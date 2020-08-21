using System;
using System.Collections.Generic;

namespace Car.Models
{
    public partial class GeneralInfo
    {
        public GeneralInfo()
        {
            AllAdsBodyType = new HashSet<AllAds>();
            AllAdsCity = new HashSet<AllAds>();
            AllAdsColor = new HashSet<AllAds>();
            AllAdsCurrency = new HashSet<AllAds>();
            AllAdsEngineVolume = new HashSet<AllAds>();
            AllAdsFuelType = new HashSet<AllAds>();
            AllAdsGearbox = new HashSet<AllAds>();
            AllAdsTransmission = new HashSet<AllAds>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? TypeId { get; set; }

        public virtual GeneralType Type { get; set; }
        public virtual ICollection<AllAds> AllAdsBodyType { get; set; }
        public virtual ICollection<AllAds> AllAdsCity { get; set; }
        public virtual ICollection<AllAds> AllAdsColor { get; set; }
        public virtual ICollection<AllAds> AllAdsCurrency { get; set; }
        public virtual ICollection<AllAds> AllAdsEngineVolume { get; set; }
        public virtual ICollection<AllAds> AllAdsFuelType { get; set; }
        public virtual ICollection<AllAds> AllAdsGearbox { get; set; }
        public virtual ICollection<AllAds> AllAdsTransmission { get; set; }
    }
}
