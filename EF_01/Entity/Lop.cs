using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_01.Entity
{
    public class Lop
    {
        public int LopId { get; set; }
        public string TenLop { get; set; }  
        public int SiSo {  get; set; }
        public IEnumerable<HocSinh> HocSinhs { get; set; }
    }
}
