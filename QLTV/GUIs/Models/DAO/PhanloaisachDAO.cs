using GUIs.Models.EF;
using GUIs.Models.VIEW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GUIs.Models.DAO
{
    public class PhanloaisachDAO
    {
       private dbContext context = new dbContext();
     public void InsertOrUpdate (PHANLOAISACH item )
        {
            if(item.ID==0)
            {
                context.PHANLOAISACH.Add(item);
            }
            context.SaveChanges();
        }
        public PHANLOAISACH getItem(int id)
        {
            return context.PHANLOAISACH.Where(x => x.ID == id).FirstOrDefault();
        }
        public PhanloaisachVIEW getItemView(int id)
        {
            var query = (from a in context.PHANLOAISACH
                         where a.ID==id
                         select new PhanloaisachVIEW
                         {
                             ID=a.ID,
                            TenPhanLoai=a.TenPhanLoai,
                         }
                        ).FirstOrDefault();
            return query;
        }
        public List<PhanloaisachVIEW> getList()
        {
            var query = (from a in context.PHANLOAISACH
                         select new PhanloaisachVIEW
                         {
                             ID = a.ID,
                             TenPhanLoai = a.TenPhanLoai
                         }).ToList();
            return query;
        }
        public List<PhanloaisachVIEW> Search(String ten)
        {
            var query = (from a in context.PHANLOAISACH
                         where a.TenPhanLoai.Contains(ten)
                         select new PhanloaisachVIEW
                         {
                             ID = a.ID,
                             TenPhanLoai=a.TenPhanLoai
                         }).ToList();
            return query;
        }
        public void Delete (int id)
        {
            PHANLOAISACH x = getItem(id);
            context.PHANLOAISACH.Remove(x);
            context.SaveChanges();
        }
    }
}