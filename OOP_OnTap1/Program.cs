using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_OnTap1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            QuanLyNhanVien ds = new QuanLyNhanVien();
            string fileInput = "C:\\Users\\nguyen.cao\\Desktop\\codec++\\oop\\baiTapTrenLMS\\OOP_OnTap1\\OOP_OnTap1\\bin\\Debug\\data.txt";
            ds.DocFile(fileInput);
            //ds.HienThiDanhSach();
            ds.TimNhanVienCoLuongMin().HienThiDanhSach();


        }
    }
}
