using System.Collections.Generic;
using InsiteTeamTask.Models;
using InsiteTeamTask.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace InsiteTeamTask.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private IDataRepository _dataRepository;

		public ProductController(IDataRepository dataRepository)
		{
			this._dataRepository = dataRepository;
		}

		// GET api/values
		[HttpGet]
		public ActionResult<IEnumerable<Product>> Get()
		{
			var products = _dataRepository.GetProducts();
			return Ok(products);
		}
	}
}
