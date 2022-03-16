using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using CarShop.Domain.Models;

namespace CarShop.Application.Models
{
    public class AddCarModel
    {
        public List<Brand> Brand { get; set; }

        public int BrandId { get; set; }

        public int ValuteId { get; set; }

        public int Age { get; set; }

        public double Price { get; set; }

        public string Description { get; set; }

        public string Picture { get; set; }

        public bool ABS { get; set; }

        public bool ElectricGlassOpener { get; set; }

        public bool Hatch { get; set; }

        public bool Bluetooth { get; set; }

        public bool Alarms { get; set; }

        public bool ParkingControl { get; set; }

        public bool Navigation { get; set; }

        public bool OnBoardComputer { get; set; }

        public bool MultiSteering { get; set; }
    }
}
