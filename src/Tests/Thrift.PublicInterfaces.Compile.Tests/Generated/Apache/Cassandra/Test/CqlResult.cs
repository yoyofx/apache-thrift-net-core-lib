/**
 * Autogenerated by Thrift Compiler (0.9.3)
 *
 * DO NOT EDIT UNLESS YOU ARE SURE THAT YOU KNOW WHAT YOU ARE DOING
 *  @generated
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Thrift;
using Thrift.Collections;
using System.Runtime.Serialization;
using Thrift.Protocol;
using Thrift.Transport;

namespace Apache.Cassandra.Test
{

  #if !SILVERLIGHT
  [Serializable]
  #endif
  public partial class CqlResult : TBase
  {
    private List<CqlRow> _rows;
    private int _num;
    private CqlMetadata _schema;

    /// <summary>
    /// 
    /// <seealso cref="CqlResultType"/>
    /// </summary>
    public CqlResultType Type { get; set; }

    public List<CqlRow> Rows
    {
      get
      {
        return _rows;
      }
      set
      {
        __isset.rows = true;
        this._rows = value;
      }
    }

    public int Num
    {
      get
      {
        return _num;
      }
      set
      {
        __isset.num = true;
        this._num = value;
      }
    }

    public CqlMetadata Schema
    {
      get
      {
        return _schema;
      }
      set
      {
        __isset.schema = true;
        this._schema = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool rows;
      public bool num;
      public bool schema;
    }

    public CqlResult() {
    }

    public CqlResult(CqlResultType type) : this() {
      this.Type = type;
    }

    public void Read (TProtocol iprot)
    {
      iprot.IncrementRecursionDepth();
      try
      {
        bool isset_type = false;
        TField field;
        iprot.ReadStructBegin();
        while (true)
        {
          field = iprot.ReadFieldBegin();
          if (field.Type == TType.Stop) { 
            break;
          }
          switch (field.ID)
          {
            case 1:
              if (field.Type == TType.I32) {
                Type = (CqlResultType)iprot.ReadI32();
                isset_type = true;
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 2:
              if (field.Type == TType.List) {
                {
                  Rows = new List<CqlRow>();
                  TList _list79 = iprot.ReadListBegin();
                  for( int _i80 = 0; _i80 < _list79.Count; ++_i80)
                  {
                    CqlRow _elem81;
                    _elem81 = new CqlRow();
                    _elem81.Read(iprot);
                    Rows.Add(_elem81);
                  }
                  iprot.ReadListEnd();
                }
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 3:
              if (field.Type == TType.I32) {
                Num = iprot.ReadI32();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 4:
              if (field.Type == TType.Struct) {
                Schema = new CqlMetadata();
                Schema.Read(iprot);
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            default: 
              TProtocolUtil.Skip(iprot, field.Type);
              break;
          }
          iprot.ReadFieldEnd();
        }
        iprot.ReadStructEnd();
        if (!isset_type)
          throw new TProtocolException(TProtocolException.INVALID_DATA);
      }
      finally
      {
        iprot.DecrementRecursionDepth();
      }
    }

    public void Write(TProtocol oprot) {
      oprot.IncrementRecursionDepth();
      try
      {
        TStruct struc = new TStruct("CqlResult");
        oprot.WriteStructBegin(struc);
        TField field = new TField();
        field.Name = "type";
        field.Type = TType.I32;
        field.ID = 1;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32((int)Type);
        oprot.WriteFieldEnd();
        if (Rows != null && __isset.rows) {
          field.Name = "rows";
          field.Type = TType.List;
          field.ID = 2;
          oprot.WriteFieldBegin(field);
          {
            oprot.WriteListBegin(new TList(TType.Struct, Rows.Count));
            foreach (CqlRow _iter82 in Rows)
            {
              _iter82.Write(oprot);
            }
            oprot.WriteListEnd();
          }
          oprot.WriteFieldEnd();
        }
        if (__isset.num) {
          field.Name = "num";
          field.Type = TType.I32;
          field.ID = 3;
          oprot.WriteFieldBegin(field);
          oprot.WriteI32(Num);
          oprot.WriteFieldEnd();
        }
        if (Schema != null && __isset.schema) {
          field.Name = "schema";
          field.Type = TType.Struct;
          field.ID = 4;
          oprot.WriteFieldBegin(field);
          Schema.Write(oprot);
          oprot.WriteFieldEnd();
        }
        oprot.WriteFieldStop();
        oprot.WriteStructEnd();
      }
      finally
      {
        oprot.DecrementRecursionDepth();
      }
    }

    public override string ToString() {
      StringBuilder __sb = new StringBuilder("CqlResult(");
      __sb.Append(", Type: ");
      __sb.Append(Type);
      if (Rows != null && __isset.rows) {
        __sb.Append(", Rows: ");
        __sb.Append(Rows);
      }
      if (__isset.num) {
        __sb.Append(", Num: ");
        __sb.Append(Num);
      }
      if (Schema != null && __isset.schema) {
        __sb.Append(", Schema: ");
        __sb.Append(Schema== null ? "<null>" : Schema.ToString());
      }
      __sb.Append(")");
      return __sb.ToString();
    }

  }

}