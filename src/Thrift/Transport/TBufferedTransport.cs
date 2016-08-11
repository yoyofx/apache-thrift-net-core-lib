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
 */

using System;
using System.IO;

namespace Thrift.Transport
{
    // ReSharper disable once InconsistentNaming
    public class TBufferedTransport : TTransport
    {
        private readonly int _bufSize;
        private readonly MemoryStream _inputBuffer = new MemoryStream(0);
        private readonly MemoryStream _outputBuffer = new MemoryStream(0);
        private readonly TTransport _transport;

        public TBufferedTransport(TTransport transport, int bufSize = 1024)
        {
            if (transport == null)
                throw new ArgumentNullException(nameof(transport));
            if (bufSize <= 0)
                throw new ArgumentOutOfRangeException(nameof(bufSize), "Buffer size must be a positive number.");
            _transport = transport;
            _bufSize = bufSize;
        }

        public TTransport UnderlyingTransport
        {
            get
            {
                CheckNotDisposed();
                return _transport;
            }
        }

        public override bool IsOpen => !_isDisposed && _transport.IsOpen;

      public override void Open()
        {
            CheckNotDisposed();
            _transport.Open();
        }

        public override void Close()
        {
            CheckNotDisposed();
            _transport.Close();
        }

        public override int Read(byte[] buf, int off, int len)
        {
            CheckNotDisposed();
            ValidateBufferArgs(buf, off, len);
            if (!IsOpen)
                throw new TTransportException(TTransportException.ExceptionType.NotOpen);
            if (_inputBuffer.Capacity < _bufSize)
                _inputBuffer.Capacity = _bufSize;
            var got = _inputBuffer.Read(buf, off, len);
            if (got > 0)
                return got;

            _inputBuffer.Seek(0, SeekOrigin.Begin);
            _inputBuffer.SetLength(_inputBuffer.Capacity);

            ArraySegment<byte> bufSegment;
            _inputBuffer.TryGetBuffer(out bufSegment);

            var filled = _transport.Read(bufSegment.Array, 0, (int) _inputBuffer.Length);
            _inputBuffer.SetLength(filled);
            if (filled == 0)
                return 0;
            return Read(buf, off, len);
        }

        public override void Write(byte[] buf, int off, int len)
        {
            CheckNotDisposed();
            ValidateBufferArgs(buf, off, len);
            if (!IsOpen)
                throw new TTransportException(TTransportException.ExceptionType.NotOpen);
            // Relative offset from "off" argument
            var offset = 0;
            if (_outputBuffer.Length > 0)
            {
                var capa = (int) (_outputBuffer.Capacity - _outputBuffer.Length);
                var writeSize = capa <= len ? capa : len;
                _outputBuffer.Write(buf, off, writeSize);
                offset += writeSize;
                if (writeSize == capa)
                {
                    ArraySegment<byte> bufSegment;
                    _outputBuffer.TryGetBuffer(out bufSegment);

                    _transport.Write(bufSegment.Array, 0, (int) _outputBuffer.Length);
                    _outputBuffer.SetLength(0);
                }
            }
            while (len - offset >= _bufSize)
            {
                _transport.Write(buf, off + offset, _bufSize);
                offset += _bufSize;
            }
            var remain = len - offset;
            if (remain > 0)
            {
                if (_outputBuffer.Capacity < _bufSize)
                    _outputBuffer.Capacity = _bufSize;
                _outputBuffer.Write(buf, off + offset, remain);
            }
        }

        public override void Flush()
        {
            CheckNotDisposed();
            if (!IsOpen)
                throw new TTransportException(TTransportException.ExceptionType.NotOpen);
            if (_outputBuffer.Length > 0)
            {
                ArraySegment<byte> bufSegment;
                _outputBuffer.TryGetBuffer(out bufSegment);
                _transport.Write(bufSegment.Array, 0, (int) _outputBuffer.Length);
                _outputBuffer.SetLength(0);
            }
            _transport.Flush();
        }

        private void CheckNotDisposed()
        {
            if (_isDisposed)
                throw new ObjectDisposedException("TBufferedTransport");
        }

        private bool _isDisposed;

        // IDisposable
        protected override void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                if (disposing)
                {
                    _inputBuffer.Dispose();
                    _outputBuffer.Dispose();
                }
            }
            _isDisposed = true;
        }
    }
}