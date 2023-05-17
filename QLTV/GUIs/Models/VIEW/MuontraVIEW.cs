using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GUIs.Models.VIEW
{
    public class MuontraVIEW
    {
        public int ID { get; set; }

        public int? SVId { get; set; }
        public string HotenSv { set; get; } //set - trang thai cua thuoc tinh la cho phep ghi

        public int? SachCTId { get; set; }
        public string Tensach { set; get; }

        public DateTime? NgayMuon { get; set; }

        public DateTime? NgayTra { get; set; }

         
        public string TinhTrangMuon { get; set; }

         
        public string TinhTrangTra { get; set; }

        public int? NVMuonId { get; set; }
        public string Nhanvienchomuon { set; get; }

        public int? NVTraId { get; set; }
        public string Nhanviennhantra { set; get; }
        public bool? Baomat { get; set; }
    }
}