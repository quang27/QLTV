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
        public ActionResult Index()
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
                text += "<td>" + item.NgayMuon + "</td>";
                text += "<td>" + item.NgayTra + "</td>";
                text += "<td>" + item.TinhTrangMuon + "</td>";
                text += "<td>" + item.TinhTrangTra + "</td>";
                text += "<td>" + item.Nhanvienchomuon + "</td>";
                text += "<td>" + item.Nhanviennhantra + "</td>";
                text += "<td>" + item.Baomat + "</td>";
                text += "</tr>";
            }
            ViewBag.ds = text;
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(MuontraVIEW model)
        {
            MuontraDAO muontra = new MuontraDAO();
            MUONTRA item = new MUONTRA();
            item.SVId = model.SVId;
            item.SachCTId = model.SachCTId;
            item.NgayMuon = model.NgayMuon;
            item.NgayTra = model.NgayTra;
            item.TinhTrangMuon = model.TinhTrangMuon;
            item.NgayTra = model.NgayTra;
            return RedirectToAction("Index");
        }
    }
}