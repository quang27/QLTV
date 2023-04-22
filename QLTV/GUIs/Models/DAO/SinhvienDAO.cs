using GUIs.Models.EF;
using GUIs.Models.VIEW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GUIs.Models.DAO
{
    public class SinhvienDAO
    {

        private dbContext context = new dbContext();
        public void InsertOrUpdate(SINHVIEN item) {
            if (item.ID == 0)
            {
                context.SINHVIEN.Add(item);
            }
            context.SaveChanges();
        }
        public SINHVIEN getItem(int id)
        {
            //Entity framework
            return context.SINHVIEN.Where(x => x.ID == id).FirstOrDefault();
        }
        public SinhvienVIEW getItemView(int id)
        {
            //LinQ
            var query = (from a in context.SINHVIEN
                          where a.ID == id
                          select new SinhvienVIEW
                          {
                              ID = a.ID,
                              Hoten = a.HoTen,
                              MaSV = a.MaSV,
                              Ngaysinh = a.NgaySinh,
                              Username = a.UserName
                          }).FirstOrDefault();
            return query;
        }
        public List<SINHVIEN> getList()
            {
            var ds = this.context.SINHVIEN.ToList();
            return ds;
        }
        public void Add(SINHVIEN sinhvien)
        {
            context.SINHVIEN.Add(sinhvien);
            context.SaveChanges();
        }
        public void Edit(SINHVIEN sv)
        {
            SINHVIEN x = getItem(sv.ID);
            x.UserName = sv.UserName;
            x.Pass = sv.Pass;
            context.SaveChanges();
        }

        public List<SINHVIEN> Search(String mssv)
        {

            var query = context.SINHVIEN.Where(x => x.MaSV.Contains(mssv)).ToList();
            return query;
        }
        public void Detele(int id)
        {
            SINHVIEN x = getItem(id);
            context.SINHVIEN.Remove(x);
            context.SaveChanges();
        }
    }
}