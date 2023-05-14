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
    public class TacgiaController : Controller
    {
        // GET: Admin/Tacgia
        public ActionResult Index()
        {
          
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(TacgiaVIEW model)
        {
            TacgiaDAO tacgia = new TacgiaDAO();
            TACGIA item = new TACGIA();
            item.Tentacgia = model.Tentacgia;
            tacgia.InsertOrUpdate(item);
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int? id)
        {
            TacgiaDAO tacgia = new TacgiaDAO();
            if (id == null) return RedirectToAction("Index");
            return View(tacgia.getItemView(id.Value));
        }
        [HttpPost]
        public ActionResult Edit(TacgiaVIEW model)
        {
            TacgiaDAO tacgia = new TacgiaDAO();
            var item = tacgia.getItem(model.ID);
            item.Tentacgia = model.Tentacgia;
            tacgia.InsertOrUpdate(item);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            TacgiaDAO tacgia = new TacgiaDAO();
            tacgia.Detele(id);
            return RedirectToAction("Index");
        }
        public  JsonResult Search(string ten)
        {
            TacgiaDAO tacgia = new TacgiaDAO();
            var query = tacgia.getList(ten);
            string text = "";
            int i = 1;
            foreach (var item in query)
            {
                text += "<tr> <td>" + i++ + "</td>";
                text += "<td>" + item.Tentacgia + "</td>";
                text += "<td>";
                text += "<a href='/Admin/Tacgia/Edit/" + item.ID + "'><i class='fa fa-edit' aria-hidden='true'></i> </td>";
                text += "</td>";
                text += "<td>";
                text += "<a href='/Admin/Tacgia/Delete/" + item.ID + "'><i class='fa fa-trash' aria-hidden='true'></i> </td>";
                text += "</td> </tr>";
            }
            return Json(new { data=text},JsonRequestBehavior.AllowGet);
        }
    }
}