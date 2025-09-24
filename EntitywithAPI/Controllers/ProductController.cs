using EntitywithAPI.Data;
using EntitywithAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EntitywithAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
       private readonly appdbcontxt _context;
        public ProductController(appdbcontxt context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Get() { 
            var products = _context.Products.ToList();
            if (products.Count==0) { 
                return NotFound();
            }
            return Ok(products);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
        [HttpPost]
        public IActionResult Post(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return CreatedAtAction("Get", new { id = product.Id }, product);
        }
        [HttpPut]
        public IActionResult Put(Product product) 
        {

           
                if (product == null)
                {
                    return BadRequest("Model data is invalid");
                }

                if (product.Id == 0)
                {
                    return BadRequest("ID is invalid");
                }
                var existingProduct = _context.Products.Find(product.Id);
            if (existingProduct == null)
                {
                   return BadRequest("failed");
                }
                existingProduct.Name = product.Name;
                existingProduct.Price = product.Price ;
                 existingProduct.Qty = product.Qty;
            _context.Products.Update(existingProduct);
            _context.SaveChanges();

                return Ok("Product updated successfully");

          

        }
        [HttpDelete]
        public IActionResult Delete(int id) {


           var pro = _context.Products.Find(id);
            if (pro == null) {
                return BadRequest("Not found");
            }
            _context.Products.Remove(pro);
            _context.SaveChanges();

            return Ok("Deleted");

        }



    }
}
