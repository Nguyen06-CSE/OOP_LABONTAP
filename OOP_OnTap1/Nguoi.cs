using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_OnTap1
{
    public class Nguoi
    {
        public string DiaChi { get; set; }
        public string Ten { get; set; }
        public int Tuoi {  get; set; }

        public Nguoi() { }

        public virtual void HienThiThongTin()
        {
            Console.WriteLine($"Ten: {Ten}, Tuoi: {Tuoi}, Đia chi: {DiaChi}");
        }
    }
}
