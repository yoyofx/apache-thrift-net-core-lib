/**
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
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Thrift.Transport
{
    // ReSharper disable once InconsistentNaming
    public class TStreamTransport : TTransport
    {
        protected TStreamTransport()
        {
        }

        public TStreamTransport(Stream inputStream, Stream outputStream)
        {
            InputStream = inputStream;
            OutputStream = outputStream;
        }

        protected Stream OutputStream { get; set; }

        protected Stream InputStream { get; set; }

        public override bool IsOpen => true;

        public override void Open()
        {
        }

        public override void Close()
        {
            if (InputStream != null)
            {
                InputStream.Dispose();
                InputStream = null;
            }
            if (OutputStream != null)
            {
                OutputStream.Dispose();
                OutputStream = null;
            }
        }

        public override int Read(byte[] buf, int off, int len)
        {
            if (InputStream == null)
            {
                throw new TTransportException(TTransportException.ExceptionType.NotOpen,
                    "Cannot read from null inputstream");
            }

            return InputStream.Read(buf, off, len);
        }

        public override void Write(byte[] buf, int off, int len)
        {
            if (OutputStream == null)
            {
                throw new TTransportException(TTransportException.ExceptionType.NotOpen,
                    "Cannot write to null outputstream");
            }

            OutputStream.Write(buf, off, len);
        }

        public override void Flush()
        {
            if (OutputStream == null)
            {
                throw new TTransportException(TTransportException.ExceptionType.NotOpen,
                    "Cannot flush null outputstream");
            }

            OutputStream.Flush();
        }

        public override IAsyncResult BeginFlush(AsyncCallback callback, object state)
        {
            Console.WriteLine("TStreamTransport -> BeginFlush");
            //TODO: Check implementation
            return OutputStream.FlushAsync(CancellationToken.None);
        }

        public override void EndFlush(IAsyncResult asyncResult)
        {
            Console.WriteLine("TStreamTransport -> EndFlush");
            //TODO: Check implementation
            ((Task)asyncResult).GetAwaiter().GetResult();
        }

        private bool _isDisposed;

        // IDisposable
        protected override void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                if (disposing)
                {
                    InputStream?.Dispose();
                    OutputStream?.Dispose();
                }
            }
            _isDisposed = true;
        }
    }
}