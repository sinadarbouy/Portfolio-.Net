using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Services;
using Web.ViewModels;

namespace Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private CatalogViewModelService _client;

        public IndexModel(ILogger<IndexModel> logger,[FromServices] CatalogViewModelService client)
        {
            _logger = logger;
            _client = client;
        }
        public CatalogViewModel CatalogModel { get; set; } = new CatalogViewModel() { catalogItems=new List<CatalogItemViewModel>() { } };


        public async Task OnGetAsync()
        {
            CatalogModel = await _client.GetCatalogItemsasync();

        }
    }
}
