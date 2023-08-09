
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
    public class NhaXuatBanController : Controller
    {
        // GET: Admin/NhaXuatBan
        public ActionResult Index()
        {
            List<Lopchung> pagesize = new List<Lopchung>();
            pagesize.Add(new Lopchung { ID = 10 });
            pagesize.Add(new Lopchung { ID = 20 });
            pagesize.Add(new Lopchung { ID = 30 });
            pagesize.Add(new Lopchung { ID = 40 });
            pagesize.Add(new Lopchung { ID = 50 });
            ViewBag.Pagesize = pagesize;
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(NhaXuatBanVIEW model)
        {
            NhaXuatBanDAO nxb = new NhaXuatBanDAO();
            NHAXUATBAN item = new NHAXUATBAN();
            item.TenNXB = model.TenNXB;
            item.DiaChi = model.DiaChi;
            nxb.InsertOrUpdate(item);
            return RedirectToAction("Index");
        }
       
        public ActionResult Edit(int? id)
        {
            NhaXuatBanDAO nxb = new NhaXuatBanDAO();
            if (id == null) return RedirectToAction("Index");
            return View(nxb.getItemView(id.Value));
        }
        [HttpPost]
        public ActionResult Edit(NhaXuatBanVIEW model)
        {
            NhaXuatBanDAO nxb= new NhaXuatBanDAO();
            var item=nxb.getItem(model.ID);
            item.TenNXB = model.TenNXB;
            item.DiaChi = model.DiaChi;
            nxb.InsertOrUpdate(item);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            NhaXuatBanDAO nxb=new NhaXuatBanDAO();
            nxb.Delete(id);
            return RedirectToAction("Index");
        }
        public JsonResult Search(String TenNxb="",int index=1,int size=10)
        {
            NhaXuatBanDAO nxb = new NhaXuatBanDAO();
            int total = 0;
            var query = nxb.Search(TenNxb,out total,index,size);
            String text = "";
            int i = 1;
            foreach(var item in query)
            {
                text += "<tr> <td>" + i++ + "</td>";
                text += "<td>" + item.TenNXB + "</td>";
                text += "<td>" + item.DiaChi + "</td>";
                text += "<td>";
                text += "<a href='/Admin/NhaXuatBan/Edit/" + item.ID + "'><i class='fa fa-edit' aria-hidden='true'></i> </td>";
                text += "</td>";
                text += "<td>";
                text += "<a href='/Admin/NhaXuatBan/Delete/" + item.ID + "'><i class='fa fa-trash' aria-hidden='true'></i>";
                text += "</td> </tr>";
            }
            string pages = Support.Support.InTrang(total, index, size);
            return Json(new { data=text,page=pages}, JsonRequestBehavior.AllowGet);
        }

    }
}