
using GUIs.Models.DAO;
using GUIs.Models.EF;
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
            NhaXuatBanDAO nxb = new NhaXuatBanDAO();
            var ds = nxb.getList();
            return View(ds);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(NHAXUATBAN model)
        {
            NhaXuatBanDAO nxb = new NhaXuatBanDAO();
            nxb.InsertOrUpdate(model);
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int? id)
        {
            NhaXuatBanDAO nxb = new NhaXuatBanDAO();
            if (id == null) return RedirectToAction("Index");
            return View(nxb.getItem(id.Value));
        }
        [HttpPost]
        public ActionResult Edit(NHAXUATBAN model)
        {
            NhaXuatBanDAO nxb= new NhaXuatBanDAO();
            nxb.Edit(model);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            NhaXuatBanDAO nxb=new NhaXuatBanDAO();
            nxb.Delete(id);
            return RedirectToAction("Index");
        }
        public JsonResult Search(String TenNxb,String Diachi)
        {
            NhaXuatBanDAO nxb = new NhaXuatBanDAO();
            var query = nxb.Search(TenNxb, Diachi);
            String text = "";
            int i = 1;
            foreach(var item in query)
            {

            }
        }

    }
}