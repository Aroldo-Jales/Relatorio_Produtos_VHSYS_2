// Decompiled with JetBrains decompiler
// Type: Relatorio_Produtos_VHSYS.Classes.Utils.GenerateListPedidos
// Assembly: Relatorio_Produtos_VHSYS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3740E6A2-8A63-493B-9E56-76A1104CAF61
// Assembly location: C:\Users\Aroldo Jales\Desktop\net5.0-windows\Relatorio_Produtos_VHSYS.dll

using System.Collections.Generic;

namespace Relatorio_Produtos_VHSYS.Classes.Utils
{
  public static class GenerateListPedidos
  {
    public static List<int> returnListIdPedidos(int inicial, int final)
    {
      List<int> intList = new List<int>();
      for (int index = inicial; index <= final; ++index)
        intList.Add(index);
      return intList;
    }
  }
}
