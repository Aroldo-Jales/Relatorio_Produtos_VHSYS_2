// Decompiled with JetBrains decompiler
// Type: Relatorio_Produtos_VHSYS.Classes.Utils.ReturnLists
// Assembly: Relatorio_Produtos_VHSYS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3740E6A2-8A63-493B-9E56-76A1104CAF61
// Assembly location: C:\Users\Aroldo Jales\Desktop\net5.0-windows\Relatorio_Produtos_VHSYS.dll

using Relatorio_Produtos_VHSYS.Classes.Products_Deserialize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Relatorio_Produtos_VHSYS.Classes.Utils
{
  internal static class ReturnLists
  {
    public static async 

    Task<List<OrderFormatted>> returnOrdersList(
      IDictionary<string, string> mapSearchParams,
      IDictionary<string, DateTime> searchDates)
    {
      loadingForm loadingf = new loadingForm("Carregando Pedidos...");
      loadingf.Show();
      List<OrderFormatted> listData = new List<OrderFormatted>();
      int totalPages = await RequestsUtils.returnTotalPages(mapSearchParams);
      bool stopflag = false;
      int tolerance = 20;
      int lastPage = totalPages;
      try
      {
        for (int i = totalPages - 1; i < totalPages; --i)
        {
          if (!stopflag)
          {
            loadingf.labelPage_ChangeText("Verificando página: " + i.ToString() + " de " + totalPages.ToString());
            foreach (Order order in JsonSerializer.Deserialize<DataOrder>(await RequestsUtils.returnResponseOrders(mapSearchParams, i)).data)
            {
              Order data = order;
              DateTime dateTime1 = Convert.ToDateTime(data.data_pedido);
              DateTime dateTime2 = Convert.ToDateTime(data.data_cad_pedido);
              DateTime dateTime3 = Convert.ToDateTime(data.data_mod_pedido);
              if (dateTime2 >= searchDates["initial"] && dateTime2 <= searchDates["final"])
              {
                if (!listData.Any<OrderFormatted>((Func<OrderFormatted, bool>) (it => it.id_pedido == data.id_pedido)))
                {
                  listData.Add(new OrderFormatted(data.id_ped, data.id_pedido, data.id_cliente, data.nome_cliente, data.vendedor_pedido, new int?(data.vendedor_pedido_id), dateTime1, dateTime2, dateTime3, data.status_pedido, data.lixeira));
                  lastPage = i;
                  loadingf.labelCount_ChangeText(listData.Count.ToString());
                }
                else
                  continue;
              }
              if (dateTime2 < searchDates["initial"] && i == lastPage - tolerance)
              {
                stopflag = true;
                break;
              }
            }
          }
          else
          {
            loadingf.Close();
            return listData;
          }
        }
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message, "Erro ao carregar lista de pedidos", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
      loadingf.Close();
      return listData;
    }

    public static async Task<List<OrderFormatted>> returnOrdersListByRangeOrder(
      IDictionary<string, string> mapSearchParams,
      List<int> orders_ids)
    {
      loadingForm loadingf = new loadingForm("Carregando Pedidos...");
      loadingf.Show();
      List<OrderFormatted> listData = new List<OrderFormatted>();
      try
      {
        int index;
        for (int i = 0; i < orders_ids.Count; index = i++)
        {
          int num = i + 1;
          loadingForm loadingForm = loadingf;
          string[] strArray = new string[6]
          {
            "Verificando pedido: ",
            num.ToString(),
            " de ",
            null,
            null,
            null
          };
          index = orders_ids.Count;
          strArray[3] = index.ToString();
          strArray[4] = " | ID = ";
          index = orders_ids[i];
          strArray[5] = index.ToString();
          string text = string.Concat(strArray);
          loadingForm.labelPage_ChangeText(text);
          Order[] data = JsonSerializer.Deserialize<DataOrder>(await RequestsUtils.returnResponseOrder(orders_ids[i])).data;
          for (index = 0; index < data.Length; ++index)
          {
            Order order = data[index];
            listData.Add(new OrderFormatted(order.id_ped, order.id_pedido, order.id_cliente, order.nome_cliente, order.vendedor_pedido, new int?(order.vendedor_pedido_id), DateTime.Now, DateTime.Now, DateTime.Now, order.status_pedido, order.lixeira));
            loadingf.labelCount_ChangeText(listData.Count.ToString());
          }
          string vendedor = mapSearchParams["vendedor"];
          string nome_cliente = mapSearchParams["cliente"];
          string status = mapSearchParams["status"];
          string lixeira = mapSearchParams["lixeira"];
          if (vendedor != "")
            listData.RemoveAll((Predicate<OrderFormatted>) (of => of.vendedor_pedido != vendedor));
          else if (nome_cliente != "")
            listData.RemoveAll((Predicate<OrderFormatted>) (of => of.nome_cliente != nome_cliente));
          else if (status != "")
            listData.RemoveAll((Predicate<OrderFormatted>) (of => of.status_pedido != status));
          else if (lixeira != "")
            listData.RemoveAll((Predicate<OrderFormatted>) (of => of.lixeira != lixeira));
        }
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message, "Erro ao carregar lista de pedidos 2", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
      loadingf.Close();
      List<OrderFormatted> orderFormattedList = listData;
      loadingf = (loadingForm) null;
      listData = (List<OrderFormatted>) null;
      return orderFormattedList;
    }

    public static async Task<List<Product>> returnProductsList(
      List<OrderFormatted> ordersList)
    {
      List<Product> listData = new List<Product>();
      loadingForm loadingf = new loadingForm("Carregando Produtos...");
      loadingf.Show();
      try
      {
        foreach (OrderFormatted orders in ordersList)
        {
          foreach (Product product in JsonSerializer.Deserialize<DataProduct>(await RequestsUtils.returnResponseProducts(orders.id_ped)).data)
          {
            listData.Add(product);
            loadingf.labelCount_ChangeText(listData.Count.ToString());
          }
        }
        loadingf.Close();
        return listData;
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message, "Erro ao carregar lista de produtos", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
      loadingf.Close();
      return listData;
    }
  }
}
