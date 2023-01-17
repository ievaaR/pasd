using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using ddapi.Models;

namespace ddapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DeliveryController : Controller {
   List<int> idArray = new List<int>();

   [HttpGet]
   public string GetAllDeliveries() {
      return JsonConvert.SerializeObject(idArray);
   }

   [HttpGet("{id}")]
   public async Task<String> GetDelivery(string id) {
      using (var httpClient = new HttpClient()) {
         using (var request = new HttpRequestMessage(new HttpMethod("GET"), "https://pasd-webshop-api.onrender.com/api/delivery/0")) {
            request.Headers.TryAddWithoutValidation("accept", "application/json");
            request.Headers.TryAddWithoutValidation("x-api-key", "4sqmKzToVkUoTsVfze4X"); 

            var response = await httpClient.SendAsync(request);
            return await response.Content.ReadAsStringAsync();
         }
      }
   }

   [HttpPost]
   public async Task<String> PostDelivery() {
      using (var httpClient = new HttpClient()) {
         using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://pasd-webshop-api.onrender.com/api/delivery/")) {
            request.Headers.TryAddWithoutValidation("accept", "application/json");
            request.Headers.TryAddWithoutValidation("x-api-key", "4sqmKzToVkUoTsVfze4X"); 

           // request.Content = new StringContent("{\n  \"price_in_cents\": 0,\n  \"expected_delivery_datetime\": \"2023-01-16T21:02:47.309Z\",\n  \"order_id\": 0\n}");
            request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json"); 

            var response = await httpClient.SendAsync(request);
            var res = await response.Content.ReadAsStringAsync();
            var delivery = JsonConvert.DeserializeObject<Delivery>(res);
            idArray.Add(delivery.id);
            return res;
         }
      }
   }

   [HttpPatch("{id}")]
   public async Task<String> UpdateDelivery(string id) {
      using (var httpClient = new HttpClient()) {
         using (var request = new HttpRequestMessage(new HttpMethod("PATCH"), "https://pasd-webshop-api.onrender.com/api/delivery/0")) {
            request.Headers.TryAddWithoutValidation("accept", "application/json");
            request.Headers.TryAddWithoutValidation("x-api-key", "4sqmKzToVkUoTsVfze4X"); 

            //request.Content = new StringContent("{\n  \"status\": \"TRN\"\n}");
            //request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json"); 

            var response = await httpClient.SendAsync(request);
            return await response.Content.ReadAsStringAsync();
         }
      }
   }
}