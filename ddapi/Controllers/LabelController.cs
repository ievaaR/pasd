using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace ddapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LabelController : Controller {
   [HttpPost]
   public async Task<String> PostLabel() {
      using (var httpClient = new HttpClient())
      {
         using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://pasd-webshop-api.onrender.com/api/label?delivery_id=0"))
         {
            request.Headers.TryAddWithoutValidation("accept", "application/json");
            request.Headers.TryAddWithoutValidation("x-api-key", "4sqmKzToVkUoTsVfze4X"); 

            var multipartContent = new MultipartFormDataContent();
            var file1 = new ByteArrayContent(System.IO.File.ReadAllBytes("anime-anime-girls-white-hair-long-hair-wallpaper-preview.jpg"));
            file1.Headers.Add("Content-Type", "image/jpeg");
            multipartContent.Add(file1, "labelFile", Path.GetFileName("anime-anime-girls-white-hair-long-hair-wallpaper-preview.jpg"));
            request.Content = multipartContent; 

            var response = await httpClient.SendAsync(request);
            return await response.Content.ReadAsStringAsync();
         }
      }
   }
}