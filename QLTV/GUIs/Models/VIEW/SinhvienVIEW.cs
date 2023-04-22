using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GUIs.Models.VIEW
{
    public class SinhvienVIEW
    {
        public int ID { get; set; }

        public string MaSV { get; set; }

         
        public string Hoten { get; set; }
         
        public DateTime? Ngaysinh { get; set; }

        public string Password { get; set; }

        public string Username { get; set; }
    }
}