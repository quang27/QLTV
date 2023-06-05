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
                         join b in context.LOP on a.LopID equals b.ID
                          where a.ID == id
                          select new SinhvienVIEW
                          {
                              ID = a.ID,
                              Hoten = a.HoTen,
                              MaSV = a.MaSV,
                              Ngaysinh = a.NgaySinh,
                              Username = a.UserName,
                              Tenlop = b.TenLop
                          }).FirstOrDefault();
            return query;
        }
        public SinhvienVIEW getItemView(string  MaSv)
        {
            //LinQ
            var query = (from a in context.SINHVIEN
                         join b in context.LOP on a.LopID equals b.ID
                         where a.MaSV == MaSv
                         select new SinhvienVIEW
                         {
                             ID = a.ID,
                             Hoten = a.HoTen,
                             MaSV = a.MaSV,
                             Ngaysinh = a.NgaySinh,
                             Username = a.UserName,
                             Tenlop = b.TenLop
                         }).FirstOrDefault();
            return query;
        }
        /// <summary>
        /// Lấy sinh viên theo mã lớp
        /// </summary>
        /// <param name="Lopid">Mã lớp</param>
        /// <returns></returns>
        public List<SinhvienVIEW> getList(int Lopid)
            {
            var query = (from a in context.SINHVIEN   
                         join b in context.LOP on a.LopID equals b.ID
                         where b.ID==Lopid
                         select new SinhvienVIEW
                         {
                             ID = a.ID,
                             Hoten = a.HoTen,
                             MaSV = a.MaSV,
                             Tenlop=b.TenLop,
                             Ngaysinh = a.NgaySinh,
                             Username = a.UserName
                         }).ToList();
            return query;
        }
        
        

        public List<SinhvienVIEW> Search(String mssv)
        {

            var query = (from a in context.SINHVIEN.Where(x => x.MaSV.Contains(mssv))
                         join b in context.LOP on a.LopID equals b.ID
                         select new SinhvienVIEW
                         {
                             ID = a.ID,
                             Hoten = a.HoTen,
                             MaSV = a.MaSV,
                             Tenlop = b.TenLop,
                             Ngaysinh = a.NgaySinh,
                             Username = a.UserName
                         }
                         ).ToList();
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