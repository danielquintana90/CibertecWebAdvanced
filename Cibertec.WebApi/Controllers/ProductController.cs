using Cibertec.Models;
using Cibertec.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace Cibertec.WebApi.Controllers
{
    [Route("product")]
    public class ProductController : BaseController
    {
        public ProductController(IUnitOfWork unit) : base(unit)
        {
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok(_unit.Products.GetAll());
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Detail(int id)
        {
            return Ok(_unit.Products.GetById(id));
        }

        [HttpPut]
        public IActionResult Update([FromBody]Product product)
        {
            return Ok(_unit.Products.Update(product));
        }

        [HttpPost]
        public IActionResult Create([FromBody]Product product)
        {
            return Ok(_unit.Products.Insert(product));
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_unit.Products.Delete(_unit.Products.GetById(id)));
        }

        [HttpGet]
        [Route("{numberPage}/{numberRecords}")]
        public IActionResult GetProductsByPagination(int numberPage, int numberRecords)
        {
            int startRow = (numberPage - 1) * numberRecords + 1;
            int endRow = numberPage * numberRecords;

            return Ok(_unit.Products.GetProductsByPagination(startRow, endRow));
        }

        [HttpGet]
        [Route("count")]
        public IActionResult GetRowNumbers()
        {
            return Ok(_unit.Products.RowNumbers());
        }

    }
}