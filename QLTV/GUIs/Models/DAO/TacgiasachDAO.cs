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
        public List<TacgiasachVIEW> getList(int id)
        {
            var query = (from a in context.TACGIASACH
                         join b in context.TACGIA on a.TacgiaId equals b.ID
                         join c in context.SACH on a.MaSach equals c.ID
                         where (a.MaSach==id)
                         select new TacgiasachVIEW
                         {
                             ID = a.ID,
                             MaSach = a.MaSach,
                             Tentacgia = b.Tentacgia,
                             Tensach=c.TenSach,
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