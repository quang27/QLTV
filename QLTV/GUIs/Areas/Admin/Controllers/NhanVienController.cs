using GUIs.Models.DAO;
using GUIs.Models.EF;
using GUIs.Models.VIEW;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GUIs.Areas.Admin.Controllers
{
    public class NhanVienController : Controller
    {
        // GET: Admin/NhanVien
        public ActionResult Index()
        {
            return View(); //Json(new { data = text, thongbao = "Số bản ghi tìm thấy: " + query.Count() }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public JsonResult Create(string TenNv,string Email,string Pass,string SDT, HttpPostedFileBase Anh)
        {
            NhanVienDAO nhanvien = new NhanVienDAO();
            var item = new NHANVIEN();
            item.TenNV =  TenNv;
            item.SDT =  SDT;
            item.Email = Email;
            item.Pass =  Pass;
            
            
            nhanvien.InsertOrUpdate(item);
            string text = "Không có ảnh";
            if (Anh != null)
            {
                
                string Name = Anh.FileName;
                Name = Name.Substring(Name.LastIndexOf(".") + 1);//Lay phan duoi
                string tenanh = item.ID + "_" + TenNv + "." + Name;
                string path = Path.Combine(Server.MapPath("~"), "Upload", "Avata", tenanh);
                Anh.SaveAs(path);//Lưu và thư mục Uploads/Âvata
                item.Anh = path;//Đường dẫn tới ảnh
                text = path;
                nhanvien.InsertOrUpdate(item);
            }
            return Json(new { result=text},JsonRequestBehavior.AllowGet);
        }
        public ActionResult Edit(int? id)
        {
            NhanVienDAO nhanvien = new NhanVienDAO();
            if (id == null) return RedirectToAction("Index");
            return View(nhanvien.getItemView(id.Value));

        }
        [HttpPost]
        public ActionResult Edit(NhanVienVIEW model)
        {
            NhanVienDAO nhanvien = new NhanVienDAO();
            var item = nhanvien.getItem(model.ID);
            item.TenNV = model.TenNV;
            item.SDT = model.SDT;
            item.Email = model.Email;
            item.Pass = model.Pass;
            nhanvien.InsertOrUpdate(item);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            NhanVienDAO x = new NhanVienDAO();
            x.Detele(id);
            return RedirectToAction("Index");
        }
        public JsonResult Search(String ten="")
        {
            NhanVienDAO nhanvien = new NhanVienDAO();
            String text = "";
            int i = 1;
            var query = nhanvien.getList(ten);
            foreach (var item in query)
            {
                text += "<tr> <td>" + i++ + "</td>";
                text += "<td class=''>" + item.TenNV + "</td>";
                text += "<td>" + item.Email + "</td>";
                text += "<td>" + item.SDT + "</td>";
                text += "<td>";
                text += "<a href='/Admin/Nhanvien/Edit/" + item.ID + "'><i class='fa fa-edit' aria-hidden='true'></i> </td>";
                text += "<td>";
                text += "<a href='/Admin/Nhanvien/Delete/" + item.ID + "'><i class='fa fa-trash' aria-hidden='true'></i>";
                text += "</td>";
                text += " </tr>";
            }
            return Json(new { data = text, thongbao = "Số bản ghi tìm thấy: " + query.Count() }, JsonRequestBehavior.AllowGet);
        }


    }
}