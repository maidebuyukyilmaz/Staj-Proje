using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using stajProje.UI.DTOs.CategoryDtos;
using stajProje.UI.Helpers;

[Area("author")]
[Route("[area]/[controller]/[action]/{id?}")]
public class CategoryViewComponent : ViewComponent
{
    private readonly HttpClient _client;
    public CategoryViewComponent()
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

            return View("Default", categories);
        }

        return View("Error");
    }
}