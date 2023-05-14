using GUIs.Models.EF;
using GUIs.Models.VIEW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GUIs.Models.DAO
{
    public class NhanVienDAO
    {
        private dbContext context = new dbContext();
        public void InsertOrUpdate(NHANVIEN item)
        {
            if (item.ID == 0)
            {
                context.NHANVIEN.Add(item);
            }
            context.SaveChanges();
        }
        public NHANVIEN getItem(int id)
        {
            
            return context.NHANVIEN.Where(x => x.ID == id).FirstOrDefault();
        }
        public NhanVienVIEW getItemView(int id)
        {
           
            var query = (from a in context.NHANVIEN
                         where a.ID == id
                         select new NhanVienVIEW
                         {
                             ID = a.ID,
                             TenNV = a.TenNV,
                             Email = a.Email,
                             SDT = a.SDT    
                         }).FirstOrDefault();
            return query;
        }
        public List<NhanVienVIEW> getList(String ten="")
        {
            var query = (from a in context.NHANVIEN
                         where (a.TenNV.Contains(ten))
                         select new NhanVienVIEW
                         {
                             ID = a.ID,
                             TenNV = a.TenNV,
                             Email = a.Email,
                             SDT = a.SDT
                         }).ToList();
            return query;
        }
        public void Detele(int id)
        {
            NHANVIEN x = getItem(id);
            context.NHANVIEN.Remove(x);
            context.SaveChanges();
        }
        
    }

    
}