using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETicaretAPI.Application.Repostories.Products;
using ETicaretAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        readonly private IProductReadRepository _productReadRepository;
        readonly private IProductWriteRepository _productWriteRepository;

        public ProductsController(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
        }

        [HttpGet]
        public async Task Get()
        {
            await _productWriteRepository.AddRangeAsync(new()
            {
                new() {Id = Guid.NewGuid(), Name= "Potato", Price = 100, Stock = 10, CreatedDate= DateTime.UtcNow},
                new() {Id = Guid.NewGuid(), Name= "Tomato", Price = 560, Stock = 20, CreatedDate= DateTime.UtcNow},
                new() {Id = Guid.NewGuid(), Name= "Pepper", Price = 450, Stock = 35, CreatedDate= DateTime.UtcNow}
            });
            await _productWriteRepository.SaveAsync();
            //tracking örneği
             //Product p = await _productReadRepository.GetByIdAsync("4bdba454-d09c-4b15-a9f9-eff9cf2a6ed6", false(bu durumda dbde değişim olmaz çünkü biz tracking metodunu iptal ediyoruz,hiçbir değer vermezsek de otomatik olarak zaten true döndüğünden işlemi yapacaktır));
            //p.Name = "Yeni ürün";
            //await _productWriteRepository.SaveAsync(); ef sayesinde aynı anda read ve write yapabliyoruz.
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            Product product = await _productReadRepository.GetByIdAsync(id);
            return Ok(product);
        }


        //// GET: api/values
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/values/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/values
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}

