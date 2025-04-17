using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace OOP_OnTap1
{
    public class QuanLyNhanVien
    {
        List<Nguoi> collection;

        public QuanLyNhanVien()
        {
            collection = new List<Nguoi>();
        }

        public void ThemNguoi(Nguoi nguoi)
        {
            collection.Add(nguoi);
        }

        public Nguoi NhapThongTin()
        {
            Console.WriteLine("Chọn loại đối tượng (1 - Người, 2 - Nhân viên, 3 - Quản lý): ");
            int loai = int.Parse(Console.ReadLine());
            string diaChi, ten, maNV, viTri, phong;
            int tuoi;
            decimal luong;
            Nguoi nguoi = null;
            Console.Write("Nhập tên: ");
            ten = Console.ReadLine();

            Console.Write("Nhập tuổi: ");
            tuoi = int.Parse(Console.ReadLine());

            Console.Write("Nhập địa chỉ: ");
            diaChi = Console.ReadLine();
            switch (loai)
            {
                case 1:
                    nguoi = new Nguoi() { Ten = ten, Tuoi = tuoi, DiaChi = diaChi };
                    break;
                case 2:
                    Console.Write("Nhập mã nhân viên: ");
                    maNV = Console.ReadLine();

                    Console.Write("Nhập vị trí: ");
                    viTri = Console.ReadLine();

                    Console.Write("Nhập lương: ");
                    luong = decimal.Parse(Console.ReadLine());
                    nguoi = new NhanVien() { Ten = ten, Tuoi = tuoi, DiaChi = diaChi, MaNhanVien = maNV, ViTri = viTri, Luong = luong};
                    break;
                case 3:
                    Console.Write("Nhập mã nhân viên: ");
                    maNV = Console.ReadLine();

                    Console.Write("Nhập vị trí: ");
                    viTri = Console.ReadLine();

                    Console.Write("Nhập lương: ");
                    luong = decimal.Parse(Console.ReadLine());
                    Console.Write("Nhập phòng ban: ");
                    phong = Console.ReadLine();
                    nguoi = new QuanLy() { Ten = ten, Tuoi = tuoi, DiaChi = diaChi, MaNhanVien = maNV, ViTri = viTri, Luong = luong, Phong = phong };
                    break;
                default:
                    Console.WriteLine("Lựa chọn không hợp lệ!");
                    break;
            }
            return nguoi;
           
        }
        public void HienThiDanhSach()
        {
            foreach (var item in collection)
            {
                item.HienThiThongTin();
                
                Console.WriteLine("-----------------------------------------------------\n");
            }
        }

        public void DocFile(string filename)
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine("file ko ton tai");
                return;
            }
            StreamReader sr = new StreamReader(filename);
            string s = "";
            Nguoi nguoi = null;
            while((s = sr.ReadLine())  != null)
            {
                var part = s.Split(',');

                string loai = part[0];
                string diaChi = part[1];
                string ten = part[2];
                int tuoi = int.Parse(part[3]);

                decimal luong = part.Length > 4 ? decimal.Parse(part[4]) : 0;
                string maNV = part.Length > 5 ? part[5] : "";
                string viTri = part.Length > 6 ? part[6] : "";

                switch (loai.ToLower())
                {
                    case "nguoi":
                        nguoi = new Nguoi() 
                        { 
                            Ten = ten, 
                            Tuoi = tuoi, 
                            DiaChi = diaChi 
                        };
                        break;
                    case "nhan vien":
                       
                        
                        nguoi = new NhanVien() 
                        { 
                            Ten = ten, 
                            Tuoi = tuoi, 
                            DiaChi = diaChi, 
                            MaNhanVien = maNV, 
                            ViTri = viTri, 
                            Luong = luong 
                        };
                        break;
                    case "quan ly":
                        
                        string phong = part[7];
                        nguoi = new QuanLy() 
                        { 
                            Ten = ten, 
                            Tuoi = tuoi, 
                            DiaChi = diaChi, 
                            MaNhanVien = maNV, 
                            ViTri = viTri, 
                            Luong = luong, 
                            Phong = 
                            phong 
                        };
                        break;
                }
                if(nguoi != null)
                {
                    collection.Add(nguoi);
                }
            }
            sr.Close();
        }
        public QuanLyNhanVien TimNhanVienCoLuongMax()
        {
            QuanLyNhanVien result = new QuanLyNhanVien();

            decimal maxVal = 0;

            foreach(var item in collection)
            {
                if(item is NhanVien nv && nv.Luong > maxVal)
                {
                    maxVal = nv.Luong;
                }
            }

            foreach(var item in collection)
            {
                if (item is NhanVien nv && nv.Luong == maxVal)
                {
                    result.ThemNguoi(item);
                }
            }
            return result;
        }

        public QuanLyNhanVien TimNhanVienCoLuongMin()
        {
            QuanLyNhanVien result = new QuanLyNhanVien();

            decimal minVal = decimal.MaxValue;

            foreach (var item in collection)
            {
                if (item is NhanVien nv && nv.Luong < minVal)
                {
                    minVal = nv.Luong;
                }
            }

            foreach (var item in collection)
            {
                if (item is NhanVien nv && nv.Luong == minVal)
                {
                    result.ThemNguoi(item);
                }
            }
            return result;
        }

        public QuanLyNhanVien TimTatCaQuanLyThuocPhong(string phong)
        {
            QuanLyNhanVien result = new QuanLyNhanVien();

            foreach (var item in collection)
            {
                if(item is QuanLy ql &&  string.Compare(ql.Phong, phong) == 0)
                {
                    result.ThemNguoi(item);
                }
            }

            return result;
        }

        public QuanLyNhanVien TimNhanVienCoMucLuongLonHon(decimal luong)
        {
            QuanLyNhanVien result = new QuanLyNhanVien();
            foreach (var item in collection)
            {
                if (item is NhanVien nv && nv.Luong > luong)
                {
                    result.ThemNguoi(item);
                }
            }
            return result;
        }

        public QuanLyNhanVien TimNhanVienCoMucLuongNhoHon(decimal luong)
        {
            QuanLyNhanVien result = new QuanLyNhanVien();
            foreach (var item in collection)
            {
                if (item is NhanVien nv && nv.Luong < luong)
                {
                    result.ThemNguoi(item);
                }
            }
            return result;
        }
    }
}
