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
using Thrift;
using Thrift.Collections;
using System.Runtime.Serialization;
using Thrift.Protocol;
using Thrift.Transport;

namespace Thrift.Test
{

  #if !SILVERLIGHT
  [Serializable]
  #endif
  public partial class Xtruct : TBase
  {
    private string _string_thing;
    private sbyte _byte_thing;
    private short _i16_thing;
    private int _i32_thing;
    private long _i64_thing;

    public string String_thing
    {
      get
      {
        return _string_thing;
      }
      set
      {
        __isset.string_thing = true;
        this._string_thing = value;
      }
    }

    public sbyte Byte_thing
    {
      get
      {
        return _byte_thing;
      }
      set
      {
        __isset.byte_thing = true;
        this._byte_thing = value;
      }
    }

    public short I16_thing
    {
      get
      {
        return _i16_thing;
      }
      set
      {
        __isset.i16_thing = true;
        this._i16_thing = value;
      }
    }

    public int I32_thing
    {
      get
      {
        return _i32_thing;
      }
      set
      {
        __isset.i32_thing = true;
        this._i32_thing = value;
      }
    }

    public long I64_thing
    {
      get
      {
        return _i64_thing;
      }
      set
      {
        __isset.i64_thing = true;
        this._i64_thing = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool string_thing;
      public bool byte_thing;
      public bool i16_thing;
      public bool i32_thing;
      public bool i64_thing;
    }

    public Xtruct() {
    }

    public void Read (TProtocol iprot)
    {
      iprot.IncrementRecursionDepth();
      try
      {
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
              if (field.Type == TType.String) {
                String_thing = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 4:
              if (field.Type == TType.Byte) {
                Byte_thing = iprot.ReadByte();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 7:
              if (field.Type == TType.I16) {
                I16_thing = iprot.ReadI16();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 9:
              if (field.Type == TType.I32) {
                I32_thing = iprot.ReadI32();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 11:
              if (field.Type == TType.I64) {
                I64_thing = iprot.ReadI64();
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
        TStruct struc = new TStruct("Xtruct");
        oprot.WriteStructBegin(struc);
        TField field = new TField();
        if (String_thing != null && __isset.string_thing) {
          field.Name = "string_thing";
          field.Type = TType.String;
          field.ID = 1;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(String_thing);
          oprot.WriteFieldEnd();
        }
        if (__isset.byte_thing) {
          field.Name = "byte_thing";
          field.Type = TType.Byte;
          field.ID = 4;
          oprot.WriteFieldBegin(field);
          oprot.WriteByte(Byte_thing);
          oprot.WriteFieldEnd();
        }
        if (__isset.i16_thing) {
          field.Name = "i16_thing";
          field.Type = TType.I16;
          field.ID = 7;
          oprot.WriteFieldBegin(field);
          oprot.WriteI16(I16_thing);
          oprot.WriteFieldEnd();
        }
        if (__isset.i32_thing) {
          field.Name = "i32_thing";
          field.Type = TType.I32;
          field.ID = 9;
          oprot.WriteFieldBegin(field);
          oprot.WriteI32(I32_thing);
          oprot.WriteFieldEnd();
        }
        if (__isset.i64_thing) {
          field.Name = "i64_thing";
          field.Type = TType.I64;
          field.ID = 11;
          oprot.WriteFieldBegin(field);
          oprot.WriteI64(I64_thing);
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
      StringBuilder __sb = new StringBuilder("Xtruct(");
      bool __first = true;
      if (String_thing != null && __isset.string_thing) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("String_thing: ");
        __sb.Append(String_thing);
      }
      if (__isset.byte_thing) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Byte_thing: ");
        __sb.Append(Byte_thing);
      }
      if (__isset.i16_thing) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("I16_thing: ");
        __sb.Append(I16_thing);
      }
      if (__isset.i32_thing) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("I32_thing: ");
        __sb.Append(I32_thing);
      }
      if (__isset.i64_thing) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("I64_thing: ");
        __sb.Append(I64_thing);
      }
      __sb.Append(")");
      return __sb.ToString();
    }

  }

}
