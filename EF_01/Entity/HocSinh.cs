using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_01.Entity
{
    public class HocSinh
    {
        public int HocSinhId { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public string QueQuan { get; set; }
        public int LopId { get; set; }
        public Lop Lop { get; set; }


    }
}
