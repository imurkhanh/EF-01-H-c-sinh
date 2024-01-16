using EF_01.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_01.IServices
{
    public interface IHocSinhServices
    {
        void ThemHocSinhVaoLop(HocSinh hocSinh, int lopId);
        void SuaThongTinHocSinh(HocSinh hocSinh);
        void XoaHocSinh(int hocSinhId);
        void ChuyenLopChoHocSinh(int hocSinhId,int lopCuId, int lopMoiId);
    }
}
