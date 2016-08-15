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
  public partial class ListTypeVersioningV1 : TBase
  {
    private List<int> _myints;
    private string _hello;

    public List<int> Myints
    {
      get
      {
        return _myints;
      }
      set
      {
        __isset.myints = true;
        this._myints = value;
      }
    }

    public string Hello
    {
      get
      {
        return _hello;
      }
      set
      {
        __isset.hello = true;
        this._hello = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool myints;
      public bool hello;
    }

    public ListTypeVersioningV1() {
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
              if (field.Type == TType.List) {
                {
                  Myints = new List<int>();
                  TList _list57 = iprot.ReadListBegin();
                  for( int _i58 = 0; _i58 < _list57.Count; ++_i58)
                  {
                    int _elem59;
                    _elem59 = iprot.ReadI32();
                    Myints.Add(_elem59);
                  }
                  iprot.ReadListEnd();
                }
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 2:
              if (field.Type == TType.String) {
                Hello = iprot.ReadString();
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
        TStruct struc = new TStruct("ListTypeVersioningV1");
        oprot.WriteStructBegin(struc);
        TField field = new TField();
        if (Myints != null && __isset.myints) {
          field.Name = "myints";
          field.Type = TType.List;
          field.ID = 1;
          oprot.WriteFieldBegin(field);
          {
            oprot.WriteListBegin(new TList(TType.I32, Myints.Count));
            foreach (int _iter60 in Myints)
            {
              oprot.WriteI32(_iter60);
            }
            oprot.WriteListEnd();
          }
          oprot.WriteFieldEnd();
        }
        if (Hello != null && __isset.hello) {
          field.Name = "hello";
          field.Type = TType.String;
          field.ID = 2;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(Hello);
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
      StringBuilder __sb = new StringBuilder("ListTypeVersioningV1(");
      bool __first = true;
      if (Myints != null && __isset.myints) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Myints: ");
        __sb.Append(Myints);
      }
      if (Hello != null && __isset.hello) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Hello: ");
        __sb.Append(Hello);
      }
      __sb.Append(")");
      return __sb.ToString();
    }

  }

}
