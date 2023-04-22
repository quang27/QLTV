﻿using GUIs.Models.EF;
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
        public List<NHAXUATBAN> getList()
        {
            var ds = this.context.NHAXUATBAN.ToList();
            return ds;
        }
        public void Edit(NHAXUATBAN x)
        {
            NHAXUATBAN nxb = getItem(x.ID);
            nxb.TenNXB= x.TenNXB;
            nxb.DiaChi = x.DiaChi;
            context.SaveChanges();
        }
        public List<NHAXUATBAN> Search(String tenNXB, string diachi)
        {

            var query = context.NHAXUATBAN.Where(x => x.TenNXB.Contains(tenNXB)).ToList();
            return query;
        }
        public void Delete(int id)
        {
            NHAXUATBAN x = getItem(id);
            context.NHAXUATBAN.Remove(x);
            context.SaveChanges();
        }
    }
}