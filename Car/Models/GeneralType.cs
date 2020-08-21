using System;
using System.Collections.Generic;

namespace Car.Models
{
    public partial class GeneralType
    {
        public GeneralType()
        {
            GeneralInfo = new HashSet<GeneralInfo>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<GeneralInfo> GeneralInfo { get; set; }
    }
}
