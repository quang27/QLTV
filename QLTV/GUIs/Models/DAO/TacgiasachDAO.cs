using GUIs.Models.EF;
using GUIs.Models.VIEW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GUIs.Models.DAO
{
    public class TacgiasachDAO
    {
        private dbContext context = new dbContext();
        public void InsertOrUpdate(TACGIASACH item)
        {
            if(item.ID==0)
            {
                context.TACGIASACH.Add(item);
            }
            context.SaveChanges();
        }
        public TACGIASACH getItem(int id)
        {
            return context.TACGIASACH.Where(x => x.ID==id).FirstOrDefault();         
        }
        public TacgiasachVIEW getItemView(int id)
        {
            var query = (from a in context.TACGIASACH
                         where (a.ID == id)
                         select new TacgiasachVIEW
                         {
                             ID=a.ID,
                             MaSach = a.MaSach,
                             TacgiaId=a.TacgiaId
                         }).FirstOrDefault();
            return query;
        }
        public List<TacgiasachVIEW> getList()
        {
            var query = (from a in context.TACGIASACH
                         select new TacgiasachVIEW
                         {
                             ID = a.ID,
                             MaSach = a.MaSach,
                             TacgiaId = a.TacgiaId
                         }).ToList();
            return query;
        }
        public void Delete(int id)
        {
            TACGIASACH item = getItem(id);
            context.TACGIASACH.Remove(item);
            context.SaveChanges();
        }

    }
}