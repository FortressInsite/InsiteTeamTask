using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InsiteTeamTask.Models;
using InsiteTeamTask.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InsiteTeamTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        // GET: /<controller>/
        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            var repo = new DataRepository();

            var products = repo.GetProducts();

            return Ok(products);
        }
    }
}
