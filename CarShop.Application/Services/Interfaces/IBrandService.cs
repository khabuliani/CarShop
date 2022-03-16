using CarShop.Application.Models;
using CarShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarShop.Application.Services.Interfaces
{
    public interface IBrandService
    {
        public Brand GetBrand(int Id);

        public List<Brand> GetBrands();

        public void AddBrand(AddBrandModel brandModel);

        public void UpdateBrand(UpdateBrandModel brandModel);

        public void DeleteBrand(int Id);
    }
}
