// Decompiled with JetBrains decompiler
// Type: Relatorio_Produtos_VHSYS.Classes.Utils.StringFormatUtils
// Assembly: Relatorio_Produtos_VHSYS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3740E6A2-8A63-493B-9E56-76A1104CAF61
// Assembly location: C:\Users\Aroldo Jales\Desktop\net5.0-windows\Relatorio_Produtos_VHSYS.dll

namespace Relatorio_Produtos_VHSYS.Classes.Utils
{
  internal static class StringFormatUtils
  {
    public static string excludeNumberAfterPoint(string str)
    {
      string str1 = "";
      for (int index = 0; index < str.Length && str[index] != '.'; ++index)
        str1 += str[index].ToString();
      return str1;
    }
  }
}
