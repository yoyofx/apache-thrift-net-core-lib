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


namespace ThriftAsync.Test
{

    [DataContract(Namespace="")]
    public partial class Bonk : TBase
    {
        private string _message;
        private int _type;

        [DataMember(Order = 0)]
        public string Message
        {
            get
            {
                return _message;
            }
            set
            {
                __isset.message = true;
                this._message = value;
            }
        }

        [DataMember(Order = 0)]
        public int Type
        {
            get
            {
                return _type;
            }
            set
            {
                __isset.type = true;
                this._type = value;
            }
        }


        [DataMember(Order = 1)]
        public Isset __isset;
        [DataContract]
        public struct Isset
        {
            [DataMember]
            public bool message;
            [DataMember]
            public bool type;
        }

        #region XmlSerializer support

        public bool ShouldSerializeMessage()
        {
            return __isset.message;
        }

        public bool ShouldSerializeType()
        {
            return __isset.type;
        }

        #endregion XmlSerializer support

        public Bonk()
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
                            if (field.Type == TType.String)
                            {
                                Message = await iprot.ReadStringAsync(cancellationToken);
                            }
                            else
                            {
                                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
                            }
                            break;
                        case 2:
                            if (field.Type == TType.I32)
                            {
                                Type = await iprot.ReadI32Async(cancellationToken);
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
                var struc = new TStruct("Bonk");
                await oprot.WriteStructBeginAsync(struc, cancellationToken);
                var field = new TField();
                if (Message != null && __isset.message)
                {
                    field.Name = "message";
                    field.Type = TType.String;
                    field.ID = 1;
                    await oprot.WriteFieldBeginAsync(field, cancellationToken);
                    await oprot.WriteStringAsync(Message, cancellationToken);
                    await oprot.WriteFieldEndAsync(cancellationToken);
                }
                if (__isset.type)
                {
                    field.Name = "type";
                    field.Type = TType.I32;
                    field.ID = 2;
                    await oprot.WriteFieldBeginAsync(field, cancellationToken);
                    await oprot.WriteI32Async(Type, cancellationToken);
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
            var sb = new StringBuilder("Bonk(");
            bool __first = true;
            if (Message != null && __isset.message)
            {
                if(!__first) { sb.Append(", "); }
                __first = false;
                sb.Append("Message: ");
                sb.Append(Message);
            }
            if (__isset.type)
            {
                if(!__first) { sb.Append(", "); }
                __first = false;
                sb.Append("Type: ");
                sb.Append(Type);
            }
            sb.Append(")");
            return sb.ToString();
        }
    }

}
