using CarShop.Application.Models;
using CarShop.Application.Services.Interfaces;
using CarShop.Models.BrandModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarShop.Controllers
{
    [Route("api/brand")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly ICarService _carService;
        private readonly IBrandService _brandService;

        public BrandController(ICarService carService, IBrandService brandService)
        {
            _carService = carService;
            _brandService = brandService;
        }

        [HttpGet("{id}")]
        public IActionResult GetBrand([FromRoute]int id)
        {
            var brand = _brandService.GetBrand(id);
            var brandModel = new GetBrand()
            {
                Id = brand.Id,
                Name = brand.Name
            };

            return Ok(brandModel);
        }

        [HttpGet]
        public IActionResult GetBrands()
        {
            var brands = _brandService.GetBrands();

            return Ok(brands);
        }

        [HttpPost("add")]
        public IActionResult AddBrand([FromBody] AddBrand brand)
        {
            var brandModel = new AddBrandModel()
            {
                Name = brand.Name
            };

            _brandService.AddBrand(brandModel);

            return CreatedAtAction(nameof(GetBrands),brandModel);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBrand([FromRoute]int id)
        {
            _brandService.DeleteBrand(id);

            return NoContent();
        }

        [HttpPost("update")]
        public IActionResult UpdateBrand([FromBody]UpdateBrand updateBrand)
        {
            var brand = _brandService.GetBrand(updateBrand.Id);

            if (brand == null)
                return NotFound();

            var brandModel = new UpdateBrandModel()
            {
                Id= brand.Id,
                Name= updateBrand.Name
            };

            _brandService.UpdateBrand(brandModel);

            return Ok(brandModel);
        }
    }
}
