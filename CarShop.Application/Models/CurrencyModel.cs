using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarShop.Application.Models
{
    public class CurrencyModel
    {
        [JsonProperty("EUR_GEL")]
        public double EUR_GEL { get; set; }

        [JsonProperty("USD_GEL")]
        public double USD_GEL { get; set; }
    }
}
