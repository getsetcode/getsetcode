using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using getsetcode.Business.Readers;
using getsetcode.Web.ActionResults;
using System.IO;

namespace getsetcode.Web.Controllers
{
    public class CvController : Controller
    {
        ICurriculumVitaeReader _reader;

        public CvController(ICurriculumVitaeReader reader)
        {
            _reader = reader;
        }

        public ActionResult Index()
        {
            return View(_reader.GetLatest());
        }

        public ActionResult Pdf()
        {
            var cv = _reader.GetLatest();
            return download(string.Format("~/content/cv/{0}.pdf", cv.FileName), "pdf");
        }

        public ActionResult PdfPreview()
        {
            var cv = _reader.GetLatest();
            return File(Server.MapPath(string.Format("~/content/cv/{0}.pdf", cv.FileName)), "application/pdf");
//            return download(string.Format("~/content/cv/{0}.pdf", cv.FileName), "pdf");
        }

        public ActionResult Word()
        {
            var cv = _reader.GetLatest();
            return download(string.Format("~/content/cv/{0}.doc", cv.FileName), "doc");
        }

        ActionResult download(string virtualPath, string extension)
        {
            string fullName = Server.MapPath(virtualPath);

            byte[] fileBytes = getFile(fullName);
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, string.Format("Tom Troughton - Curriculum Vitae.{0}", extension));
        }

        byte[] getFile(string s)
        {

            System.IO.FileStream fs = System.IO.File.OpenRead(s);
            byte[] data = new byte[fs.Length];
            int br = fs.Read(data, 0, data.Length);
            if (br != fs.Length)
                throw new System.IO.IOException(s);
            return data;
        }
    }
}
