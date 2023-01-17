using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using ddapi.Models;
using System.Text;
using System.Text.Json.Nodes;
using System.Text.Json;
using ddapi.Services;

namespace ddapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DeliveryController : Controller {
   private readonly DeliveryService _deliveryService;

   public DeliveryController(DeliveryService deliveryService) =>
      _deliveryService = deliveryService;

   [HttpGet]
   public async Task<List<Delivery>> GetAllDeliveries() =>
      await _deliveryService.GetAsync();

   [HttpGet("{id}")]
   public async Task<String> GetDelivery(string id) {
      using (var httpClient = new HttpClient()) {
         using (var request = new HttpRequestMessage(new HttpMethod("GET"), string.Format("https://pasd-webshop-api.onrender.com/api/delivery/{0}", id))) {
            request.Headers.TryAddWithoutValidation("accept", "application/json");
            request.Headers.TryAddWithoutValidation("x-api-key", "4sqmKzToVkUoTsVfze4X"); 

            var response = await httpClient.SendAsync(request);
            return await response.Content.ReadAsStringAsync();
         }
      }
   }

   [HttpPost]
   public async Task<string> PostDelivery() {
      //var apiKey = "4sqmKzToVkUoTsVfze4X";
      //var apiBaseUrl = "https://pasd-webshop-api.onrender.com/";
      using (var reader = new StreamReader(
         Request.Body,
         encoding: Encoding.UTF8,
         detectEncodingFromByteOrderMarks: false
      )) {
         var bodyString = await reader.ReadToEndAsync();
         using (var httpClient = new HttpClient()) {
            using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://pasd-webshop-api.onrender.com/api/delivery/")) {
               request.Headers.TryAddWithoutValidation("accept", "application/json");
               request.Headers.TryAddWithoutValidation("x-api-key", "4sqmKzToVkUoTsVfze4X"); 

               request.Content = new StringContent(bodyString);
               request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json"); 

               var response = await httpClient.SendAsync(request);
               var res = await response.Content.ReadAsStringAsync();
               //var delivery = JsonConvert.DeserializeObject<Delivery>(res);
               //idArray.Add(delivery.id);
               dynamic tmp = JsonConvert.DeserializeObject(res);
               var value = tmp.id;
               Delivery del = new Delivery();
               del._Id = (int)value;
               await _deliveryService.CreateAsync(del);
               return res;
            }
         }
      }
   }

   [HttpPatch("{id}")]
   public async Task<String> UpdateDelivery(string id) 
   {
      using (var reader = new StreamReader(
         Request.Body,
         encoding: Encoding.UTF8,
         detectEncodingFromByteOrderMarks: false
      )) {
         var bodyString = await reader.ReadToEndAsync();
         using (var httpClient = new HttpClient()) {
            using (var request = new HttpRequestMessage(new HttpMethod("PATCH"), string.Format("https://pasd-webshop-api.onrender.com/api/delivery/{0}",id))) {
               request.Headers.TryAddWithoutValidation("accept", "application/json");
               request.Headers.TryAddWithoutValidation("x-api-key", "4sqmKzToVkUoTsVfze4X"); 

               request.Content = new StringContent("bodyString");
               request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json"); 

               var response = await httpClient.SendAsync(request);
               return await response.Content.ReadAsStringAsync();
            }
         }
      }
   }
}