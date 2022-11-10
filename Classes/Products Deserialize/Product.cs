// Decompiled with JetBrains decompiler
// Type: Relatorio_Produtos_VHSYS.Classes.Products_Deserialize.Product
// Assembly: Relatorio_Produtos_VHSYS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3740E6A2-8A63-493B-9E56-76A1104CAF61
// Assembly location: C:\Users\Aroldo Jales\Desktop\net5.0-windows\Relatorio_Produtos_VHSYS.dll

namespace Relatorio_Produtos_VHSYS.Classes.Products_Deserialize
{
  internal class Product
  {
    public Product(
      int id_ped_produto,
      int id_pedido,
      int id_produto,
      int? id_almoxarifado,
      int? id_lote,

      string desc_produto,
      string qtde_produto,
      string desconto_produto,
      string ipi_produto,
      string icms_produto,
      string valor_unit_produto,
      string valor_custo_produto,
      string valor_total_produto,
      string valor_desconto,
      string peso_produto,
      string peso_liq_produto,

      string? info_adicional,
      string? xPed_produto,
      string? nItem_produto)
    {
      this.id_ped_produto = id_ped_produto;
      this.id_pedido = id_pedido;
      this.id_produto = id_produto;
      this.id_almoxarifado = id_almoxarifado;
      this.id_lote = id_lote;
      this.desc_produto = desc_produto;
      this.qtde_produto = qtde_produto;
      this.desconto_produto = desconto_produto;
      this.ipi_produto = ipi_produto;
      this.icms_produto = icms_produto;
      this.valor_unit_produto = valor_unit_produto;
      this.valor_custo_produto = valor_custo_produto;
      this.valor_total_produto = valor_total_produto;
      this.valor_desconto = valor_desconto;
      this.peso_produto = peso_produto;
      this.peso_liq_produto = peso_liq_produto;
      this.info_adicional = info_adicional;
      this.xPed_produto = xPed_produto;
      this.nItem_produto = nItem_produto;
    }

    public int id_ped_produto { get; set; }

    public int id_pedido { get; set; }

    public int id_produto { get; set; }

    public int? id_almoxarifado { get; set; }

    public int? id_lote { get; set; }

    public 
    #nullable disable
    string desc_produto { get; set; }

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

    public string? info_adicional { get; set; }

    public string? xPed_produto { get; set; }

    public string? nItem_produto { get; set; }
  }
}
