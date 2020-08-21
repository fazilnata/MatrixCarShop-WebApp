using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Car.Models
{
    public partial class AllAds
    {
        public string Image;
        public string ModelName;
        public string BrandName;

        public AllAds()
        {
            ImgAds = new HashSet<ImgAds>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "Model seçilməlidir")]
        public int? ModelId { get; set; }
        [Required(ErrorMessage = "Ban növü seçilməlidir")]
        public int? BodyTypeId { get; set; }
        [Required(ErrorMessage = "Yürüş yazılmalıdır")]
        public int? Walk { get; set; }
        [Required(ErrorMessage = "Rəng seçilməlidir")]
        public int? ColorId { get; set; }
        [Required(ErrorMessage = "Qiymət yazılmalıdır")]
        public int? Price { get; set; }
        [Required(ErrorMessage = "Valyuta yazılmalıdır")]

        public int? CurrencyId { get; set; }

        public bool Credit { get; set; }
        public bool Barter { get; set; }  
        [Required(ErrorMessage = "Yanacaq növü seçilməlidir")]
        public int? FuelTypeId { get; set; }
       [Required(ErrorMessage = "Ötürücü seçilməlidir")]
        public int? TransmissionId { get; set; }
        [Required(ErrorMessage = "Sürət qutusu  seçilməlidir")]
        public int? GearboxId { get; set; }
        [Required(ErrorMessage = "İl seçilməlidir")]
        public int? FounderYear { get; set; }
        [Required(ErrorMessage = "Mühərrikin həcmi seçilməlidir")]
        public int? EngineVolumeId { get; set; }
        [Required(ErrorMessage = "Mühərrikin gücü seçilməlidir")]
        public int? Hp { get; set; }
        public string Note { get; set; }
        [Required(ErrorMessage = "Avtomobil haqqında qısa məlumat yazılmalıdır")]
        public bool AlloyWheels { get; set; }
        public bool CentralClosure { get; set; }
        public bool LeatherSalon { get; set; }
        public bool SeatVentilation { get; set; }
        public bool Usa { get; set; }
        public bool ParkingRadar { get; set; }
        public bool Xenon { get; set; }
        public bool Luke { get; set; }
        public bool Conditioner { get; set; }
        public bool RearCamera { get; set; }
        public bool RainSensor { get; set; }
        public bool SeatHeating { get; set; }
        public bool SideCurtains { get; set; }
        [Required(ErrorMessage = "Ad yazılmalıdır")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Şəhər seçilməlidir")]
        public int CityId { get; set; }
        [Required(ErrorMessage = "Əlaqə nömrəsi yazılmalıdır")]
        public string Contact { get; set; }
        public int? BrandId { get; set; }

        public virtual GeneralInfo BodyType { get; set; }
        public virtual Brands Brand { get; set; }
        public virtual GeneralInfo City { get; set; }
        public virtual GeneralInfo Color { get; set; }
        public virtual GeneralInfo Currency { get; set; }
        public virtual GeneralInfo EngineVolume { get; set; }
        public virtual GeneralInfo FuelType { get; set; }
        public virtual GeneralInfo Gearbox { get; set; }
        public virtual Models1 Model { get; set; }
        public virtual GeneralInfo Transmission { get; set; }
    
        public virtual ICollection<ImgAds> ImgAds { get; set; }

       
    }
}
