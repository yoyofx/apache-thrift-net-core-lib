/**
 * Autogenerated by Thrift Compiler (@PACKAGE_VERSION@)
 *
 * DO NOT EDIT UNLESS YOU ARE SURE THAT YOU KNOW WHAT YOU ARE DOING
 *  @generated
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Thrift;
using Thrift.Collections;
using System.ServiceModel;
using System.Runtime.Serialization;

using Thrift.Protocols;
using Thrift.Protocols.Entities;
using Thrift.Protocols.Utilities;
using Thrift.Transports;
using Thrift.Transports.Client;
using Thrift.Transports.Server;


namespace Thrift.Samples
{
    public partial class SharedService
    {
        [ServiceContract(Namespace="")]
        public interface IAsync
        {
            [OperationContract]
            Task<SharedStruct> GetStructAsync(int key, CancellationToken cancellationToken);

        }


        public class Client : TBaseClient, IDisposable, IAsync
        {
            public Client(TProtocol protocol) : this(protocol, protocol)
            {
            }

            public Client(TProtocol inputProtocol, TProtocol outputProtocol) : base(inputProtocol, outputProtocol)            {
            }
            public async Task<SharedStruct> GetStructAsync(int key, CancellationToken cancellationToken)
            {
                await OutputProtocol.WriteMessageBeginAsync(new TMessage("GetStruct", TMessageType.Call, SeqId), cancellationToken);
                
                var args = new GetStructArgs();
                args.Key = key;
                
                await args.WriteAsync(OutputProtocol, cancellationToken);
                await OutputProtocol.WriteMessageEndAsync(cancellationToken);
                await OutputProtocol.Transport.FlushAsync(cancellationToken);
                
                var msg = await InputProtocol.ReadMessageBeginAsync(cancellationToken);
                if (msg.Type == TMessageType.Exception)
                {
                    var x = await TApplicationException.ReadAsync(InputProtocol, cancellationToken);
                    await InputProtocol.ReadMessageEndAsync(cancellationToken);
                    throw x;
                }

                var result = new GetStructResult();
                await result.ReadAsync(InputProtocol, cancellationToken);
                await InputProtocol.ReadMessageEndAsync(cancellationToken);
                if (result.__isset.success)
                {
                    return result.Success;
                }
                throw new TApplicationException(TApplicationException.ExceptionType.MissingResult, "GetStruct failed: unknown result");
            }

        }

        public class AsyncProcessor : ITAsyncProcessor
        {
            private IAsync _iAsync;

            public AsyncProcessor(IAsync iAsync)
            {
                if (iAsync == null) throw new ArgumentNullException(nameof(iAsync));

                _iAsync = iAsync;
                processMap_["GetStruct"] = GetStruct_ProcessAsync;
            }

            protected delegate Task ProcessFunction(int seqid, TProtocol iprot, TProtocol oprot, CancellationToken cancellationToken);
            protected Dictionary<string, ProcessFunction> processMap_ = new Dictionary<string, ProcessFunction>();

            public async Task<bool> ProcessAsync(TProtocol iprot, TProtocol oprot)
            {
                return await ProcessAsync(iprot, oprot, CancellationToken.None);
            }

            public async Task<bool> ProcessAsync(TProtocol iprot, TProtocol oprot, CancellationToken cancellationToken)
            {
                try
                {
                    var msg = await iprot.ReadMessageBeginAsync(cancellationToken);

                    ProcessFunction fn;
                    processMap_.TryGetValue(msg.Name, out fn);

                    if (fn == null)
                    {
                        await TProtocolUtil.SkipAsync(iprot, TType.Struct, cancellationToken);
                        await iprot.ReadMessageEndAsync(cancellationToken);
                        var x = new TApplicationException (TApplicationException.ExceptionType.UnknownMethod, "Invalid method name: '" + msg.Name + "'");
                        await oprot.WriteMessageBeginAsync(new TMessage(msg.Name, TMessageType.Exception, msg.SeqID), cancellationToken);
                        await x.WriteAsync(oprot, cancellationToken);
                        await oprot.WriteMessageEndAsync(cancellationToken);
                        await oprot.Transport.FlushAsync(cancellationToken);
                        return true;
                    }

                    await fn(msg.SeqID, iprot, oprot, cancellationToken);

                }
                catch (IOException)
                {
                    return false;
                }

                return true;
            }

            public async Task GetStruct_ProcessAsync(int seqid, TProtocol iprot, TProtocol oprot, CancellationToken cancellationToken)
            {
                var args = new GetStructArgs();
                await args.ReadAsync(iprot, cancellationToken);
                await iprot.ReadMessageEndAsync(cancellationToken);
                var result = new GetStructResult();
                try
                {
                    result.Success = await _iAsync.GetStructAsync(args.Key, cancellationToken);
                    await oprot.WriteMessageBeginAsync(new TMessage("GetStruct", TMessageType.Reply, seqid), cancellationToken); 
                    await result.WriteAsync(oprot, cancellationToken);
                }
                catch (TTransportException)
                {
                  throw;
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine("Error occurred in processor:");
                    Console.Error.WriteLine(ex.ToString());
                    var x = new TApplicationException(TApplicationException.ExceptionType.InternalError," Internal error.");
                    await oprot.WriteMessageBeginAsync(new TMessage("GetStruct", TMessageType.Exception, seqid), cancellationToken);
                    await x.WriteAsync(oprot, cancellationToken);
                }
                await oprot.WriteMessageEndAsync(cancellationToken);
                await oprot.Transport.FlushAsync(cancellationToken);
            }

        }


        [DataContract(Namespace="")]
        public partial class GetStructArgs : TBase
        {
            private int _key;

            [DataMember(Order = 0)]
            public int Key
            {
                get
                {
                    return _key;
                }
                set
                {
                    __isset.key = true;
                    this._key = value;
                }
            }


            [DataMember(Order = 1)]
            public Isset __isset;
            [DataContract]
            public struct Isset
            {
                [DataMember]
                public bool key;
            }

            #region XmlSerializer support

            public bool ShouldSerializeKey()
            {
                return __isset.key;
            }

            #endregion XmlSerializer support

            public GetStructArgs()
            {
            }

            public async Task ReadAsync(TProtocol iprot, CancellationToken cancellationToken)
            {
                iprot.IncrementRecursionDepth();
                try
                {
                    TField field;
                    await iprot.ReadStructBeginAsync(cancellationToken);
                    while (true)
                    {
                        field = await iprot.ReadFieldBeginAsync(cancellationToken);
                        if (field.Type == TType.Stop)
                        {
                            break;
                        }

                        switch (field.ID)
                        {
                            case 1:
                                if (field.Type == TType.I32)
                                {
                                    Key = await iprot.ReadI32Async(cancellationToken);
                                }
                                else
                                {
                                    await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
                                }
                                break;
                            default: 
                                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
                                break;
                        }

                        await iprot.ReadFieldEndAsync(cancellationToken);
                    }

                    await iprot.ReadStructEndAsync(cancellationToken);
                }
                finally
                {
                    iprot.DecrementRecursionDepth();
                }
            }

            public async Task WriteAsync(TProtocol oprot, CancellationToken cancellationToken)
            {
                oprot.IncrementRecursionDepth();
                try
                {
                    var struc = new TStruct("GetStruct_args");
                    await oprot.WriteStructBeginAsync(struc, cancellationToken);
                    var field = new TField();
                    if (__isset.key)
                    {
                        field.Name = "key";
                        field.Type = TType.I32;
                        field.ID = 1;
                        await oprot.WriteFieldBeginAsync(field, cancellationToken);
                        await oprot.WriteI32Async(Key, cancellationToken);
                        await oprot.WriteFieldEndAsync(cancellationToken);
                    }
                    await oprot.WriteFieldStopAsync(cancellationToken);
                    await oprot.WriteStructEndAsync(cancellationToken);
                }
                finally
                {
                    oprot.DecrementRecursionDepth();
                }
            }

            public override string ToString()
            {
                var sb = new StringBuilder("GetStruct_args(");
                bool __first = true;
                if (__isset.key)
                {
                    if(!__first) { sb.Append(", "); }
                    __first = false;
                    sb.Append("Key: ");
                    sb.Append(Key);
                }
                sb.Append(")");
                return sb.ToString();
            }
        }


        [DataContract(Namespace="")]
        public partial class GetStructResult : TBase
        {
            private SharedStruct _success;

            [DataMember(Order = 0)]
            public SharedStruct Success
            {
                get
                {
                    return _success;
                }
                set
                {
                    __isset.success = true;
                    this._success = value;
                }
            }


            [DataMember(Order = 1)]
            public Isset __isset;
            [DataContract]
            public struct Isset
            {
                [DataMember]
                public bool success;
            }

            #region XmlSerializer support

            public bool ShouldSerializeSuccess()
            {
                return __isset.success;
            }

            #endregion XmlSerializer support

            public GetStructResult()
            {
            }

            public async Task ReadAsync(TProtocol iprot, CancellationToken cancellationToken)
            {
                iprot.IncrementRecursionDepth();
                try
                {
                    TField field;
                    await iprot.ReadStructBeginAsync(cancellationToken);
                    while (true)
                    {
                        field = await iprot.ReadFieldBeginAsync(cancellationToken);
                        if (field.Type == TType.Stop)
                        {
                            break;
                        }

                        switch (field.ID)
                        {
                            case 0:
                                if (field.Type == TType.Struct)
                                {
                                    Success = new SharedStruct();
                                    await Success.ReadAsync(iprot, cancellationToken);
                                }
                                else
                                {
                                    await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
                                }
                                break;
                            default: 
                                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
                                break;
                        }

                        await iprot.ReadFieldEndAsync(cancellationToken);
                    }

                    await iprot.ReadStructEndAsync(cancellationToken);
                }
                finally
                {
                    iprot.DecrementRecursionDepth();
                }
            }

            public async Task WriteAsync(TProtocol oprot, CancellationToken cancellationToken)
            {
                oprot.IncrementRecursionDepth();
                try
                {
                    var struc = new TStruct("GetStruct_result");
                    await oprot.WriteStructBeginAsync(struc, cancellationToken);
                    var field = new TField();

                    if(this.__isset.success)
                    {
                        if (Success != null)
                        {
                            field.Name = "Success";
                            field.Type = TType.Struct;
                            field.ID = 0;
                            await oprot.WriteFieldBeginAsync(field, cancellationToken);
                            await Success.WriteAsync(oprot, cancellationToken);
                            await oprot.WriteFieldEndAsync(cancellationToken);
                        }
                    }
                    await oprot.WriteFieldStopAsync(cancellationToken);
                    await oprot.WriteStructEndAsync(cancellationToken);
                }
                finally
                {
                    oprot.DecrementRecursionDepth();
                }
            }

            public override string ToString()
            {
                var sb = new StringBuilder("GetStruct_result(");
                bool __first = true;
                if (Success != null && __isset.success)
                {
                    if(!__first) { sb.Append(", "); }
                    __first = false;
                    sb.Append("Success: ");
                    sb.Append(Success== null ? "<null>" : Success.ToString());
                }
                sb.Append(")");
                return sb.ToString();
            }
        }

    }
}
