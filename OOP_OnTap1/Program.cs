using System;
using System.Collections.Generic;
using System.Linq;
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



            Thoat
        }

        static void Main(string[] args)
        {
            QuanLyNhanVien ds = new QuanLyNhanVien();
            string fileInput = "C:\\Users\\nguyen.cao\\Desktop\\codec++\\oop\\baiTapTrenLMS\\OOP_OnTap1\\OOP_OnTap1\\bin\\Debug\\data.txt";
            ds.DocFile(fileInput);
            //ds.HienThiDanhSach();
            //ds.TimNhanVienCoLuongMin().HienThiDanhSach();
            var item = ds.XoaQuanLyCuaPhongNaoDo("Marketing");
            item = ds.XoaQuanLyCuaPhongNaoDo("Nghien Cuu");
            item = ds.XoaQuanLyCuaPhongNaoDo("He Thong");
            foreach(var i in item)
            {
                i.HienThiThongTin();
                Console.WriteLine();
            }
            Console.WriteLine(item.Count);

        }
    }
}
