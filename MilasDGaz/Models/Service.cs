//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MilasDGaz.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Web;

    public partial class Service
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }

        [DisplayName("Upload File")]

        public HttpPostedFileBase ImageFile { get; set; }
    }
}

