using System;
using System.Collections.Generic;

namespace thuctap_CTN.Models
{
    public partial class Hocvien
    {
        public Hocvien()
        {
            Chitietlop = new HashSet<Chitietlop>();
            Thoikhoabieu = new HashSet<Thoikhoabieu>();
        }

        public string HvId { get; set; }
        public DateTime? HvNgaysinh { get; set; }
        public string HvGioitinh { get; set; }
        public string HvDiachi { get; set; }
        public string HvSdt { get; set; }
        public string HvEmail { get; set; }
        public DateTime? HvNgayvao { get; set; }
        public string HvHinhanh { get; set; }

        public virtual ICollection<Chitietlop> Chitietlop { get; set; }
        public virtual ICollection<Thoikhoabieu> Thoikhoabieu { get; set; }
    }
}
