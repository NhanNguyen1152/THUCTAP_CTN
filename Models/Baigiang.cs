using System;
using System.Collections.Generic;

namespace thuctap_CTN.Models
{
    public partial class Baigiang
    {
        public Baigiang()
        {
            Chitietbaigiang = new HashSet<Chitietbaigiang>();
        }

        public string BgId { get; set; }
        public string BgTen { get; set; }
        public string BgTrangthai { get; set; }
        public string LoaiId { get; set; }
        public string BgfId { get; set; }

        public virtual Baigiangfile Bgf { get; set; }
        public virtual Loaibaigiang Loai { get; set; }
        public virtual ICollection<Chitietbaigiang> Chitietbaigiang { get; set; }
    }
}
