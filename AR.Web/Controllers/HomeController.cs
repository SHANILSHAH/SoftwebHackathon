using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AR.Web.Models;

namespace AR.Web.Controllers
{
    public class HomeController : Controller
    {
        private FileUploadDBContext db = new FileUploadDBContext();

        public ActionResult Index()
        {
            var model = new MyViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(MyViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            FileUploadDBModel fileUploadModel = new FileUploadDBModel();

            byte[] uploadFile = new byte[model.File.InputStream.Length];
            model.File.InputStream.Read(uploadFile, 0, uploadFile.Length);

            fileUploadModel.FileName = model.File.FileName;
            fileUploadModel.File = uploadFile;

            db.FileUploadDBModels.Add(fileUploadModel);
            db.SaveChanges();

            return Content("File Uploaded.");
        }

        public ActionResult Download()
        {
            return View(db.FileUploadDBModels.ToList());
        }

        public FileContentResult FileDownload(int? id)
        {
            byte[] fileData;
            string fileName;

            FileUploadDBModel fileRecord = db.FileUploadDBModels.Find(id);

            fileData = (byte[])fileRecord.File.ToArray();
            fileName = fileRecord.FileName;

            return File(fileData, "text", fileName);
        }
    }
}