using CarShop.Domain.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarShop.Models.BrandModels
{
    public class UpdateBrand
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}

