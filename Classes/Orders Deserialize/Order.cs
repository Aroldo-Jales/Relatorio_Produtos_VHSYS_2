// Decompiled with JetBrains decompiler
// Type: Relatorio_Produtos_VHSYS.Classes.Order
// Assembly: Relatorio_Produtos_VHSYS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3740E6A2-8A63-493B-9E56-76A1104CAF61
// Assembly location: C:\Users\Aroldo Jales\Desktop\net5.0-windows\Relatorio_Produtos_VHSYS.dll

namespace Relatorio_Produtos_VHSYS.Classes
{
  internal class Order
  {
    public int id_ped { get; set; }

    public int id_pedido { get; set; }

    public int id_cliente { get; set; }

    public string nome_cliente { get; set; }

    public int? id_local_retirada { get; set; }

    public int? id_local_cobranca { get; set; }

    public string vendedor_pedido { get; set; }

    public int vendedor_pedido_id { get; set; }

    public string valor_total_produtos { get; set; }

    public string desconto_pedido { get; set; }

    public string peso_total_nota { get; set; }

    public string peso_total_nota_liq { get; set; }

    public string frete_pedido { get; set; }

    public string valor_total_nota { get; set; }

    public string valor_baseICMS { get; set; }

    public string valor_ICMS { get; set; }

    public string valor_baseST { get; set; }

    public string valor_ST { get; set; }

    public string valor_IPI { get; set; }

    public string transportadora_pedido { get; set; }

    public int? id_transportadora { get; set; }

    public string data_pedido { get; set; }

    public string prazo_entrega { get; set; }

    public string referencia_pedido { get; set; }

    public string obs_pedido { get; set; }

    public string obs_interno_pedido { get; set; }

    public string status_pedido { get; set; }

    public int? contas_pedido { get; set; }

    public int? comissao_pedido { get; set; }

    public int? estoque_pedido { get; set; }

    public int? ordemc_emitido { get; set; }

    public string data_cad_pedido { get; set; }

    public string data_mod_pedido { get; set; }

    public string lixeira { get; set; }
  }
}
