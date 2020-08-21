using System;
using System.Collections.Generic;

namespace Car.Models
{
    public partial class Brands
    {
        public Brands()
        {
            AllAds = new HashSet<AllAds>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string BrandName { get; set; }

        public virtual ICollection<AllAds> AllAds { get; set; }
    }
}
