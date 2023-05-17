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
    public class TacgiasachController : Controller
    {
        // GET: Admin/Tacgiasach
        public ActionResult Index()
        {
             
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(TacgiasachVIEW model )
        {
            TacgiasachDAO tacgiasach = new TacgiasachDAO();
            var item = new TACGIASACH();
            item.TacgiaId = model.TacgiaId;
            item.MaSach = model.MaSach;
            tacgiasach.InsertOrUpdate(item);
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int ?id)
        {
            TacgiasachDAO tacgiasach = new TacgiasachDAO();
            if(id==null) return RedirectToAction("Index");
            return View(tacgiasach.getItemView(id.Value));
        }
        [HttpPost]
        public ActionResult Edit(TacgiasachVIEW model)
        {
            TacgiasachDAO tacgiasach = new TacgiasachDAO();
            var item = tacgiasach.getItem(model.ID);
            item.MaSach = item.MaSach;
            item.TacgiaId = item.TacgiaId;
            tacgiasach.InsertOrUpdate(item);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            TacgiasachDAO tacgiasach = new TacgiasachDAO();
            tacgiasach.Delete(id);
            return RedirectToAction("Index");
        }
    }
}