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

using Thrift.Protocol;
using Thrift.Transport;


namespace ThriftAsync.Test
{

    [DataContract(Namespace="")]
    public partial class Insanity : TBase
    {
        private Dictionary<Numberz, long> _userMap;
        private List<Xtruct> _xtructs;

        [DataMember(Order = 0)]
        public Dictionary<Numberz, long> UserMap
        {
            get
            {
                return _userMap;
            }
            set
            {
                __isset.userMap = true;
                this._userMap = value;
            }
        }

        [DataMember(Order = 0)]
        public List<Xtruct> Xtructs
        {
            get
            {
                return _xtructs;
            }
            set
            {
                __isset.xtructs = true;
                this._xtructs = value;
            }
        }


        [DataMember(Order = 1)]
        public Isset __isset;
        [DataContract]
        public struct Isset
        {
            [DataMember]
            public bool userMap;
            [DataMember]
            public bool xtructs;
        }

        #region XmlSerializer support

        public bool ShouldSerializeUserMap()
        {
            return __isset.userMap;
        }

        public bool ShouldSerializeXtructs()
        {
            return __isset.xtructs;
        }

        #endregion XmlSerializer support

        public Insanity()
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
                            if (field.Type == TType.Map)
                            {
                                {
                                    UserMap = new Dictionary<Numberz, long>();
                                    TMap _map0 = await iprot.ReadMapBeginAsync(cancellationToken);
                                    for(int _i1 = 0; _i1 < _map0.Count; ++_i1)
                                    {
                                        Numberz _key2;
                                        long _val3;
                                        _key2 = (Numberz)await iprot.ReadI32Async(cancellationToken);
                                        _val3 = await iprot.ReadI64Async(cancellationToken);
                                        UserMap[_key2] = _val3;
                                    }
                                    await iprot.ReadMapEndAsync(cancellationToken);
                                }
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
                                    Xtructs = new List<Xtruct>();
                                    TList _list4 = await iprot.ReadListBeginAsync(cancellationToken);
                                    for(int _i5 = 0; _i5 < _list4.Count; ++_i5)
                                    {
                                        Xtruct _elem6;
                                        _elem6 = new Xtruct();
                                        await _elem6.ReadAsync(iprot, cancellationToken);
                                        Xtructs.Add(_elem6);
                                    }
                                    await iprot.ReadListEndAsync(cancellationToken);
                                }
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
                var struc = new TStruct("Insanity");
                await oprot.WriteStructBeginAsync(struc, cancellationToken);
                var field = new TField();
                if (UserMap != null && __isset.userMap)
                {
                    field.Name = "userMap";
                    field.Type = TType.Map;
                    field.ID = 1;
                    await oprot.WriteFieldBeginAsync(field, cancellationToken);
                    {
                        await oprot.WriteMapBeginAsync(new TMap(TType.I32, TType.I64, UserMap.Count), cancellationToken);
                        foreach (Numberz _iter7 in UserMap.Keys)
                        {
                            await oprot.WriteI32Async((int)_iter7, cancellationToken);
                            await oprot.WriteI64Async(UserMap[_iter7], cancellationToken);
                        }
                        await oprot.WriteMapEndAsync(cancellationToken);
                    }
                    await oprot.WriteFieldEndAsync(cancellationToken);
                }
                if (Xtructs != null && __isset.xtructs)
                {
                    field.Name = "xtructs";
                    field.Type = TType.List;
                    field.ID = 2;
                    await oprot.WriteFieldBeginAsync(field, cancellationToken);
                    {
                        await oprot.WriteListBeginAsync(new TList(TType.Struct, Xtructs.Count), cancellationToken);
                        foreach (Xtruct _iter8 in Xtructs)
                        {
                            await _iter8.WriteAsync(oprot, cancellationToken);
                        }
                        await oprot.WriteListEndAsync(cancellationToken);
                    }
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
            var sb = new StringBuilder("Insanity(");
            bool __first = true;
            if (UserMap != null && __isset.userMap)
            {
                if(!__first) { sb.Append(", "); }
                __first = false;
                sb.Append("UserMap: ");
                sb.Append(UserMap);
            }
            if (Xtructs != null && __isset.xtructs)
            {
                if(!__first) { sb.Append(", "); }
                __first = false;
                sb.Append("Xtructs: ");
                sb.Append(Xtructs);
            }
            sb.Append(")");
            return sb.ToString();
        }
    }

}
