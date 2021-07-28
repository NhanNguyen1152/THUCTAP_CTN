using System;
using System.Collections.Generic;

namespace thuctap_CTN.Models
{
    public partial class Chitietbaigiang
    {
        public string CtbgId { get; set; }
        public string LId { get; set; }
        public string BgId { get; set; }

        public virtual Baigiang Bg { get; set; }
        public virtual Lop L { get; set; }
    }
}
