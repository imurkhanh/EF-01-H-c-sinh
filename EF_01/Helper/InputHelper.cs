using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_01.Helper
{
    public class InputHelper
    {
        public static bool KiemTraDoDaiChuoi(string chuoi, int maxLength)
        {
            return chuoi.Length > maxLength;
        }
        public static bool KiemTraSoTu(string chuoi, int min)
        {
            return chuoi.Split(' ').Length < min;
        }
        public static bool KiemTraNamSinh(int namSinh)
        {
            return (namSinh < 2001 || namSinh >2013);
        }
    }
}
