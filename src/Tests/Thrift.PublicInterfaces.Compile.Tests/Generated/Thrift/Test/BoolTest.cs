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
  public partial class BoolTest : TBase
  {
    private bool _b;
    private string _s;

    public bool B
    {
      get
      {
        return _b;
      }
      set
      {
        __isset.b = true;
        this._b = value;
      }
    }

    public string S
    {
      get
      {
        return _s;
      }
      set
      {
        __isset.s = true;
        this._s = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool b;
      public bool s;
    }

    public BoolTest() {
      this._b = true;
      this.__isset.b = true;
      this._s = "true";
      this.__isset.s = true;
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
              if (field.Type == TType.Bool) {
                B = iprot.ReadBool();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 2:
              if (field.Type == TType.String) {
                S = iprot.ReadString();
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
        TStruct struc = new TStruct("BoolTest");
        oprot.WriteStructBegin(struc);
        TField field = new TField();
        if (__isset.b) {
          field.Name = "b";
          field.Type = TType.Bool;
          field.ID = 1;
          oprot.WriteFieldBegin(field);
          oprot.WriteBool(B);
          oprot.WriteFieldEnd();
        }
        if (S != null && __isset.s) {
          field.Name = "s";
          field.Type = TType.String;
          field.ID = 2;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(S);
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
      StringBuilder __sb = new StringBuilder("BoolTest(");
      bool __first = true;
      if (__isset.b) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("B: ");
        __sb.Append(B);
      }
      if (S != null && __isset.s) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("S: ");
        __sb.Append(S);
      }
      __sb.Append(")");
      return __sb.ToString();
    }

  }

}
