using CarShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarShop.Application.Models
{
    public class AddBrandModel
    {
        public string Name { get; set; }

        public virtual List<Car> Cars { get; set; }
    }
}
