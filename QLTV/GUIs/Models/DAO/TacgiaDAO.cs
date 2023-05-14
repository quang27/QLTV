using GUIs.Models.EF;
using GUIs.Models.VIEW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GUIs.Models.DAO
{
    public class TacgiaDAO
    {
        private dbContext context = new dbContext();
        public void InsertOrUpdate(TACGIA item)
        {
            if (item.ID == 0)
            {
                context.TACGIA.Add(item);
            }
            context.SaveChanges();
        }
        public TACGIA getItem(int id)
        {

            return context.TACGIA.Where(x => x.ID == id).FirstOrDefault();
        }
        public TacgiaVIEW getItemView(int id)
        {

            var query = (from a in context.TACGIA
                         where a.ID == id
                         select new TacgiaVIEW
                         {
                           ID=a.ID,
                           Tentacgia=a.Tentacgia
                         }).FirstOrDefault();
            return query;
          }
       
        public List<TacgiaVIEW> getList(String ten)
        {

            var query = (from a in context.TACGIA
                         where(a.Tentacgia.Contains(ten))
                         select new TacgiaVIEW
                         {
                             ID = a.ID,
                             Tentacgia = a.Tentacgia
                         }).ToList();
            return query;
        }
        public void Detele(int id)
        {
            TACGIA x = getItem(id);
            context.TACGIA.Remove(x);
            context.SaveChanges();
        }

    }
}