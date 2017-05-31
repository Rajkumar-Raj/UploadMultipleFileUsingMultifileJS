using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UploadMultipleFilesInMVC.Controllers
{
    public class MultipleController : Controller
    {
        // GET: Multiple
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(IEnumerable<HttpPostedFileBase> files)
        {
            if (files != null)
            {
                foreach (var file in files)
                {
                    if (file != null && file.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        var path = Path.Combine(Server.MapPath("~/UploadedFiles/"), fileName);
                        file.SaveAs(path);
                    }
                }
            }


            return RedirectToAction("Index");
        }

    }
}