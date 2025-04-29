using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThucHanh_
{
    public class DanhSachAnPham
    {
        List<AnPham> collection;

        public DanhSachAnPham()
        {
            collection = new List<AnPham>();
        }

        public void ThemAnPham(AnPham ap)
        {
            collection.Add(ap);
        }

        public AnPham NhapThuCong()
        {
            AnPham result = null;
            Console.WriteLine("Nhap the loai an pham:\n (1) Tap Chi\n (2) Sach");
            int loai = int.Parse(Console.ReadLine());

            string tuaDe, nhaXuatBan, ISBN, tacGia;
            int nam, so, tap;

            Console.Write("nhap nam san xuat: ");
            nam = int.Parse(Console.ReadLine());

            Console.Write("nhap nha xuat ban: ");
            nhaXuatBan = Console.ReadLine();

            Console.Write("nhap tua de: ");
            tuaDe = Console.ReadLine();

            switch (loai)
            {
                case 1:
                    Console.Write("nhap so tap chi: ");
                    so = int.Parse(Console.ReadLine());

                    Console.Write("nhap tap cua tap chi: ");
                    tap = int.Parse(Console.ReadLine());

                    result = new TapChi { Nam = nam, NhaXuatBan = nhaXuatBan, TuaDe = tuaDe, So = so, Tap = tap };
                    break;

                case 2:
                    Console.Write("Nhap ISBN: ");
                    ISBN = Console.ReadLine();

                    Console.WriteLine("Nhap tac gia: ");
                    tacGia = Console.ReadLine();

                    result = new Sach { Nam = nam, NhaXuatBan = nhaXuatBan, TuaDe = tuaDe, ISBN = ISBN , TacGia = tacGia};
                    break;
                default:
                    Console.WriteLine("lua chon ko hop le");
                    break;
            }


            return result;
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
            AnPham anPham = null;
            while ((s = sr.ReadLine()) != null)
            {
                var part = s.Split(',');

                string loai = part[0];
                int nam = int.Parse(part[1]);
                string nhaXuatBan = part[2];
                string tuaDe = part[3];

                int so, tap;
                string ISBN, tacGia;

                switch (loai)
                {
                    case "TapChi":
                        so = int.Parse(part[4]);
                        tap = int.Parse(part[5]);
                        anPham = new TapChi()
                        {
                           Nam = nam,
                           NhaXuatBan = nhaXuatBan,
                           TuaDe = tuaDe,
                           So = so,
                           Tap = tap,
                        };
                        break;
                    case "Sach":
                        ISBN = part[4];
                        tacGia = part[5];

                        anPham = new Sach()
                        {
                            Nam = nam,
                            NhaXuatBan = nhaXuatBan,
                            TuaDe = tuaDe,
                            ISBN = ISBN,
                            TacGia = tacGia,
                        };
                        break;
                                   }
                if (anPham != null)
                {
                    collection.Add(anPham);
                }
            }
            sr.Close();
        }

        public int FindMax(List<AnPham> anPhamList)
        {
            int max = 0;
            foreach(var item  in anPhamList)
            {
                if(item.Nam > max)
                {
                    max = item.Nam;
                }
            }
            return max;
        }

        public int FindMin(List<AnPham> anPhamList)
        {
            int min = int.MaxValue;
            foreach (var item in anPhamList)
            {
                if (item.Nam < min)
                {
                    min = item.Nam;
                }
            }
            return min;
        }

        public DanhSachAnPham AnPhamCoNamNhoNhat()
        {
            DanhSachAnPham result = new DanhSachAnPham();
            int min = FindMin(collection);
            foreach(var item in collection)
            {
                if(item.Nam ==  min)
                {
                    result.ThemAnPham(item);
                }
            }
            return result;
        }

        public DanhSachAnPham AnPhamCoNamLonNhat()
        {
            DanhSachAnPham result = new DanhSachAnPham();
            int max = FindMax(collection);
            foreach (var item in collection)
            {
                if (item.Nam == max)
                {
                    result.ThemAnPham(item);
                }
            }
            return result;
        }

      


        public DanhSachAnPham TimAnhPhamCoChungNhaXuatBan(string nhaXuatBan)
        {
            DanhSachAnPham result = new DanhSachAnPham();
            foreach(var item in collection)
            {
                if(string.Compare(item.NhaXuatBan, nhaXuatBan) == 0)
                {
                    result.ThemAnPham(item);
                }
            }

            return result;
        }

        public DanhSachAnPham TimAnhPhamCoChungNamXuatBan(int nam)
        {
            DanhSachAnPham result = new DanhSachAnPham();
            foreach (var item in collection)
            {
                if (item.Nam == nam)
                {
                    result.ThemAnPham(item);
                }
            }

            return result;
        }

            public DanhSachAnPham TimAnhPhamCoChungTuaDe(string tuaDe)
            {
                DanhSachAnPham result = new DanhSachAnPham();
                foreach (var item in collection)
                {
                    if (string.Compare(item.TuaDe, tuaDe) == 0)
                    {
                        result.ThemAnPham(item);
                    }
                }

                return result;
            }

        public DanhSachAnPham TimCacAnPhamLaTapChi()
        {
            DanhSachAnPham result = new DanhSachAnPham();
            foreach (var item in collection)
            {
                if (item is TapChi)
                {
                    result.ThemAnPham(item);
                }
            }

            return result;
        }

        public DanhSachAnPham TapChiCoNamNhoNhat()
        {
            DanhSachAnPham result = new DanhSachAnPham();
            var tapChiList = TimCacAnPhamLaTapChi().collection;
            int min = FindMin(tapChiList);
            foreach (var item in tapChiList)
            {
                if (item.Nam == min)
                {
                    result.ThemAnPham(item);
                }
            }
            return result;
        }

        public DanhSachAnPham TapChiCoNamLonNhat()
        {
            DanhSachAnPham result = new DanhSachAnPham();
            var tapChiList = TimCacAnPhamLaTapChi().collection;
            int max = FindMax(tapChiList);
            foreach (var item in tapChiList)
            {
                if (item.Nam == max)
                {
                    result.ThemAnPham(item);
                }
            }
            return result;
        }


        public DanhSachAnPham TimCacAnPhamLaSach()
        {
            DanhSachAnPham result = new DanhSachAnPham();
            foreach (var item in collection)
            {
                if (item is Sach)
                {
                    result.ThemAnPham(item);
                }
            }

            return result;
        }

        public DanhSachAnPham SachCoNamNhoNhat()
        {
            DanhSachAnPham result = new DanhSachAnPham();
            var sachList = TimCacAnPhamLaSach().collection;
            int min = FindMin(sachList);
            foreach (var item in sachList)
            {
                if (item.Nam == min)
                {
                    result.ThemAnPham(item);
                }
            }
            return result;
        }

        public DanhSachAnPham SachCoNamLonNhat()
        {
            DanhSachAnPham result = new DanhSachAnPham();
            var sachList = TimCacAnPhamLaSach().collection;
            int max = FindMax(sachList);

            foreach (var item in sachList)
            {
                if (item.Nam == max)
                {
                    result.ThemAnPham(item);
                }
            }

            return result;
        }

        public void XoaCacAnPhamCoNam(int nam)
        {
            foreach(var item in collection)
            {
                if(item.Nam == nam)
                {
                    collection.Remove(item);
                }
            }
        }

        public void XoaCacAnPhamChungNhaXuatBan(string nhaXuatBan)
        {
            foreach (var item in collection)
            {
                if (string.Compare(item.NhaXuatBan, nhaXuatBan) == 0)
                {
                    collection.Remove(item);
                }
            }
        }

       
    }
}
