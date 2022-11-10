// Decompiled with JetBrains decompiler
// Type: Relatorio_Produtos_VHSYS.Classes.OrderFormatted
// Assembly: Relatorio_Produtos_VHSYS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3740E6A2-8A63-493B-9E56-76A1104CAF61
// Assembly location: C:\Users\Aroldo Jales\Desktop\net5.0-windows\Relatorio_Produtos_VHSYS.dll

using System;

namespace Relatorio_Produtos_VHSYS.Classes
{
  internal class OrderFormatted
  {
    public OrderFormatted(
      int id_ped,
      int id_pedido,
      int id_cliente,
      string nome_cliente,
      string vendedor_pedido,
      int? vendedor_pedido_id,
      DateTime data_pedido,
      DateTime data_cad_pedido,
      DateTime data_mod_pedido,
      string status_pedido,
      string lixeira)
    {
      this.id_ped = id_ped;
      this.id_pedido = id_pedido;
      this.id_cliente = id_cliente;
      this.nome_cliente = nome_cliente;
      this.vendedor_pedido = vendedor_pedido;
      this.vendedor_pedido_id = vendedor_pedido_id;
      this.data_pedido = data_pedido;
      this.data_cad_pedido = data_cad_pedido;
      this.data_mod_pedido = data_mod_pedido;
      this.status_pedido = status_pedido;
      this.lixeira = lixeira;
    }

    public int id_ped { get; set; }

    public int id_pedido { get; set; }

    public int id_cliente { get; set; }

    public string nome_cliente { get; set; }

    public string vendedor_pedido { get; set; }

    public int? vendedor_pedido_id { get; set; }

    public DateTime data_pedido { get; set; }

    public DateTime data_cad_pedido { get; set; }

    public DateTime data_mod_pedido { get; set; }

    public string status_pedido { get; set; }

    public string lixeira { get; set; }
  }
}
