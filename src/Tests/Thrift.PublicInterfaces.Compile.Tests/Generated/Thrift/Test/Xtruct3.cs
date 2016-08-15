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
  public partial class Xtruct3 : TBase
  {
    private string _string_thing;
    private int _changed;
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

    public int Changed
    {
      get
      {
        return _changed;
      }
      set
      {
        __isset.changed = true;
        this._changed = value;
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
      public bool changed;
      public bool i32_thing;
      public bool i64_thing;
    }

    public Xtruct3() {
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
              if (field.Type == TType.I32) {
                Changed = iprot.ReadI32();
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
        TStruct struc = new TStruct("Xtruct3");
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
        if (__isset.changed) {
          field.Name = "changed";
          field.Type = TType.I32;
          field.ID = 4;
          oprot.WriteFieldBegin(field);
          oprot.WriteI32(Changed);
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
      StringBuilder __sb = new StringBuilder("Xtruct3(");
      bool __first = true;
      if (String_thing != null && __isset.string_thing) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("String_thing: ");
        __sb.Append(String_thing);
      }
      if (__isset.changed) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Changed: ");
        __sb.Append(Changed);
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
