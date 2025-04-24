using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_OnTap1
{
    public class NhanVien : Nguoi
    {
        public decimal Luong { get; set; }
        public string MaNhanVien { get; set; }
        public string ViTri {  get; set; }

        public NhanVien() { }

        public NhanVien(string diaChi, string ten, int tuoi, decimal luong, string maNhanVien, string viTri)
            : base(diaChi, ten, tuoi)
        {
            Luong = luong;
            MaNhanVien = maNhanVien;
            ViTri = viTri;
        }


        public override void HienThiThongTin()
        {
            base.HienThiThongTin();
            Console.WriteLine($"Ma NV: {MaNhanVien}, Vi tri: {ViTri}, Luong: {Luong}");
        }
    }
}
