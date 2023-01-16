using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace ddapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MainController : Controller {
   [HttpGet]
   public async Task<String> GetAllOrders() {
      var apiKey = "4sqmKzToVkUoTsVfze4X";
      var apiBaseUrl = "https://pasd-webshop-api.onrender.com/";

      string response = null!;
      HttpClient client = new();
      client.BaseAddress = new Uri(apiBaseUrl);
      client.DefaultRequestHeaders.Accept.Clear();
      client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
      client.DefaultRequestHeaders.Add("x-api-key", apiKey);
      
      HttpResponseMessage res = await client.GetAsync("https://pasd-webshop-api.onrender.com/api/order/");
      response = await res.Content.ReadAsStringAsync();
      return response;
   }
}