// Decompiled with JetBrains decompiler
// Type: Relatorio_Produtos_VHSYS.Classes.Utils.RequestsUtils
// Assembly: Relatorio_Produtos_VHSYS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3740E6A2-8A63-493B-9E56-76A1104CAF61
// Assembly location: C:\Users\Aroldo Jales\Desktop\net5.0-windows\Relatorio_Produtos_VHSYS.dll

using Newtonsoft.Json;
using Relatorio_Produtos_VHSYS.Properties;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


#nullable enable
namespace Relatorio_Produtos_VHSYS.Classes.Utils
{
  public static class RequestsUtils
  {
    private static 
    #nullable disable
    HttpClient client = new HttpClient();

    static RequestsUtils()
    {
      RequestsUtils.client.BaseAddress = new Uri("https://api.vhsys.com/v2/");
      RequestsUtils.client.DefaultRequestHeaders.Add("access-token", Settings.Default.accessToken);
      RequestsUtils.client.DefaultRequestHeaders.Add("secret-access-token", Settings.Default.secretAccessToken);
      RequestsUtils.client.DefaultRequestHeaders.Add("cache-control", Settings.Default.cacheControl);
    }

    public static async Task<int> returnTotalPages(IDictionary<string, string> mapSearchParams)
    {
      string json = await (await RequestsUtils.client.SendAsync(new HttpRequestMessage(HttpMethod.Get, new Uri("https://api.vhsys.com/v2/pedidos"))
      {
        Content = (HttpContent) new StringContent(JsonConvert.SerializeObject((object) new
        {
          vendedor = mapSearchParams["vendedor"],
          nome_cliente = mapSearchParams["cliente"],
          offset = 0,
          status = mapSearchParams["status"],
          limit = 250,
          lixeira = mapSearchParams["lixeira"]
        }), Encoding.UTF8, "application/json")
      })).Content.ReadAsStringAsync();
      List<OrderFormatted> orderFormattedList = new List<OrderFormatted>();
      return System.Text.Json.JsonSerializer.Deserialize<DataOrder>(json).paging.total;
    }

    public static async Task<string> returnResponseOrders(
      IDictionary<string, string> mapSearchParams,
      int offset)
    {
      return await (await RequestsUtils.client.SendAsync(new HttpRequestMessage(HttpMethod.Get, new Uri("https://api.vhsys.com/v2/pedidos"))
      {
        Content = (HttpContent) new StringContent(JsonConvert.SerializeObject((object) new
        {
          vendedor = mapSearchParams["vendedor"],
          nome_cliente = mapSearchParams["cliente"],
          offset = offset,
          status = mapSearchParams["status"],
          limit = 250,
          lixeira = mapSearchParams["lixeira"]
        }), Encoding.UTF8, "application/json")
      })).Content.ReadAsStringAsync();
    }

    public static async Task<string> returnResponseOrder(int id) => await (await RequestsUtils.client.SendAsync(new HttpRequestMessage(HttpMethod.Get, new Uri("https://api.vhsys.com/v2/pedidos/"))
    {
      Content = (HttpContent) new StringContent(JsonConvert.SerializeObject((object) new
      {
        id_pedido = id
      }), Encoding.UTF8, "application/json")
    })).Content.ReadAsStringAsync();

    public static async Task<string> returnResponseProducts(int orderid)
    {
      string str;
      do
      {
        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, new Uri("https://api.vhsys.com/v2/pedidos/" + orderid.ToString() + "/produtos"));
        str = await (await RequestsUtils.client.SendAsync(request)).Content.ReadAsStringAsync();
      }
      while (!(str != "Too Many Attempts."));
      return str;
    }
  }
}
