// Decompiled with JetBrains decompiler
// Type: Relatorio_Produtos_VHSYS.Program
// Assembly: Relatorio_Produtos_VHSYS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3740E6A2-8A63-493B-9E56-76A1104CAF61
// Assembly location: C:\Users\Aroldo Jales\Desktop\net5.0-windows\Relatorio_Produtos_VHSYS.dll

using System;
using System.Windows.Forms;

namespace Relatorio_Produtos_VHSYS
{
  internal static class Program
  {
    [STAThread]
    private static void Main()
    {            
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run((Form) new mainForm());
    }
  }
}
