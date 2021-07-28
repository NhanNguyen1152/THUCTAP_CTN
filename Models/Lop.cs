using System;
using System.Collections.Generic;

namespace thuctap_CTN.Models
{
    public partial class Lop
    {
        public Lop()
        {
            Chitietbaigiang = new HashSet<Chitietbaigiang>();
            Chitietlop = new HashSet<Chitietlop>();
            Thoikhoabieu = new HashSet<Thoikhoabieu>();
        }

        public string LId { get; set; }
        public string LTen { get; set; }
        public string LMota { get; set; }
        public string LKhoa { get; set; }
        public DateTime? LNgaybatdau { get; set; }
        public DateTime? LNgayketthuc { get; set; }
        public string LTrangthai { get; set; }

        public virtual ICollection<Chitietbaigiang> Chitietbaigiang { get; set; }
        public virtual ICollection<Chitietlop> Chitietlop { get; set; }
        public virtual ICollection<Thoikhoabieu> Thoikhoabieu { get; set; }
    }
}
