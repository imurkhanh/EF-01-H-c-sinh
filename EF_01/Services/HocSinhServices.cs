using EF_01.Entity;
using EF_01.Helper;
using EF_01.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_01.Services
{
    public class HocSinhServices : IHocSinhServices
    {
        private readonly AppDbContext dbContext;
        public HocSinhServices()
        {
            dbContext = new AppDbContext();
        }
        private void CapNhapSiSo(int lopId)
        {
            var lopHienTai = dbContext.Lop.FirstOrDefault(x=>x.LopId == lopId);
            if (lopHienTai != null )
            {
                lopHienTai.SiSo = dbContext.Lop.Count(x=>x.LopId == lopHienTai.LopId);
                dbContext.Update(lopHienTai);
                dbContext.SaveChanges();
            }    
        }

        public void SuaThongTinHocSinh(HocSinh hocSinh)
        {
            if (InputHelper.KiemTraNamSinh(hocSinh.NgaySinh.Year))
            {
                Console.WriteLine("Năm sinh phải nằm trong (2001,2013)");
                return;
            }
            if (InputHelper.KiemTraDoDaiChuoi(hocSinh.HoTen, 20))
            {
                Console.WriteLine("Họ tên không được quá 20 ký tự");
                return;
            }
            if (InputHelper.KiemTraSoTu(hocSinh.HoTen, 2))
            {
                Console.WriteLine("Họ tên phải có 2 từ trở lên");
                return;
            }
            var hocSinhHienTai = dbContext.HocSinh.FirstOrDefault(x=>x.HocSinhId==hocSinh.HocSinhId);
            if(hocSinhHienTai != null)
            {
                hocSinhHienTai.HoTen = hocSinh.HoTen;
                hocSinhHienTai.NgaySinh = hocSinh.NgaySinh;
                hocSinhHienTai.QueQuan = hocSinh.QueQuan;
                dbContext.Update(hocSinhHienTai);
                dbContext.SaveChanges();
                Console.WriteLine("Cập nhập thành công");
            }
            else
            {
                Console.WriteLine("Học sinh không tồn tại");
                return;
            }
        }

        public void ThemHocSinhVaoLop(HocSinh hocSinh, int lopId)
        {
            /*if(hocSinh.NgaySinh.Year<2001 || hocSinh.NgaySinh.Year>2013)
            {
                Console.WriteLine("Nam sinh vuot qua khoang (2001,2013)");
            }*/
            if (InputHelper.KiemTraNamSinh(hocSinh.NgaySinh.Year))
            {
                Console.WriteLine("Năm sinh phải nằm trong (2001,2013)");
                return;
            }
            if (InputHelper.KiemTraDoDaiChuoi(hocSinh.HoTen, 20))
            {
                Console.WriteLine("Họ tên không được quá 20 ký tự");
                return;
            }
            if (InputHelper.KiemTraSoTu(hocSinh.HoTen, 2))
            {
                Console.WriteLine("Họ tên phải có 2 từ trở lên");
                return;
            }
            if (dbContext.HocSinh.Any(x=> x.HocSinhId == hocSinh.HocSinhId))
            {
                Console.WriteLine("Học sinh đã tồn tại");
            }
            else
            {
                if (dbContext.Lop.Any(x => x.LopId == lopId))
                {
                    var lopHienTai = dbContext.Lop.FirstOrDefault(x=>x.LopId == lopId);
                    if(lopHienTai.SiSo +1>20)
                    {
                        Console.WriteLine("Lớp đã đạt sĩ số tối đa (20)");
                    }    
                    else
                    {
                        hocSinh.LopId = lopId;
                        dbContext.HocSinh.Add(hocSinh);
                        dbContext.SaveChanges();
                        CapNhapSiSo(lopId);
                    }    
                }
                else
                {
                    Console.WriteLine("Lớp chưa tồn tại");
                }
            }    
        }

        public void XoaHocSinh(int hocSinhId)
        {
            var hocSinhHienTai = dbContext.HocSinh.FirstOrDefault(x=>x.HocSinhId == hocSinhId);
            if(hocSinhHienTai != null)
            {
                dbContext.Remove(hocSinhHienTai);
                dbContext.SaveChanges();
                CapNhapSiSo(hocSinhHienTai.LopId);
                Console.WriteLine("Xóa thành công");

                
            }    
            else
            {
                Console.WriteLine("Học sinh không tồn tại");
            }    
        }

        public void ChuyenLopChoHocSinh(int hocSinhId,int lopCuId, int lopMoiId)
        {
            if(!dbContext.Lop.Any(x=>x.LopId==lopCuId))
            {
                Console.WriteLine("Lớp cũ không tồn tại");
                return;
            }
            if (!dbContext.Lop.Any(x => x.LopId == lopMoiId))
            {
                Console.WriteLine("Lớp mới không tồn tại");
                return;
            }

            var hocSinhHienTai = dbContext.HocSinh.FirstOrDefault(x=>x.HocSinhId == hocSinhId);
            if(hocSinhHienTai!= null)
            {
                hocSinhHienTai.LopId = lopMoiId;
                dbContext.Update(hocSinhHienTai);
                dbContext.SaveChanges();
                CapNhapSiSo(lopCuId);
                CapNhapSiSo(lopMoiId);
            }
            else
            {
                Console.WriteLine("Học sinh không tồn tại");
            }    
        }
    }
}
