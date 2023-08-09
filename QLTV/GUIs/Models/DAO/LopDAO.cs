using GUIs.Models.EF;
using GUIs.Models.VIEW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GUIs.Models.DAO
{
    public class LopDAO
    {
        private dbContext context = new dbContext();
        public void InsertOrUpdate(LOP item)
        {
            if (item.ID == 0)
            {
                context.LOP.Add(item);
            }
            context.SaveChanges();
        }
        public LOP getItem(int id)
        {

            return context.LOP.Where(x => x.ID == id).FirstOrDefault();
        }
        public LopVIEW getItemView(int id)
        {

            var query = (from a in context.LOP
                         where a.ID == id
                         select new LopVIEW
                         {
                             Id=a.ID,
                             Tenlop=a.TenLop               
                         }).FirstOrDefault();
            return query;
        }
       
        public List<LopVIEW> getList() {
            var query = (from a in context.LOP
                         select new LopVIEW
                         {
                             Id = a.ID,
                             Tenlop=a.TenLop
                         }
                             ).ToList();
            return query;
        }
        public List<LopVIEW> Search(String ten, out int total, int index = 1, int size = 10)
        {
            var query = (from a in context.LOP
                         where (a.TenLop.Contains(a.TenLop))
                         select new LopVIEW
                         {
                             Id = a.ID,
                             Tenlop = a.TenLop
                         }).Skip((index-1)*size).Take(size).ToList();
            total = query.Count();
            return query;
        }
        public void Detele(int id)
        {
            LOP x = getItem(id);
            context.LOP.Remove(x);
            context.SaveChanges();
        }
    }
}
