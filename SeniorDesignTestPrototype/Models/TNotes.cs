using System;
using System.Collections.Generic;

namespace SeniorDesignTestPrototype.Models
{
    public partial class TNotes
    {
        public int INoteId { get; set; }
        public int IPrototypeId { get; set; }
        public string VcNote { get; set; }

        public virtual TPrototype IPrototype { get; set; }
    }
}
