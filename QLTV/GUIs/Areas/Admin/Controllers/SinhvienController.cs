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
    public class SinhvienController : Controller
    {
        // GET: Admin/Sinhvien
        public ActionResult Index()
        {
            SinhvienDAO sv = new SinhvienDAO();
            var ds = sv.getList();
            return View(ds);
        }
        public ActionResult Create(){
        
            return View();
        }
        [HttpPost]
        public ActionResult Create(SINHVIEN model)
        {
            SinhvienDAO sv = new SinhvienDAO();
            sv.InsertOrUpdate(model);
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int? id)
        {
            SinhvienDAO sinhvien = new SinhvienDAO();
            if (id == null) return RedirectToAction("Index");
            return View(sinhvien.getItem(id.Value));
            
        }
        [HttpPost]
        public ActionResult Edit(SINHVIEN model)
        {
            SinhvienDAO sv = new SinhvienDAO();
            sv.Edit(model);
            return RedirectToAction("Index");          
        }
        public JsonResult Search(string mssv, string hoten)
        {
            SinhvienDAO sv = new SinhvienDAO();
            var query = sv.Search(mssv);
            string text = "";
            int i = 1;
            foreach (var item in query)
            {
                text += "<tr> <td>" + i++ + "</td>";
                text += "<td class=''>" + item.MaSV + "</td>";
                text += "<td>" + item.HoTen + "</td>";
                text += "<td> </td> </tr>";
            }
            return Json(new { data = text, thongbao = "Số bản ghi tìm thấy: " + query.Count() }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Delete(int id)
        {
            SinhvienDAO x = new SinhvienDAO();
            x.Detele(id);
            return RedirectToAction("Index");
        }
    }
}