using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace ddapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MainController : Controller {
   [HttpGet]
   public async Task<String> GetAllOrders() {
      using (var httpClient = new HttpClient()) {

         using (var request = new HttpRequestMessage(new HttpMethod("GET"), "https://pasd-webshop-api.onrender.com/api/order/")) {

         request.Headers.TryAddWithoutValidation("accept", "application/json");
         request.Headers.TryAddWithoutValidation("x-api-key", "4sqmKzToVkUoTsVfze4X"); 

         var response = await httpClient.SendAsync(request);
         return await response.Content.ReadAsStringAsync();
         }
      }
      
   }

   public async Task<String> PostOrder() {
      using (var httpClient = new HttpClient()) {

      using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://pasd-webshop-api.onrender.com/api/delivery/")) {
         request.Headers.TryAddWithoutValidation("accept", "application/json");
         request.Headers.TryAddWithoutValidation("x-api-key", "4sqmKzToVkUoTsVfze4X"); 

         request.Content = new StringContent("{\n  \"price_in_cents\": 0,\n  \"expected_delivery_datetime\": \"2023-01-16T21:02:47.309Z\",\n  \"order_id\": 0\n}");
         request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json"); 

         var response = await httpClient.SendAsync(request);
         return await response.Content.ReadAsStringAsync();
      }
   }
   }
}