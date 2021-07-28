using System;
using System.Collections.Generic;

namespace thuctap_CTN.Models
{
    public partial class Loaibaigiang
    {
        public Loaibaigiang()
        {
            Baigiang = new HashSet<Baigiang>();
        }

        public string LoaiId { get; set; }
        public string LoaiTen { get; set; }

        public virtual ICollection<Baigiang> Baigiang { get; set; }
    }
}
