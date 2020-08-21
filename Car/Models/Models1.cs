using System;
using System.Collections.Generic;

namespace Car.Models
{
    public partial class Models1
    {
        public Models1()
        {
            AllAds = new HashSet<AllAds>();
        }

        public int Id { get; set; }
        public int BrandId { get; set; }
        public string Code { get; set; }
        public string ModelName { get; set; }

        public virtual ICollection<AllAds> AllAds { get; set; }
    }
}
