﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Car.Models
{
    public class CardGeneralModel
    {
        public List<AllAds> AllAdss { get; set; }
        public AllAds Alladss { get; set; }

        public int? BrandId { get; set; }
        [Required]
        public int? FuelTypeId { get; set; }
        [Required]
        public int? TransmissionId { get; set; }
        [Required]
        public int? BodyTypeId { get; set; }
        [Required]
        public int? GearboxId { get; set; }
        [Required]
        public int? ColorId { get; set; }
        [Required]
        public int? Walk { get; set; }
        [Required]
        public int? EngineVolumeId { get; set; }
        public string Note { get; set; }
        public bool AlloyWheels { get; set; }
        public bool Usa { get; set; }
        public bool Luke { get; set; }
        public bool RainSensor { get; set; }
        public bool CentralClosure { get; set; }
        public bool ParkingRadar { get; set; }
        public bool Conditioner { get; set; }

        public bool SeatHeating { get; set; }
        public bool LeatherSalon { get; set; }
        public bool Xenon { get; set; }
        public bool RearCamera { get; set; }
        public bool SideCurtains { get; set; }
        public bool SeatVentilation { get; set; }
        [Required(ErrorMessage = "Is required")]
        public string Name { get; set; }
        [Required]
        public string Contact { get; set; }
        [Required]
        public int? ModelId { get; set; }
        [Required]       
        public int? Price { get; set; }
        [Required]
        public int? CurrencyId { get; set; }
        public string Currency { get; set; }
        public bool Credit { get; set; }
        public bool Barter { get; set; }
        [Required]
        public int? FounderYear { get; set; }
        [Required]
        public int? CityId { get; set; }
        [Required]
        public int? minPrice { get; set; }
        [Required]
        public int? maxPrice { get; set; }
        [Required]
        public int? minYear { get; set; }
        [Required]
        public int? maxYear { get; set; }
        [Required]
        public int? minWalk { get; set; }
        [Required]
        public int? maxWalk { get; set; }
        [Required]
       
        public int? VolumeId { get; set; }
        public string Image { get; internal set; }
        public string ModelName { get; internal set; }
        public string BrandName { get; internal set; }
    }
}
