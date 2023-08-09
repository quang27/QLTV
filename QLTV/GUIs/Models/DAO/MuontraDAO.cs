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
            if(item.ID==0)
            {
                context.MUONTRA.Add(item);
            }
            context.SaveChanges();
        }
        public MUONTRA getIitem(int id)
        {

            return context.MUONTRA.Where(x => x.ID == id).FirstOrDefault();
        }
        public MuontraVIEW getItemTraView(String code)
        {
            var query = (from a in context.MUONTRA
                         join c in context.SACHCHITIET on a.SachCTId equals c.MaCT
                         join b in context.SINHVIEN on a.SVId equals b.ID
                         join d in context.SACH on c.MaSach equals d.ID
                         join e in context.TACGIASACH on d.ID equals e.MaSach
                         join f in context.TACGIA on e.TacgiaId equals f.ID
                         join g in context.LOP on b.LopID equals g.ID
                         where (a.NgayTra == null && c.MaCode==code)
                         select new MuontraVIEW
                         {
                             ID=a.ID,
                             Tensach=d.TenSach,
                             Tentacgia=f.Tentacgia,
                             TinhTrangMuon=a.TinhTrangMuon,
                             SVId=b.ID,
                             HotenSv=b.HoTen,
                             Tenlop=g.TenLop,
                             MSSV=b.MaSV,
                             Tinhtrangthe=b.Trangthaithe??true//Nếu b.tinhtrangthe == null thì mặc định là true;
                         }).FirstOrDefault();
            return query;
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
                         join b in context.SACHCHITIET on a.SachCTId equals b.MaCT
                         join c in context.SACH on b.MaSach equals c.ID
                         join d in context.TACGIASACH on c.ID equals d.MaSach
                         join e in context.TACGIA on d.TacgiaId equals e.ID
                         join f in context.SINHVIEN on a.SVId equals f.ID

                         select new MuontraVIEW
                         {
                             ID = a.ID,
                             SVId = a.SVId,
                             Tensach = c.TenSach,
                             HotenSv =f.HoTen,
                             Tentacgia=e.Tentacgia,
                             SachCTId = a.SachCTId,
                             NgayMuon = a.NgayMuon,
                             NgayTra = a.NgayTra,
                             TinhTrangMuon = a.TinhTrangMuon,
                             TinhTrangTra = a.TinhTrangTra,
                             NVMuonId = a.NVMuonId,
                             NVTraId = a.NVTraId,
                             Baomat = a.Baomat,
                             Hantra=a.Hantra
                         }).ToList();
            //skip(10) - bỏ qua 10 bản ghi đầu tiên
            //take(10) - lấy 10 bảng ghi
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