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
    public class SachchitietController : Controller
    {
        // GET: Admin/Sachchitiet
        private const string sachID = "ID";
        public ActionResult Index(int? id)//id này là sachid
        {
            if (id == null) return RedirectToAction("index", "Sach", new { area = "admin" });
            Session[sachID] = id;
            var item = new SachDAO().getItemView(id.Value);
            return View(item);
        }
        
        [HttpPost]
        public JsonResult Save(string code, int namxb)
        {
            SachchitietDAO sachchitiet = new SachchitietDAO();
            SACHCHITIET item = new SACHCHITIET();
            var query = sachchitiet.getItemVIEW(code);
            if (query == null)
            {
                item.MaSach = Convert.ToInt16(Session[sachID]);
                item.Tinhtrang = "moi";
                item.Ngay_nhap = DateTime.Now;
                item.NamXb = namxb;
                item.MaCode = code;
                
                sachchitiet.InsertOrUpdate(item);
                return Json(new { result = "Cập nhật thành công!" }, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(new { result = "Ma code da co " }, JsonRequestBehavior.AllowGet);
        }
       
        public ActionResult Delete(int id)
        {
            SachchitietDAO sachchitiet = new SachchitietDAO();
            sachchitiet.Delete(id);
            return RedirectToAction("Index");
        }
        public JsonResult Search(String macode)
        {
            SachchitietDAO sachchitiet = new SachchitietDAO();
            var query = sachchitiet.getItemVIEW(macode);
            String text = "";
            text += "<tr>";
            text += "<td>" + query.MaCT + "</td>";
            text += "<td>" + query.MaSach+ "</td>";
            text += "<td>" + query.Tensach + "</td>";
            text += "<td>" + query.Tacgia + "</td>";           
            text += "<td>" + query.Ngay_nhap + "</td>";
            text += "<td>" + query.NamXb + "</td>";
            text += "<td>" + query.Tinhtrang + "</td>";
            text += "<td>" + query.MaCode + "</td>";
            text += "</tr>";
            return Json(new { data=text},JsonRequestBehavior.AllowGet);
        }
        
    }
}