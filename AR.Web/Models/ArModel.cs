using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace AR.Web.Models
{
    public class MyViewModel
    {
        [DisplayName("Select File to Upload")]
        public HttpPostedFileBase File { get; set; }
    }

    public class FileUploadDBModel
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public byte[] File { get; set; }
    }
}