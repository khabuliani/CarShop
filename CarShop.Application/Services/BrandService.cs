using CarShop.Application.Models;
using CarShop.Application.Services.Interfaces;
using CarShop.Domain.Models;
using CarShop.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarShop.Application.Services
{
    public class BrandService : IBrandService
    {
        private readonly CarShopDbContext _db;

        public BrandService(CarShopDbContext db)
        {
            _db = db;
        }

        public void AddBrand(AddBrandModel brandModel)
        {
            if (brandModel == null)
                throw new ArgumentNullException();

            var brand = new Brand()
            {
                Name = brandModel.Name
            };

            _db.Set<Brand>().Add(brand);
            _db.SaveChanges();
        }

        public void DeleteBrand(int id)
        {
            var brand = _db.Set<Brand>().SingleOrDefault(x => x.Id == id);

            if (brand == null)
                throw new ArgumentNullException();

            //var cars = _db.Set<Car>().Where(x => x.BrandId == id).ToList();

            //_db.Set<Car>().RemoveRange(cars);
            _db.Set<Brand>().Remove(brand);
            _db.SaveChanges();
        }

        public Brand GetBrand(int id)
        {
            var brand = _db.Set<Brand>().SingleOrDefault(x => x.Id == id);

            return brand;
        }

        public List<Brand> GetBrands()
        {
            var brands = _db.Set<Brand>().ToList();

            return brands;
        }

        public void UpdateBrand(UpdateBrandModel brandModel)
        {
            if (brandModel == null)
                throw new ArgumentNullException();

            var brand = _db.Set<Brand>().SingleOrDefault(x => x.Id == brandModel.Id);

            if (brand == null)
                throw new ArgumentNullException();

            brand.Name = brandModel.Name;

            _db.Set<Brand>().Update(brand);
            _db.SaveChanges();
        }
    }
}
