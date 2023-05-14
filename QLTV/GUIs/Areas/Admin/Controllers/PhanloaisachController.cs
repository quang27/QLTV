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
    public class PhanloaisachController : Controller
    {
        // GET: Admin/Phanloaisach
        public ActionResult Index()
        {
            PhanloaisachDAO phanloai = new PhanloaisachDAO();
            var query = phanloai.getList();
            string text = "";
            int i = 1;
            foreach(var item in query)
            {
                text += "<tr>";
                text += "<td>" + i++ + "</td>";
                text += "<td>" + item.TenPhanLoai + "</td>";
                text += "<td><a href='/Admin/Phanloaisach/Edit/" + item.ID + "'><i class='fa fa-edit' aria-hidden='true'></i></td>";
                text += "<td><a href='/Admin/Phanloaisach/Delete/" + item.ID + "'><i class='fa fa-trash' aria-hidden='true'></i></td>";
                text += "</tr>";
            }
            ViewBag.danhsach = text;
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(PhanloaisachVIEW model)
        {
            PhanloaisachDAO phanloai = new PhanloaisachDAO();
            var item = new PHANLOAISACH();
            item.TenPhanLoai = model.TenPhanLoai;
            phanloai.InsertOrUpdate(item);
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int? id)
        {
            PhanloaisachDAO phanloai = new PhanloaisachDAO();
            if (id == 0) return RedirectToAction("Index");
            return View(phanloai.getItemView(id.Value));
        }
        public ActionResult Edit(PhanloaisachVIEW model)
        {
            PhanloaisachDAO phanloai = new PhanloaisachDAO();
            var item = phanloai.getItem(model.ID);
            item.TenPhanLoai = model.TenPhanLoai;
            phanloai.InsertOrUpdate(item);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            PhanloaisachDAO phanloai = new PhanloaisachDAO();       
            phanloai.Delete(id);
            return RedirectToAction("Index");
        }
    }
}