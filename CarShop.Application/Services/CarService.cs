using CarShop.Application.Models;
using CarShop.Application.Services.Interfaces;
using CarShop.Domain.Models;
using CarShop.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CarShop.Application.Services
{
    public class CarService : ICarService
    {
        private readonly CarShopDbContext _db;
        private readonly IHttpClientFactory _httpClientFactory;

        public CarService(CarShopDbContext db, IHttpClientFactory httpClientFactory)
        {
            _db = db;
            _httpClientFactory = httpClientFactory;
        }

        private async Task CalculatePrice(Car car, string valuteName, double price)
        {
            if (!valuteName.Equals("GEL"))
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://free.currconv.com/api/v7/convert?q=" + valuteName + "_GEL&compact=ultra&apiKey=888d06b72cb500c87adc");
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        var content = await reader.ReadToEndAsync();
                        var currencyModel = JsonSerializer.Deserialize<CurrencyModel>(content);

                        if (valuteName.Equals("EUR"))
                        {
                            car.Price = currencyModel.EUR_GEL * price;
                        }
                        else if (valuteName.Equals("USD"))
                        {
                            car.Price = currencyModel.USD_GEL * price;
                        }
                    }
                }
            }
        }

        public async Task AddCar(AddCarModel carModel)
        {
            if (carModel == null)
                throw new ArgumentNullException();

            var valute = _db.Set<Valute>().SingleOrDefault(x => x.Id == carModel.ValuteId);
            var valuteName = valute.Name;

            Car car = new Car()
            {
                BrandId = carModel.BrandId,
                ValuteId = carModel.ValuteId,
                Age = carModel.Age,
                Description = carModel.Description,
                Picture = carModel.Picture,
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

            await CalculatePrice(car, valuteName, carModel.Price);

            _db.Set<Car>().Add(car);
            _db.SaveChanges();
        }

        public void DeleteCar(int id)
        {
            var car = _db.Set<Car>().SingleOrDefault(x => x.Id == id);

            if (car == null)
                throw new ArgumentNullException();

            _db.Set<Car>().Remove(car);
            _db.SaveChanges();
        }

        public Car GetCar(int id)
        {
            var car = _db.Set<Car>().SingleOrDefault(x => x.Id == id);

            return car;
        }

        public List<Car> GetCars()
        {
            var cars = _db.Set<Car>().ToList();

            return cars;
        }

        public async Task UpdateCar(UpdateCarModel carModel)
        {
            if (carModel == null)
                throw new ArgumentNullException();

            var valute = _db.Set<Valute>().SingleOrDefault(x => x.Id == carModel.ValuteId);
            var valuteName = valute.Name;

            var car = _db.Set<Car>().SingleOrDefault(x => x.Id == carModel.Id);

            await CalculatePrice(car, valuteName, carModel.Price);

            car.BrandId = carModel.BrandId;
            car.ValuteId = carModel.ValuteId;
            car.Age = carModel.Age;
            car.Description = carModel.Description;
            car.Picture = carModel.Picture;
            car.ABS = carModel.ABS;
            car.ElectricGlassOpener = carModel.ElectricGlassOpener;
            car.Hatch = carModel.Hatch;
            car.Bluetooth = carModel.Bluetooth;
            car.Alarms = carModel.Alarms;
            car.ParkingControl = carModel.ParkingControl;
            car.Navigation = carModel.Navigation;
            car.OnBoardComputer = carModel.OnBoardComputer;
            car.MultiSteering = carModel.MultiSteering;

            _db.Set<Car>().Update(car);
            _db.SaveChanges();
        }
    }
}
