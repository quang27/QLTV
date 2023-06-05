using GUIs.Models.DAO;
using GUIs.Models.EF;
using GUIs.Models.VIEW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GUIs.Areas.Admin.Controllers
{
    public class MuontraController : Controller
    {
        // GET: Admin/Muontra
        private const string SACH_ID = "SACH_ID";
        private const string SINHVIEN_ID = "SINHVIEN_ID";
        private const string TRA_ID = "TRA_ID";
        public ActionResult Index() 
        {
            return View();
        }
        public JsonResult Search()
        {
            MuontraDAO muontra = new MuontraDAO();
            var query = muontra.getList();
            string text = "";
            int i = 1;
            foreach(var item in query)
            {
                text += "<tr>";
                text += "<td>"+ i++ +"</td>";
                text += "<td>"+ item.HotenSv +"</td>";
                text += "<td>" + item.Tensach + "</td>";
                text += "<td>" + item.Tentacgia + "</td>";
                text += "<td>" + item.NgayMuon + "</td>";
                text += "<td>" + item.NgayTra + "</td>";
                text += "<td>" + item.TinhTrangMuon + "</td>";
                text += "<td>" + item.TinhTrangTra + "</td>";
               
               
                text += "</tr>";
            }

            return Json(new { data=text},JsonRequestBehavior.AllowGet);

        }
        public ActionResult Create()
        {
            return View();
        }
        
        public JsonResult Save_Muon()
        {
            SinhvienVIEW sinhvienItem = (SinhvienVIEW)Session[SINHVIEN_ID];
            SachchitietVIEW  SachItem = (SachchitietVIEW)Session[SACH_ID];
            MuontraDAO muontra = new MuontraDAO();
            MUONTRA item = new MUONTRA();
            item.SVId = sinhvienItem.ID;
            item.SachCTId = SachItem.MaCT;
            item.NgayMuon = DateTime.Now;
            item.TinhTrangMuon = SachItem.Tinhtrang;
             
            //item.NVMuonId = model.NVMuonId;
            item.Hantra = item.NgayMuon.Value.AddDays(10);
            muontra.InsertOrUpdate(item);

            return Json(new { result="Cho mượn thành công"},JsonRequestBehavior.AllowGet);
        }
      
        public ActionResult Trasach()
        {
            return View();
        }

        public JsonResult Save_Tra()//id là mã code
        {
            if (Session[TRA_ID] != null)
            {
                MuontraVIEW muonview = (MuontraVIEW)Session[TRA_ID];
                MuontraDAO muontra = new MuontraDAO();


                MUONTRA item = muontra.getIitem(muonview.ID);

                item.NgayTra = DateTime.Now;
                item.TinhTrangTra = "";
                //item.NVTraId =  
                muontra.InsertOrUpdate(item);
                Session[TRA_ID] = null;
                return Json(new { result = "tra sach thanh cong" }, JsonRequestBehavior.AllowGet);
            }
            else 
                return Json(new { result = "tra sach ko thanh cong" }, JsonRequestBehavior.AllowGet);

        }
        public JsonResult Timsach_Tra(string id)
        {
            MuontraDAO muon = new MuontraDAO();
            var query = muon.getItemTraView(id);
            Session[TRA_ID] = query;
            return Json(new { data = query }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult TimSach(String id)
        {
            //id - Mã code sách
            SachchitietDAO sachchitiet = new SachchitietDAO();
            var query = sachchitiet.getItemVIEW(id);
            Session[SACH_ID] = query;
                
            return Json(new {  data = query }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult TimSinhvien(string id)
        {
            //id - Mã sinh viên
            SinhvienDAO sv = new SinhvienDAO();
            var query = sv.getItemView(id);
            Session[SINHVIEN_ID] = query;
            return Json(new { data = query }, JsonRequestBehavior.AllowGet);
        }
    }
}