using EF_01.Entity;
using EF_01.IServices;
using EF_01.Services;

void Main()
{
    Console.OutputEncoding = System.Text.Encoding.UTF8;
    Console.InputEncoding = System.Text.Encoding.UTF8;
    IHocSinhServices hocSinhServices = new HocSinhServices();

    Console.WriteLine("----------------Quản Lý Học Sinh (EF-01)----------------");
    Console.WriteLine("1.Thêm học sinh vào lớp đã tồn tại");
    Console.WriteLine("2.Sửa thông tin học sinh");
    Console.WriteLine("3.Xóa học sinh");
    Console.WriteLine("4.Chuyển lớp cho học sinh sang lớp mới");
    Console.WriteLine("5.Thoát chương trình");
    Console.WriteLine("Chọn chức năng (1-5):");

    string choice;
    do
    {
        Console.WriteLine();
        Console.Write("Nhập lựa chọn (1-5): ");
        choice = Console.ReadLine();
        switch (choice)
        {
            case "1":
                Console.Write("Họ tên: ");
                string hoTen = Console.ReadLine();
                Console.Write("Ngày sinh: ");
                DateTime ngaySinh = DateTime.Parse(Console.ReadLine());
                Console.Write("Quê quán: ");
                string queQuan = Console.ReadLine();
                Console.Write("Lớp ID: ");
                int lopId = int.Parse(Console.ReadLine());
                var hocSinh = new HocSinh
                {
                    HoTen = hoTen,
                    NgaySinh = ngaySinh,
                    QueQuan = queQuan,
                    LopId = lopId,
                };
                hocSinhServices.ThemHocSinhVaoLop(hocSinh,lopId);
                break;
            case "2":
                Console.Write("Nhập học sinh ID của sinh viên cần sửa: ");
                int hocSinhId = int.Parse(Console.ReadLine());
                Console.Write("Họ tên mới: ");
                string hoTenMoi = Console.ReadLine();
                Console.Write("Ngày sinh mới: ");
                DateTime ngaySinhMoi = DateTime.Parse(Console.ReadLine());
                Console.Write("Quê quán mới: ");
                string queQuanMoi = Console.ReadLine();
                var hocSinhMoi = new HocSinh
                {
                    HoTen = hoTenMoi,
                    NgaySinh = ngaySinhMoi,
                    QueQuan = queQuanMoi,
                };
                hocSinhServices.SuaThongTinHocSinh(hocSinhMoi);
                break;
            case "3":
                Console.Write("Nhập học sinh ID cần xóa: ");
                int hocSinhIdDelete = int.Parse(Console.ReadLine());
                hocSinhServices.XoaHocSinh(hocSinhIdDelete);
                break;
            case "4":
                Console.Write("Nhập học sinh ID cần chuyển lớp: ");
                int hocSinhIdChuyen = int.Parse(Console.ReadLine());
                Console.Write("Nhập lớp cũ ID: ");
                int lopCuId = int.Parse(Console.ReadLine());
                Console.Write("Nhập lớp mới ID: ");
                int lopMoiId = int.Parse(Console.ReadLine());
                hocSinhServices.ChuyenLopChoHocSinh(hocSinhIdChuyen, lopCuId,lopMoiId);
                break;
            case "5":
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Lựa chọn không hợp lệ.Vui lòng nhập lại");
                break;
        }

    } while (choice != "5");

}
Main();