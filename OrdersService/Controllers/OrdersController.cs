using Microsoft.AspNetCore.Mvc;

namespace OrdersService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        [HttpGet("{productId}")]
        public async Task<IActionResult> Get(string productId)
        {
            var client = new HttpClient();
            var response = await client.GetAsync(
                $"http://inventory-service:8080/api/inventory/{productId}");
            var content = await response.Content.ReadAsStringAsync();
            return Content(content);
        }
    }
}