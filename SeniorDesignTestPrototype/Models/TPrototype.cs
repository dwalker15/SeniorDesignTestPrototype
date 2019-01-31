using System;
using System.Collections.Generic;

namespace SeniorDesignTestPrototype.Models
{
    public partial class TPrototype
    {
        public TPrototype()
        {
            TNotes = new HashSet<TNotes>();
        }

        public int IPrototypeId { get; set; }
        public string VcTorqueType { get; set; }
        public string VcPosture { get; set; }
        public string VcDataCollection { get; set; }
        public int IStudyYear { get; set; }

        public virtual ICollection<TNotes> TNotes { get; set; }
    }
}
