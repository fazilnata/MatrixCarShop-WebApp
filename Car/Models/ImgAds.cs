using System;
using System.Collections.Generic;

namespace Car.Models
{
    public partial class ImgAds
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public int? AdsId { get; set; }

        public virtual AllAds Ads { get; set; }
    }
}
