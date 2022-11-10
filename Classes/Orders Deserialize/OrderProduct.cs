// Decompiled with JetBrains decompiler
// Type: Relatorio_Produtos_VHSYS.Classes.OrderProduct
// Assembly: Relatorio_Produtos_VHSYS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3740E6A2-8A63-493B-9E56-76A1104CAF61
// Assembly location: C:\Users\Aroldo Jales\Desktop\net5.0-windows\Relatorio_Produtos_VHSYS.dll

namespace Relatorio_Produtos_VHSYS.Classes
{
  internal class OrderProduct
  {
    public int id_ped_produto { get; set; }

    public int id_pedido { get; set; }

    public int id_produto { get; set; }

    public object id_almoxarifado { get; set; }

    public object id_lote { get; set; }

    public string desc_produto { get; set; }

    public string qtde_produto { get; set; }

    public string desconto_produto { get; set; }

    public string ipi_produto { get; set; }

    public string icms_produto { get; set; }

    public string valor_unit_produto { get; set; }

    public string valor_custo_produto { get; set; }

    public string valor_total_produto { get; set; }

    public string valor_desconto { get; set; }

    public string peso_produto { get; set; }

    public string peso_liq_produto { get; set; }

    public object info_adicional { get; set; }

    public object xPed_produto { get; set; }

    public object nItem_produto { get; set; }
  }
}
