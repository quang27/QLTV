using GUIs.Models.EF;
using GUIs.Models.VIEW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GUIs.Models.DAO
{
    public class SachDAO
    {
        private dbContext context = new dbContext();
        public void InsertOrUpdate(SACH item)
        {
            if (item.ID == 0)
            {
                context.SACH.Add(item);
            }
            context.SaveChanges();
        }
        public SACH getItem(int id)
        {
            //Entity framework
            return context.SACH.Where(x => x.ID == id).FirstOrDefault();
        }
        public SachVIEW getItemView(int id)
        {
            //LinQ
            var query = (from a in context.SACH
                         join b in context.NHAXUATBAN on a.NXBId equals b.ID
                         join c in context.PHANLOAISACH on a.PhanLoaiId equals c.ID
                         where a.ID == id
                         select new SachVIEW
                         {
                             ID = a.ID,
                             TenSach=a.TenSach,
                             TenNxb=b.TenNXB,
                             Phanloai=c.TenPhanLoai,
                             GiaTien=a.GiaTien,
                            AnhBia=a.AnhBia,
                            Tomtat=a.Tomtat,
                            Noi_dung=a.Noi_dung   
                         }).FirstOrDefault();
            return query;
        }
        public List<SachVIEW> getList(String tensach,String phanloai)
        {
            var query = (from a in context.SACH
                         join b in context.NHAXUATBAN on a.NXBId equals b.ID
                         join c in context.PHANLOAISACH on a.PhanLoaiId equals c.ID 
                         //where(a.TenSach.Contains(tensach) &&c.TenPhanLoai.Contains(phanloai))
                         
                         select new SachVIEW
                         {
                             ID = a.ID,
                             TenSach = a.TenSach,
                             TenNxb = b.TenNXB,
                             Phanloai = c.TenPhanLoai,
                             GiaTien = a.GiaTien,
                             AnhBia = a.AnhBia,
                             Tomtat = a.Tomtat,
                             Noi_dung = a.Noi_dung
                         }).ToList();
            if (tensach != "")
            {
                query = query.Where(x => x.TenSach.Contains(tensach)).ToList();
            }
            if(phanloai!="")
            {
                query = query.Where(x => x.Phanloai.Contains(phanloai)).ToList();
            }
            return query;
        }
        public List<SachVIEW> getList(String tensach, int phanloaiid=0,int nhaxbid=0)
        {
            var query = (from a in context.SACH
                         join b in context.NHAXUATBAN on a.NXBId equals b.ID
                         join c in context.PHANLOAISACH on a.PhanLoaiId equals c.ID
                         //where(a.TenSach.Contains(tensach) &&c.TenPhanLoai.Contains(phanloai))

                         select new SachVIEW
                         {
                             ID = a.ID,
                             TenSach = a.TenSach,
                             TenNxb = b.TenNXB,
                             Phanloai = c.TenPhanLoai,
                             GiaTien = a.GiaTien,
                             AnhBia = a.AnhBia,
                             Tomtat = a.Tomtat,
                             Noi_dung = a.Noi_dung,
                             PhanLoaiId = a.PhanLoaiId,
                             NXBId=a.NXBId
                             
                         }).ToList();
            if (tensach != "")
            {
                query = query.Where(x => x.TenSach.Contains(tensach)).ToList();
            }
            if (phanloaiid != 0)
            {
                query = query.Where(x => x.PhanLoaiId == phanloaiid ).ToList();
            }
            if(nhaxbid!=0)
            {
                query = query.Where(x => x.NXBId == nhaxbid).ToList();
            }
            return query;
        }
        public void Detele(int id)
        {
            SACH x = getItem(id);
            context.SACH.Remove(x);
            context.SaveChanges();
        }
    }
}