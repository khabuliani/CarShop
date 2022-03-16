using CarShop.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;
using CarShop.Domain.Models;
using System.Threading.Tasks;

namespace CarShop.Application.Services.Interfaces
{
    public interface ICarService
    {
        public Car GetCar(int Id);

        public List<Car> GetCars();

        public Task AddCar(AddCarModel carModel);

        public Task UpdateCar(UpdateCarModel carModel);

        public void DeleteCar(int Id);
    }
}
