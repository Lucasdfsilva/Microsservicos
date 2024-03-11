using GeekShoppingAPI.Data.ValueObject;
using GeekShoppingAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace GeekShoppingAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var product = await _productRepository.FindById(id);

            if (product == null) return NotFound();

            return Ok(product);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductVO>>> List()
        {
            IEnumerable<ProductVO> product = await _productRepository.FindAll();

            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<ProductVO>> Post(ProductVO productVO)
        {
            if (productVO == null) return BadRequest();

            var product = await _productRepository.Create(productVO);

            return Ok(product);
        }

        [HttpPut]
        public async Task<ActionResult<ProductVO>> Put(ProductVO productVO)
        {
            if (productVO == null) return BadRequest();

            var product = await _productRepository.Update(productVO);

            return Ok(product);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(long id)
        {
            bool product = await _productRepository.Delete(id);

            if (!product) return BadRequest();

            return Ok(product);
        }
    }
}
