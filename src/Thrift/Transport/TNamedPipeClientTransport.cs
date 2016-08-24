﻿/**
 * Licensed to the Apache Software Foundation (ASF) under one
 * or more contributor license agreements. See the NOTICE file
 * distributed with this work for additional information
 * regarding copyright ownership. The ASF licenses this file
 * to you under the Apache License, Version 2.0 (the
 * "License"); you may not use this file except in compliance
 * with the License. You may obtain a copy of the License at
 *
 *   http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing,
 * software distributed under the License is distributed on an
 * "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
 * KIND, either express or implied. See the License for the
 * specific language governing permissions and limitations
 * under the License.
 *
 * Contains some contributions under the Thrift Software License.
 * Please see doc/old-thrift-license.txt in the Thrift distribution for
 * details.
 */

using System;
using System.IO.Pipes;
using System.Threading;
using System.Threading.Tasks;

namespace Thrift.Transport
{
    // ReSharper disable once InconsistentNaming
    public class TNamedPipeClientTransport : TTransport
    {
        private NamedPipeClientStream _client;

        public TNamedPipeClientTransport(string pipe) : this(".", pipe)
        {
        }

        public TNamedPipeClientTransport(string server, string pipe)
        {
            var serverName = string.IsNullOrWhiteSpace(server) ? server : ".";

            _client = new NamedPipeClientStream(serverName, pipe, PipeDirection.InOut, PipeOptions.None);
        }

        public override bool IsOpen => _client != null && _client.IsConnected;

        public override void Open()
        {
            if (IsOpen)
            {
                throw new TTransportException(TTransportException.ExceptionType.AlreadyOpen);
            }

            _client.Connect();
        }

        public override async Task OpenAsync(CancellationToken cancellationToken)
        {
            if (IsOpen)
            {
                throw new TTransportException(TTransportException.ExceptionType.AlreadyOpen);
            }

            await _client.ConnectAsync(cancellationToken);
        }

        public override void Close()
        {
            if (_client != null)
            {
                _client.Dispose();
                _client = null;
            }
        }

        public override int Read(byte[] buffer, int offset, int length)
        {
            if (_client == null)
            {
                throw new TTransportException(TTransportException.ExceptionType.NotOpen);
            }

            return _client.Read(buffer, offset, length);
        }

        public override async Task<int> ReadAsync(byte[] buffer, int offset, int length, CancellationToken cancellationToken)
        {
            if (_client == null)
            {
                throw new TTransportException(TTransportException.ExceptionType.NotOpen);
            }

            return await _client.ReadAsync(buffer, offset, length, cancellationToken);
        }

        public override void Write(byte[] buffer, int offset, int length)
        {
            if (_client == null)
            {
                throw new TTransportException(TTransportException.ExceptionType.NotOpen);
            }

            _client.Write(buffer, offset, length);
        }

        public override async Task WriteAsync(byte[] buffer, int offset, int length, CancellationToken cancellationToken)
        {
            if (_client == null)
            {
                throw new TTransportException(TTransportException.ExceptionType.NotOpen);
            }

            await _client.WriteAsync(buffer, offset, length, cancellationToken);
        }

        public override async Task FlushAsync(CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                await Task.FromCanceled(cancellationToken);
            }
        }

        public override IAsyncResult BeginFlush(AsyncCallback callback, object state)
        {
            return _client.FlushAsync();
        }

        public override void EndFlush(IAsyncResult asyncResult)
        {
            asyncResult.AsyncWaitHandle.WaitOne();
        }

        protected override void Dispose(bool disposing)
        {
            _client.Dispose();
        }
    }
}