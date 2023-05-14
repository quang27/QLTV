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
    public class SachController : Controller
    {

        private const string NXBID = "NXBID";
        private const string PHANLOAIID = "PHANLOAIID";
        // GET: Admin/Sach
        public ActionResult Index()
        {
            NhaXuatBanDAO nxb = new NhaXuatBanDAO();
            var item = nxb.getList();
            ViewBag.listnxb = item;
            PhanloaisachDAO phanloai = new PhanloaisachDAO();
            var items = phanloai.getList();
            ViewBag.listphanloai = items;
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(SachVIEW model)
        {
            //Buoc 2: Lay session ra
            int nxbid = Convert.ToInt16(Session[NXBID]);
            int plid = Convert.ToInt16(Session[PHANLOAIID]);
            SachDAO sach = new SachDAO();
            var item = new SACH();       
            
            item.NXBId = nxbid;
            item.TenSach = model.TenSach;
            item.PhanLoaiId = plid;
            item.GiaTien = model.GiaTien;
            item.AnhBia = model.AnhBia;
            item.Tomtat = model.Tomtat;
            item.Noi_dung = model.Noi_dung;
            sach.InsertOrUpdate(item);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public JsonResult Save(string Tensach,int Giatien,string tomtat,string noidung,string anhbia)
        {
            //Buoc 2: Lay session ra
            int nxbid = Convert.ToInt16(Session[NXBID]);
            int plid = Convert.ToInt16(Session[PHANLOAIID]);
            SachDAO sach = new SachDAO();
            var item = new SACH();

            item.NXBId = nxbid;
            item.TenSach = Tensach;
            item.PhanLoaiId = plid;
            item.GiaTien = Giatien;
            item.AnhBia =anhbia;
            item.Tomtat = tomtat;
            item.Noi_dung = noidung;
            sach.InsertOrUpdate(item);
            return Json(new { result = "Cập nhật thành công"}, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Edit(int? id)
        {
            SachDAO sach = new SachDAO();
            if (id == null) return RedirectToAction("Index");
            return View(sach.getItemView(id.Value));
        }
        [HttpPost]
        public ActionResult Edit(SachVIEW model)
        {
            SachDAO sach = new SachDAO();
            var item = sach.getItem(model.ID);
            item.TenSach = model.TenSach;
            item.NXBId = model.NXBId;
            item.PhanLoaiId = model.PhanLoaiId;
            item.GiaTien = model.GiaTien;
            item.AnhBia = model.AnhBia;
            item.Tomtat = model.Tomtat;
            item.Noi_dung = model.Noi_dung;
            sach.InsertOrUpdate(item);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            SachDAO sach = new SachDAO();
            sach.Detele(id);
            return RedirectToAction("Index");
        }
        public JsonResult Search(String tensach,int phanloai=0,int nhaxb=0)
        {
            SachDAO sach = new SachDAO();
            Session[NXBID] = nhaxb;
            Session[PHANLOAIID] = phanloai;
            //Buoc 1 - thiet lap cac session
            var query = sach.getList(tensach,phanloai,nhaxb);
            String text = "";
            int i = 1;
            foreach(var item in query)
            {
                text += "<tr>";
                text += "<td>"+ i++ +"</td>";
                text += "<td>" + item.TenSach+ "</td>";
                text += "<td>" + item.Phanloai + "</td>";
                text += "<td>" + item.TenNxb + "</td>";
                text += "<td>" + item.GiaTien + "</td>";
                text += "<td>" + item.AnhBia+ "</td>";
                text += "<td><a href='/Admin/Sach/Edit/" + item.ID + "'><i class='fa fa-edit' aria-hidden='true'></i></td>";
                text += "<td><a href='/Admin/Sach/Delete/" + item.ID + "'><i class='fa fa-trash' aria-hidden='true'></i></td>";               
                text += "</tr>";
            }
            return Json(new {data=text },JsonRequestBehavior.AllowGet);
        }
    }
}