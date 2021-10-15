using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Web.Interfaces;
using Web.ViewModels;

namespace Web.Services
{
    public class CatalogViewModelService  : ICatalogViewModelService
    {
        private readonly JsonSerializerOptions options = new JsonSerializerOptions()
        {
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        };

        private readonly HttpClient client;


        public CatalogViewModelService(HttpClient client )
        {
            this.client = client;

        }

        public async Task<CatalogViewModel> GetCatalogItemsasync()
        {
            CatalogViewModel catalog = new CatalogViewModel();
            try
            {
                var responseMessage = await this.client.GetAsync("/CatalogInfo");

                if (responseMessage != null)
                {
                    var stream = await responseMessage.Content.ReadAsStreamAsync();
                    catalog.catalogItems= await JsonSerializer.DeserializeAsync<List<CatalogItemViewModel>>(stream, options);
                    return  catalog;
                }
            }
            catch (HttpRequestException ex)
            {
                 throw;
            }
            return catalog;

        }

        
    }
}
