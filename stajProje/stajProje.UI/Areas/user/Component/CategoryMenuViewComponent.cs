using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using stajProje.UI.DTOs.CategoryDtos;
using stajProje.UI.Helpers;

namespace stajProje.UI.Areas.user.Component
{
    [Area("user")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class CategoryMenuViewComponent:ViewComponent
    {
        private readonly HttpClient _client;
        public CategoryMenuViewComponent()
        {
            _client = HttpClientInstance.CreateClient(); ;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var response = await _client.GetAsync("Categories");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var categories = JsonConvert.DeserializeObject<List<CategoryDto>>(jsonData);

                return View("Default",categories );
            }

            return View("Error");
        }
    }
}
