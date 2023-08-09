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
    public class LopController : Controller
    {

        // GET: Admin/Lop
        public ActionResult Index()
        {
           
            return View();
        }
        public JsonResult ShowList()
        {
            LopDAO lop = new LopDAO();
            var query = lop.getList();
            string text = "";
            int i = 1;
            foreach (var item in query)
            {
                text += "<tr>";
                text += "<td>" + i++ + "</td>";
                text += "<td>";
                text += item.Tenlop;
                text += "</td>";
                text += "<td> <a href='/Admin/Lop/Edit/" + item.Id + "'><i class='fa fa-edit' aria-hidden='true'></i> </td>";
                text += "<td> <a href='/Admin/Lop/Delete/" + item.Id + "'><i class='fa fa-trash' aria-hidden='true'></i> </td>";
                text += "</tr>";
            }

            return Json(new { danhsach = text, thongbao = "tong so lop " + query.Count() }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(LopVIEW model)
        {
            LopDAO lopDAO = new LopDAO();
            LOP item = new LOP();
            item.TenLop = model.Tenlop;
            lopDAO.InsertOrUpdate(item);
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int? id)
        {
            LopDAO lop = new LopDAO();
            if (id == null) return RedirectToAction("Index");
            return View(lop.getItemView(id.Value));
        }
        [HttpPost]
        public ActionResult Edit(LopVIEW model)
        {
            LopDAO lop = new LopDAO();
            var item = lop.getItem(model.Id);
            item.TenLop = model.Tenlop;
            lop.InsertOrUpdate(item);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            LopDAO lop = new LopDAO();
            lop.Detele(id);
            return RedirectToAction("Index");
        }
    }
}