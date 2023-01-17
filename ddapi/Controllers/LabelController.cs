using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace ddapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LabelController : Controller {
   [HttpPost("{id}")]
   public async Task<String> PostLabel(string id) {
      //using (var reader = new StreamReader(
         //Request.Body,
         //encoding: Encoding.UTF8,
         //detectEncodingFromByteOrderMarks: false
     // )) {
         //var bodyString = await reader.ReadToEndAsync();
         using (var httpClient = new HttpClient())
         {
            using (var request = new HttpRequestMessage(new HttpMethod("POST"), string.Format("https://pasd-webshop-api.onrender.com/api/label/{0}", id)))
            {
               request.Headers.TryAddWithoutValidation("accept", "application/json");
               request.Headers.TryAddWithoutValidation("x-api-key", "4sqmKzToVkUoTsVfze4X"); 

               var multipartContent = new MultipartFormDataContent();
               var file1 = new ByteArrayContent(System.IO.File.ReadAllBytes("Aangifteformulier verhuizing.pdf"));
        file1.Headers.Add("Content-Type", "application/pdf");
        multipartContent.Add(file1, "labelFile", Path.GetFileName("Aangifteformulier verhuizing.pdf"));
               request.Content = multipartContent;

               var response = await httpClient.SendAsync(request);
               return await response.Content.ReadAsStringAsync();
            }
         }
     // }
   }
}