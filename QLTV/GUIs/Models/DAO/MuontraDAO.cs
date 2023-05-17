using GUIs.Models.EF;
using GUIs.Models.VIEW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GUIs.Models.DAO
{
    public class MuontraDAO
    {
        dbContext context = new dbContext();
        public void InsertOrUpdate(MUONTRA item)
        {
            if(item.ID==null)
            {
                context.MUONTRA.Add(item);
            }
            context.SaveChanges();
        }
        public MUONTRA getIitem(int id)
        {

            return context.MUONTRA.Where(x => x.ID == id).FirstOrDefault();
        }
        public MuontraVIEW getItemView(int id)
        {
            var query = (from a in context.MUONTRA
                         where (a.ID == id)
                         select new MuontraVIEW
                         {
                             ID = a.ID,
                             SVId=a.SVId,
                             SachCTId=a.SachCTId,
                             NgayMuon=a.NgayMuon,
                             NgayTra=a.NgayTra,
                             TinhTrangMuon=a.TinhTrangMuon,
                             TinhTrangTra=a.TinhTrangTra,
                             NVMuonId=a.NVMuonId,
                             NVTraId=a.NVTraId,
                             Baomat=a.Baomat
                         }).FirstOrDefault();
            return query;
        }
        public List<MuontraVIEW> getList()
        {
            var query = (from a in context.MUONTRA

                         select new MuontraVIEW
                         {
                             ID = a.ID,
                             SVId = a.SVId,
                             SachCTId = a.SachCTId,
                             NgayMuon = a.NgayMuon,
                             NgayTra = a.NgayTra,
                             TinhTrangMuon = a.TinhTrangMuon,
                             TinhTrangTra = a.TinhTrangTra,
                             NVMuonId = a.NVMuonId,
                             NVTraId = a.NVTraId,
                             Baomat = a.Baomat
                         }).ToList();
            return query;
        }
        public void Delete(int id)
        {
            MUONTRA x = new MUONTRA();
            context.MUONTRA.Remove(x);
            context.SaveChanges();
        }
    }
}