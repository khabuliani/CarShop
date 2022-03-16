using CarShop.Application.Models;
using CarShop.Application.Services;
using CarShop.Application.Services.Interfaces;
using CarShop.Domain.Models;
using CarShop.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Net;

namespace CarShop.Controllers
{
    [Route("api/car")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;
        private readonly IBrandService _brandService;
        private string _basePath;

        public CarController(ICarService carService, IBrandService brandService,
            IWebHostEnvironment hostingEnvironment)
        {
            _carService = carService;
            _brandService = brandService;
            _basePath = hostingEnvironment.WebRootPath + "/Images";
        }

        private string SaveImage(IFormFile picture, string oldFileName = null)
        {
            if (!System.IO.File.Exists(_basePath))
            {
                Directory.CreateDirectory(_basePath);
            }

            if (!string.IsNullOrEmpty(oldFileName))
            {
                System.IO.File.Delete(oldFileName);
            }

            using MemoryStream memoryStream = new MemoryStream();
            picture.OpenReadStream().CopyTo(memoryStream);

            var guid = Guid.NewGuid();
            var fileName = $"{guid}{Path.GetExtension(picture.FileName)}";
            var url = $"{_basePath}/{fileName}";

            using var fileStream = System.IO.File.Create(url);

            memoryStream.Seek(0, SeekOrigin.Begin);
            memoryStream.CopyTo(fileStream);

            return url;
        }

        [HttpGet("{id}")]
        public IActionResult GetCar([FromRoute] int id)
        {
            var car = _carService.GetCar(id);

            if (car == null)
                return NotFound();

            GetCar carModel = new GetCar()
            {
                Id = car.Id,
                BrandId = car.BrandId,
                ValuteId = car.ValuteId,
                BrandName = car.Brand.Name,
                Age = car.Age,
                Price = car.Price,
                Description = car.Description,
                Picture = car.Picture,
                ABS = car.ABS,
                ElectricGlassOpener = car.ElectricGlassOpener,
                Hatch = car.Hatch,
                Bluetooth = car.Bluetooth,
                Alarms = car.Alarms,
                ParkingControl = car.ParkingControl,
                Navigation = car.Navigation,
                OnBoardComputer = car.OnBoardComputer,
                MultiSteering = car.MultiSteering
            };

            return Ok(carModel);
        }

        [HttpGet]
        public IActionResult GetCars()
        {
            var cars = _carService.GetCars();

            var getCarsList = cars.Select(x => new GetCar()
            {
                Id = x.Id,
                BrandId = x.BrandId,
                BrandName = x.Brand.Name,
                ValuteId = x.ValuteId,
                Age = x.Age,
                Picture = x.Picture,
                Price = x.Price,
                Description = x.Description,
                ABS = x.ABS,
                ElectricGlassOpener = x.ElectricGlassOpener,
                Hatch = x.Hatch,
                Bluetooth = x.Bluetooth,
                Alarms = x.Alarms,
                ParkingControl = x.ParkingControl,
                Navigation = x.Navigation,
                OnBoardComputer = x.OnBoardComputer,
                MultiSteering = x.MultiSteering
            }).ToList();

            return Ok(getCarsList);
        }

        [HttpPost("add")]
        public IActionResult AddCar([FromBody] AddCar car, [FromForm] IFormFile picture)
        {
            var url = string.Empty;

            if (picture != null)
                url = SaveImage(picture);

            var addCarModel = new AddCarModel()
            {
                BrandId = car.BrandId,
                ValuteId = car.ValuteId,
                Age = car.Age,
                Picture = url,
                Price = car.Price,
                Description = car.Description,
                ABS = car.ABS,
                ElectricGlassOpener = car.ElectricGlassOpener,
                Hatch = car.Hatch,
                Bluetooth = car.Bluetooth,
                Alarms = car.Alarms,
                ParkingControl = car.ParkingControl,
                Navigation = car.Navigation,
                OnBoardComputer = car.OnBoardComputer,
                MultiSteering = car.MultiSteering
            };

            _carService.AddCar(addCarModel);

            return CreatedAtAction(nameof(GetCars), addCarModel);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCar([FromRoute] int id)
        {
            _carService.DeleteCar(id);

            return NoContent();
        }

        [HttpPost("update")]
        public IActionResult UpdateCar([FromBody] UpdateCar carModel, [FromForm] IFormFile picture)
        {
            var url = string.Empty;

            var car = _carService.GetCar(carModel.Id);

            if (car == null)
                return NotFound();

            if (picture != null)
                url = SaveImage(picture, car.Picture);

            var updateCarModel = new UpdateCarModel()
            {
                Id = carModel.Id,
                BrandId = carModel.BrandId,
                ValuteId = carModel.ValuteId,
                Age = carModel.Age,
                Price = carModel.Price,
                Description = carModel.Description,
                Picture = url,
                ABS = carModel.ABS,
                ElectricGlassOpener = carModel.ElectricGlassOpener,
                Hatch = carModel.Hatch,
                Bluetooth = carModel.Bluetooth,
                Alarms = carModel.Alarms,
                ParkingControl = carModel.ParkingControl,
                Navigation = carModel.Navigation,
                OnBoardComputer = carModel.OnBoardComputer,
                MultiSteering = carModel.MultiSteering
            };


            _carService.UpdateCar(updateCarModel);

            return RedirectToAction(nameof(GetCar), new { id = carModel.Id });
        }
    }
}
