using System;
using System.Collections.Generic;

namespace thuctap_CTN.Models
{
    public partial class Thoikhoabieu
    {
        public string TkbId { get; set; }
        public string LId { get; set; }
        public string HvId { get; set; }
        public string TkbMonhoc { get; set; }
        public string TkbKhunggio { get; set; }
        public DateTime? TkbNgay { get; set; }
        public string TkbLinkhoc { get; set; }

        public virtual Hocvien Hv { get; set; }
        public virtual Lop L { get; set; }
    }
}
