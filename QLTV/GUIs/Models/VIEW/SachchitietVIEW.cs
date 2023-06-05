using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GUIs.Models.VIEW
{
    public class SachchitietVIEW
    {
        public int MaCT { get; set; }
        public int MaSach { get; set; }
        public string Tinhtrang { get; set; }
        public DateTime? Ngay_nhap { get; set; }
        public int? NamXb { get; set; }
        public string MaCode { get; set; }
        public string Tensach { set; get; }
        public string Tacgia { set; get; }
    }
}