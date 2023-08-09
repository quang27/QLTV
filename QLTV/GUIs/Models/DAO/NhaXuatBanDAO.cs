using GUIs.Models.EF;
using GUIs.Models.VIEW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GUIs.Models.DAO
{
    public class NhaXuatBanDAO
    {
        private dbContext context = new dbContext();
        public void InsertOrUpdate(NHAXUATBAN item)
        {
            if (item.ID == 0)
            {
                context.NHAXUATBAN.Add(item);
            }
            context.SaveChanges();
        }
        public NHAXUATBAN getItem(int id)
        {
            
            return context.NHAXUATBAN.Where(x => x.ID == id).FirstOrDefault();
        }
        public NhaXuatBanVIEW getItemView(int id)
        {
           
            var query = (from a in context.NHAXUATBAN
                         where a.ID == id
                         select new NhaXuatBanVIEW
                         {
                             ID = a.ID,
                             TenNXB=a.TenNXB,
                             DiaChi=a.DiaChi
                         }).FirstOrDefault();
            return query;
        }
        public List<NhaXuatBanVIEW> getList()
        {
            var query = (from a in context.NHAXUATBAN
                        
                         select new NhaXuatBanVIEW
                         {
                             ID = a.ID,
                             TenNXB = a.TenNXB,
                             DiaChi = a.DiaChi
                         }).ToList();
            return query;
        }
       
        public List<NhaXuatBanVIEW> Search(String tenNXB,out int total,int index=1,int size=10)
        {
            var query = (from a in context.NHAXUATBAN
                         where (a.TenNXB.Contains(tenNXB))
                         select new NhaXuatBanVIEW
                         {
                             ID = a.ID,
                             TenNXB = a.TenNXB,
                             DiaChi = a.DiaChi
                         }).ToList();
            total = query.Count;

            var  result = query.Skip((index - 1) * size).Take(size).ToList();

            return result;
        }
        public void Delete(int id)
        {
            NHAXUATBAN x = getItem(id);
            context.NHAXUATBAN.Remove(x);
            context.SaveChanges();
        }
    }
}