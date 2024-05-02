using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MilasDGaz.ViewModels
{
    public class AboutViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Item1 { get; set; }
        public string Item2 { get; set; }
        public string Item3 { get; set; }
        public string Image1 { get; set; }

        public string Image2 { get; set; }
        public HttpPostedFileBase Image1File { get; set; }
        public HttpPostedFileBase Image2File { get; set; }
        
    }
}