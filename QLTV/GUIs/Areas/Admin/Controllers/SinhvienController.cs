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
        private const string LOPID = "LOPID";
        public ActionResult Index()
        {
           
            ViewBag.Lops =new LopDAO().getList();
            
             
            return View();
        }
        public JsonResult getSinhvien(int id) {
            Session[LOPID] = id;
            SinhvienDAO sv = new SinhvienDAO();
            var query = sv.getList(id);
            int i = 1;
            string text = "";
            foreach (var item in query)
            {
                text += "<tr> <td>" + i++ + "</td>";
                text += "<td class=''>" + item.Hoten + "</td>";
                text += "<td>" + item.MaSV + "</td>";
                text += "<td>" + item.Tenlop + "</td>";
                text += "<td>" + item.Ngaysinh + "</td>";
                text += "<td>" + item.Username + "</td>";
                text += "<td>";
                text += "<a href='/Admin/Sinhvien/Edit/" + item.ID + "'><i class='fa fa-edit' aria-hidden='true'></i>";
                text += "</td>";
                text += "<td>";
                text += "<a href='javascript:void(0)' onclick='Sinhvien.Delete(" + item.ID + ")'><i class='fa fa-trash' aria-hidden='true'></i>";
                text += "</td>";
                text += "<td> </td> </tr>";
            }
            string mess = "Số bản ghi tìm thấy: " + query.Count();
            return Json(new { data = text, mess = mess }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Create(){
        
            return View();
        }
        [HttpPost]
        public ActionResult Create(SinhvienVIEW model)
        {
            int lopid = Convert.ToInt16(Session[LOPID]);
            SinhvienDAO sv = new SinhvienDAO();
            var item = new SINHVIEN();
            item.UserName = model.Username;
            item.HoTen = model.Hoten;
            item.LopID = lopid;
            item.NgaySinh = model.Ngaysinh;
            item.MaSV = model.MaSV;
            item.Pass = model.Password;
            sv.InsertOrUpdate(item);
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int? id)
        {
            SinhvienDAO sinhvien = new SinhvienDAO();
            if (id == null) return RedirectToAction("Index");
            return View(sinhvien.getItemView(id.Value));
            
        }
        [HttpPost]
        public ActionResult Edit(SinhvienVIEW model)
        {
            SinhvienDAO sv = new SinhvienDAO();
            var item = sv.getItem(model.ID);
            item.UserName = model.Username;
            item.HoTen = model.Hoten;
            //item.LopID = model.LopID;
            item.MaSV = model.MaSV;
            item.Pass = model.Password;
            sv.InsertOrUpdate(item);
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
                text += "<td>" + item.Hoten + "</td>";
                text += "<td> </td> </tr>";
            }
            return Json(new { data = text, thongbao = "Số bản ghi tìm thấy: " + query.Count() }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(int id)
        {
            SinhvienDAO x = new SinhvienDAO();
            x.Detele(id);
            return Json(new {result ="Xóa thành công!" },JsonRequestBehavior.AllowGet);
        }
    }
}