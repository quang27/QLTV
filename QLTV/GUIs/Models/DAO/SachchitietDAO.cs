using GUIs.Models.EF;
using GUIs.Models.VIEW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GUIs.Models.DAO
{
    public class SachchitietDAO
    {
        private dbContext context = new dbContext();
        public void InsertOrUpdate(SACHCHITIET item)
        {
            if(item.MaCT==0)
            {
                context.SACHCHITIET.Add(item);
            }
            context.SaveChanges();
        }
        public SACHCHITIET getItem(int id)
        {
            return context.SACHCHITIET.Where(x => x.MaCT == id).FirstOrDefault();
        }
        public SachchitietVIEW getItemVIEW(String  macode)
        {
            var query = (from a in context.SACHCHITIET
                         join b in context.SACH on a.MaSach equals b.ID
                         join c in context.TACGIASACH on b.ID equals c.MaSach
                         join d in context.TACGIA on c.TacgiaId equals d.ID
                         join e in context.NHAXUATBAN on b.NXBId equals e.ID
                         where String.Compare(a.MaCode, macode, true) == 0
                         select new SachchitietVIEW
                         {
                             MaCT=a.MaCT,
                             MaSach=a.MaSach,
                             Tinhtrang=a.Tinhtrang,
                             Ngay_nhap=a.Ngay_nhap,
                             NamXb=a.NamXb,
                             MaCode=a.MaCode,
                             Tensach=b.TenSach,
                             Tacgia=d.Tentacgia
                         }
                         ).FirstOrDefault();
            return query;
        }     
        public List<SachchitietVIEW> getList(int id)
        {
            var query = (from a in context.SACHCHITIET
                         join b in context.SACH on a.MaSach equals b.ID
                         join c in context.TACGIASACH on b.ID equals c.MaSach
                         join d in context.TACGIA on c.TacgiaId equals d.ID
                         join e in context.NHAXUATBAN on b.NXBId equals e.ID
                         where a.MaSach == id
                         select new SachchitietVIEW
                         {
                             MaCT = a.MaCT,
                             MaSach = a.MaSach,
                             Tinhtrang = a.Tinhtrang,
                             Ngay_nhap = a.Ngay_nhap,
                             NamXb = a.NamXb,
                             MaCode = a.MaCode,
                             Tensach = b.TenSach,
                             Tacgia = d.Tentacgia
                         }).ToList();                       
            return query;
        }
        public void Delete(int id)
        {
            SACHCHITIET x = getItem(id);
            context.SACHCHITIET.Remove(x);
            context.SaveChanges();
        }
    }
}