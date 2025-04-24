using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThucHanh_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DanhSachAnPham ds = new DanhSachAnPham();
            string file = "C:\\Users\\nguyen.cao\\Desktop\\codec++\\oop\\baiTapTrenLMS\\OOP_OnTap1\\ThucHanh@\\bin\\Debug\\data.txt";
            ds.DocFile(file);
            //ds.HienThiDanhSach();
            ds.SachCoNamLonNhat().HienThiDanhSach();
            ds.TapChiCoNamLonNhat().HienThiDanhSach();
        }
    }
}
