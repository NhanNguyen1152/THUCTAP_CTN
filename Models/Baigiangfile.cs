using System;
using System.Collections.Generic;

namespace thuctap_CTN.Models
{
    public partial class Baigiangfile
    {
        public Baigiangfile()
        {
            Baigiang = new HashSet<Baigiang>();
        }

        public string BgfId { get; set; }
        public string BgfTen { get; set; }
        public string BgfFile { get; set; }

        public virtual ICollection<Baigiang> Baigiang { get; set; }
    }
}
