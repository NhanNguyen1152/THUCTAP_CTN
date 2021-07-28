using System;
using System.Collections.Generic;

namespace thuctap_CTN.Models
{
    public partial class Chitietlop
    {
        public string CtlId { get; set; }
        public string HvId { get; set; }
        public string LId { get; set; }

        public virtual Hocvien Hv { get; set; }
        public virtual Lop L { get; set; }
    }
}
