using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GUIs.Models.VIEW
{
    public class SachVIEW
    {
        public int ID { get; set; }
        public string TenSach { get; set; }
        public int? NXBId { get; set; }
        public int? PhanLoaiId { get; set; }
        public int? GiaTien { get; set; }
        public string AnhBia { get; set; }
        public string Tomtat { get; set; }
        public string Noi_dung { get; set; }
        public string TenNxb { set; get; }
        public string Phanloai { set; get; }
    }
}