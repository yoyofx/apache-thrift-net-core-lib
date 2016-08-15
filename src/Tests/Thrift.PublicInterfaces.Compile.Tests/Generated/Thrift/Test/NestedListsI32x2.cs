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
  public partial class NestedListsI32x2 : TBase
  {
    private List<List<int>> _integerlist;

    public List<List<int>> Integerlist
    {
      get
      {
        return _integerlist;
      }
      set
      {
        __isset.integerlist = true;
        this._integerlist = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool integerlist;
    }

    public NestedListsI32x2() {
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
                  Integerlist = new List<List<int>>();
                  TList _list78 = iprot.ReadListBegin();
                  for( int _i79 = 0; _i79 < _list78.Count; ++_i79)
                  {
                    List<int> _elem80;
                    {
                      _elem80 = new List<int>();
                      TList _list81 = iprot.ReadListBegin();
                      for( int _i82 = 0; _i82 < _list81.Count; ++_i82)
                      {
                        int _elem83;
                        _elem83 = iprot.ReadI32();
                        _elem80.Add(_elem83);
                      }
                      iprot.ReadListEnd();
                    }
                    Integerlist.Add(_elem80);
                  }
                  iprot.ReadListEnd();
                }
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
        TStruct struc = new TStruct("NestedListsI32x2");
        oprot.WriteStructBegin(struc);
        TField field = new TField();
        if (Integerlist != null && __isset.integerlist) {
          field.Name = "integerlist";
          field.Type = TType.List;
          field.ID = 1;
          oprot.WriteFieldBegin(field);
          {
            oprot.WriteListBegin(new TList(TType.List, Integerlist.Count));
            foreach (List<int> _iter84 in Integerlist)
            {
              {
                oprot.WriteListBegin(new TList(TType.I32, _iter84.Count));
                foreach (int _iter85 in _iter84)
                {
                  oprot.WriteI32(_iter85);
                }
                oprot.WriteListEnd();
              }
            }
            oprot.WriteListEnd();
          }
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
      StringBuilder __sb = new StringBuilder("NestedListsI32x2(");
      bool __first = true;
      if (Integerlist != null && __isset.integerlist) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Integerlist: ");
        __sb.Append(Integerlist);
      }
      __sb.Append(")");
      return __sb.ToString();
    }

  }

}
