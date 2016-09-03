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


namespace Apache.Cassandra.Test
{

    /// <summary>
    /// Row returned from a CQL query
    /// </summary>
    [DataContract(Namespace="")]
    public partial class CqlRow : TBase
    {

        [DataMember(Order = 0)]
        public byte[] Key { get; set; }

        [DataMember(Order = 0)]
        public List<Column> Columns { get; set; }

        public CqlRow()
        {
        }

        public CqlRow(byte[] key, List<Column> columns) : this()
        {
            this.Key = key;
            this.Columns = columns;
        }

        public async Task ReadAsync(TProtocol iprot, CancellationToken cancellationToken)
        {
            iprot.IncrementRecursionDepth();
            try
            {
                bool isset_key = false;
                bool isset_columns = false;
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
                                Key = await iprot.ReadBinaryAsync(cancellationToken);
                                isset_key = true;
                            }
                            else
                            {
                                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
                            }
                            break;
                        case 2:
                            if (field.Type == TType.List)
                            {
                                {
                                    Columns = new List<Column>();
                                    TList _list65 = await iprot.ReadListBeginAsync(cancellationToken);
                                    for(int _i66 = 0; _i66 < _list65.Count; ++_i66)
                                    {
                                        Column _elem67;
                                        _elem67 = new Column();
                                        await _elem67.ReadAsync(iprot, cancellationToken);
                                        Columns.Add(_elem67);
                                    }
                                    await iprot.ReadListEndAsync(cancellationToken);
                                }
                                isset_columns = true;
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
                if (!isset_key)
                {
                    throw new TProtocolException(TProtocolException.INVALID_DATA);
                }
                if (!isset_columns)
                {
                    throw new TProtocolException(TProtocolException.INVALID_DATA);
                }
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
                var struc = new TStruct("CqlRow");
                await oprot.WriteStructBeginAsync(struc, cancellationToken);
                var field = new TField();
                field.Name = "key";
                field.Type = TType.String;
                field.ID = 1;
                await oprot.WriteFieldBeginAsync(field, cancellationToken);
                await oprot.WriteBinaryAsync(Key, cancellationToken);
                await oprot.WriteFieldEndAsync(cancellationToken);
                field.Name = "columns";
                field.Type = TType.List;
                field.ID = 2;
                await oprot.WriteFieldBeginAsync(field, cancellationToken);
                {
                    await oprot.WriteListBeginAsync(new TList(TType.Struct, Columns.Count), cancellationToken);
                    foreach (Column _iter68 in Columns)
                    {
                        await _iter68.WriteAsync(oprot, cancellationToken);
                    }
                    await oprot.WriteListEndAsync(cancellationToken);
                }
                await oprot.WriteFieldEndAsync(cancellationToken);
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
            var sb = new StringBuilder("CqlRow(");
            sb.Append(", Key: ");
            sb.Append(Key);
            sb.Append(", Columns: ");
            sb.Append(Columns);
            sb.Append(")");
            return sb.ToString();
        }
    }

}
