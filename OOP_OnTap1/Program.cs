using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace OOP_OnTap1
{
    internal class Program
    {
        public enum ThucDon
        {
            NhapThongTinMotNhanVien = 1,
            NhapDanhSachTuFile,
            Xuat,
            TimNhanVienCoLuongMax,
            TimNhanVienCoLuongMin,
            TimNhanVienCoMucLuongNhoHon,
            TImNhanVienCoMucLuongLonHon,
            TimTatCaQuanLyThuocPhong,
            XoaQuanLyCuaPhongNaoDo,
            SapDanhSachViTriTang,
            SapDanhSachViTriGiam,
            ChuanHoaTen,
            SapXepDanhSachTheoTen,
            Thoat
        }

        static void Main(string[] args)
        {
            QuanLyNhanVien ds = new QuanLyNhanVien();
            //ds.DocFile(fileInput);
            ////ds.HienThiDanhSach();
            ////ds.TimNhanVienCoLuongMin().HienThiDanhSach();
            //var item = ds.XoaQuanLyCuaPhongNaoDo("Marketing");
            //item = ds.XoaQuanLyCuaPhongNaoDo("Nghien Cuu");
            //item = ds.XoaQuanLyCuaPhongNaoDo("He Thong");
            //foreach(var i in item)
            //{
            //    i.HienThiThongTin();
            //    Console.WriteLine();
            //}
            //Console.WriteLine(item.Count);


            while (true)
            {
                Nguoi nguoi1 = new Nguoi();
                string fileInput;
                Console.Clear();
                Console.WriteLine("chon chuc nang ");
                foreach (var i in Enum.GetValues(typeof(ThucDon)))
                {
                    Console.WriteLine($"{(int)i}. {i}");
                }

                Console.Write("nhap lua chon: ");
                ThucDon chon = (ThucDon)int.Parse(Console.ReadLine());

                switch (chon)
                {
                    case ThucDon.NhapThongTinMotNhanVien:
                        nguoi1 = ds.NhapThongTin();
                        ds.ThemNguoi(nguoi1);
                        break;
                    case ThucDon.NhapDanhSachTuFile:  // Case 2
                        fileInput = "C:\\Users\\nguyen.cao\\Desktop\\codec++\\oop\\baiTapTrenLMS\\OOP_OnTap1\\OOP_OnTap1\\bin\\Debug\\data.txt";

                        ds.DocFile(fileInput);
                        break;

                    case ThucDon.Xuat:  // Case 3
                        ds.HienThiDanhSach();
                        break;

                    case ThucDon.TimNhanVienCoLuongMax:  // Case 4
                        QuanLyNhanVien dsMax = ds.TimNhanVienCoLuongMax();
                        dsMax.HienThiDanhSach();
                        break;

                    case ThucDon.TimNhanVienCoLuongMin:  // Case 5
                        QuanLyNhanVien dsMin = ds.TimNhanVienCoLuongMin();
                        dsMin.HienThiDanhSach();
                        break;

                    case ThucDon.TimNhanVienCoMucLuongNhoHon:  // Case 6
                        Console.Write("Nhập mức lương: ");
                        decimal luongLonHon = decimal.Parse(Console.ReadLine());
                        QuanLyNhanVien dsLonHon = ds.TimNhanVienCoMucLuongNhoHon(luongLonHon);
                        dsLonHon.HienThiDanhSach();
                        break;
                        
           
                    case ThucDon.TImNhanVienCoMucLuongLonHon:  // Case 7
                        Console.Write("Nhập mức lương: ");
                        decimal luongNhoHon = decimal.Parse(Console.ReadLine());
                        QuanLyNhanVien dsNhoHon = ds.TimNhanVienCoMucLuongNhoHon(luongNhoHon);
                        dsNhoHon.HienThiDanhSach();
                        break;
                        
                    case ThucDon.TimTatCaQuanLyThuocPhong:  // Case 8
                        Console.Write("Nhập tên phòng: ");
                        string tenPhong = Console.ReadLine();
                        QuanLyNhanVien dsQL = ds.TimTatCaQuanLyThuocPhong(tenPhong);
                        dsQL.HienThiDanhSach();
                        break;
                        
            
           
                    case ThucDon.XoaQuanLyCuaPhongNaoDo:  // Case 9
                        Console.Write("Nhập tên phòng: ");
                        string phongCanXoa = Console.ReadLine();
                        List<Nguoi> dsSauKhiXoa = ds.XoaQuanLyCuaPhongNaoDo(phongCanXoa);
                        // Xử lý hiển thị danh sách sau khi xóa
                        break;

                    case ThucDon.SapDanhSachViTriTang:  // Case 10
                        ds.SapDanhSachViTriTang();
                        Console.WriteLine("Đã sắp xếp tăng dần");
                        break;
            
                    case ThucDon.SapDanhSachViTriGiam:  // Case 11
                        ds.SapDanhSachViTriGiam();
                        Console.WriteLine("Đã sắp xếp giảm dần");
                        break;

                    case ThucDon.ChuanHoaTen:  // Case 12
                        ds.ChuanHoaDanhSachTen();
                        Console.WriteLine("Đã chuẩn hóa tên");
                        break;

                    case ThucDon.SapXepDanhSachTheoTen:  // Case 13
                        ds.SapXepTheoTen();
                        Console.WriteLine("Đã sắp xếp theo tên");
                        break;

                    case ThucDon.Thoat:  // Case 14
                        Console.WriteLine("Kết thúc chương trình");
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ");
                        break;
                }
                Console.ReadLine();
            }
            
        }
    }
}
