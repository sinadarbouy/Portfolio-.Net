using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Web.Pages;
using Web.Services;
using Xunit;

namespace UnitTests.Pages
{
    public class IndexTests
    {
        [Fact]
        public async Task OnGetAsync() {



            var c = new CatalogViewModelService(new HttpClient() { BaseAddress = new Uri("https://localhost:44340") });
            var pageModel = new IndexModel(null,c);
            await pageModel.OnGetAsync();
            var b = pageModel.CatalogModel.catalogItems.Count();

            var actualMessages = 3;
            Assert.Equal(
                b,
                actualMessages);

        }
    }
}
