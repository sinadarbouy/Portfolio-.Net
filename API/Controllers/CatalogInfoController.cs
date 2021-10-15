using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CatalogInfoController : Controller
    {
        private static readonly List<CatalogItem> CatalogItem = new List<CatalogItem>
        {
            new CatalogItem (1,1,"","A",20000,"") ,
            new CatalogItem (1,1,"","B",30000,""),
            new CatalogItem (1,1,"","C",40000,"")
        };

        [HttpGet]
        public IEnumerable<CatalogItem> Get()
        {
            return CatalogItem;
        }
    }
}
