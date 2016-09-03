﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Core;
using Thrift;
using Thrift.Samples;
using Thrift.Server;
using Thrift.Transports;
using Thrift.Transports.Server;

namespace Server
{
    public class Program
    {
        static readonly Logger Logger = new LoggerConfiguration()
            .MinimumLevel.Verbose()
            .Enrich.WithThreadId()
            .WriteTo.ColoredConsole(
                outputTemplate:
                "{Timestamp:yyyy-MM-dd HH:mm:ss:fff} [{Level}] [ThreadId:{ThreadId}] {SourceContext:l} {Message}{NewLine}{Exception}")
            .CreateLogger();

        private enum Transport
        {
            Tcp,
            NamedPipe,
            Http,
            TcpTls
        }

        public static void Main(string[] args)
        {
            using (var source = new CancellationTokenSource())
            {
                RunAsync(args, source.Token).GetAwaiter().GetResult();

                Logger.Information("Press any key to stop...");

                Console.ReadLine();
                source.Cancel();
            }
        }

        private static void DisplayHelp()
        {
            Console.WriteLine(@"
Usage: 
    Server.exe 
        will diplay help information 

    Server.exe -t:<transport>
        will run server with specified arguments

Options:
    -t (transport): 
        tcp - tcp transport will be used (host - ""localhost"", port - 9090)
        namedpipe - namedpipe transport will be used (pipe address - "".test"")
        http - http transport will be used (http address - ""localhost:9090"")
        
Sample:
    Server.exe -t:tcp 
");
        }

        private static async Task RunAsync(string[] args, CancellationToken cancellationToken)
        {
            if (args == null || !args.Any(x => x.ToLowerInvariant().Contains("-t:")))
            {
                DisplayHelp();
                return;
            }

            var transport = args.First(x => x.StartsWith("-t")).Split(':')[1];
            Transport selectedTransport;
            if (Enum.TryParse(transport, true, out selectedTransport))
            {
                switch (selectedTransport)
                {
                    case Transport.Tcp:
                    case Transport.NamedPipe:
                    case Transport.TcpTls:
                        await RunSelectedConfigurationAsync(selectedTransport, cancellationToken);
                        break;
                    case Transport.Http:
                        new HttpServerSample().Run(cancellationToken);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            else
            {
                DisplayHelp();
            }
        }

        private static async Task RunSelectedConfigurationAsync(Transport transport, CancellationToken cancellationToken)
        {
            Logger.Information($"Selected TAsyncServer with {transport} transport");

            var fabric = new LoggerFactory().AddSerilog(Logger);
            var handler = new CalculatorAsyncHandler();
            var processor = new Calculator.AsyncProcessor(handler);
            TServerTransport serverTransport = null;
            
            switch (transport)
            {
                case Transport.Tcp:
                    serverTransport = new TServerSocketTransport(9090);
                    break;
                case Transport.NamedPipe:
                    serverTransport = new TNamedPipeServerTransport(".test");
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(transport), transport, null);
            }

            try
            {
                var server = new AsyncBaseServer(processor, serverTransport, fabric);

                Logger.Information("Starting the server...");
                await server.ServeAsync(cancellationToken);

            }
            catch (Exception x)
            {
                Logger.Information(x, "Error");
            }

            Logger.Information("Server stopped.");
        }

        public class HttpServerSample
        {
            public void Run(CancellationToken cancellationToken)
            {
                var config = new ConfigurationBuilder()
                    .AddEnvironmentVariables(prefix: "ASPNETCORE_")
                    .Build();

                var host = new WebHostBuilder()
                    .UseConfiguration(config)
                    .UseKestrel()
                    .UseUrls("http://localhost:9090")
                    .UseContentRoot(Directory.GetCurrentDirectory())
                    .UseIISIntegration()
                    .UseStartup<Startup>()
                    .Build();

                host.Run(cancellationToken);
            }

            public class Startup
            {
                public Startup(IHostingEnvironment env)
                {
                    var builder = new ConfigurationBuilder()
                        .SetBasePath(env.ContentRootPath)
                        .AddEnvironmentVariables();

                    Configuration = builder.Build();
                }

                public IConfigurationRoot Configuration { get; }

                // This method gets called by the runtime. Use this method to add services to the container.
                public void ConfigureServices(IServiceCollection services)
                {
                    services.AddTransient<Calculator.IAsync, CalculatorAsyncHandler>();
                    services.AddTransient<ITAsyncProcessor, Calculator.AsyncProcessor>();
                    services.AddTransient<THttpServerTransport, THttpServerTransport>();
                }

                // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
                public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
                {
                    loggerFactory.AddSerilog(Logger);
                    app.UseMiddleware<THttpServerTransport>();
                }
            }
        }

        public class CalculatorAsyncHandler : Calculator.IAsync
        {
            Dictionary<int, SharedStruct> _log;

            public CalculatorAsyncHandler()
            {
                _log = new Dictionary<int, SharedStruct>();
            }

            public async Task<SharedStruct> GetStructAsync(int key, CancellationToken cancellationToken)
            {
                Logger.Information("GetStructAsync({0})", key);
                return await Task.FromResult(_log[key]);
            }

            public async Task PingAsync(CancellationToken cancellationToken)
            {
                Logger.Information("PingAsync()");
                await Task.CompletedTask;
            }

            public async Task<int> AddAsync(int num1, int num2, CancellationToken cancellationToken)
            {
                Logger.Information($"AddAsync({num1},{num2})");
                return await Task.FromResult(num1 + num2);
            }

            public async Task<int> CalculateAsync(int logid, Work w, CancellationToken cancellationToken)
            {
                Logger.Information($"CalculateAsync({logid}, [{w.Op},{w.Num1},{w.Num2}])");

                var val = 0;
                switch (w.Op)
                {
                    case Operation.Add:
                        val = w.Num1 + w.Num2;
                        break;

                    case Operation.Substract:
                        val = w.Num1 - w.Num2;
                        break;

                    case Operation.Multiply:
                        val = w.Num1 * w.Num2;
                        break;

                    case Operation.Divide:
                        if (w.Num2 == 0)
                        {
                            var io = new InvalidOperation
                            {
                                WhatOp = (int)w.Op,
                                Why = "Cannot divide by 0"
                            };

                            throw io;
                        }
                        val = w.Num1 / w.Num2;
                        break;

                    default:
                        {
                            var io = new InvalidOperation
                            {
                                WhatOp = (int)w.Op,
                                Why = "Unknown operation"
                            };

                            throw io;
                        }
                }

                var entry = new SharedStruct
                {
                    Key = logid,
                    Value = val.ToString()
                };

                _log[logid] = entry;

                return await Task.FromResult(val);
            }

            public async Task ZipAsync(CancellationToken cancellationToken)
            {
                Logger.Information("ZipAsync() with delay 100mc");
                await Task.Delay(100, CancellationToken.None);
            }
        }
    }
}