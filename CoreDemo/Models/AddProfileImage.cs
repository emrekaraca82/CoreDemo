using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Models
{
    public class AddProfileImage
    {
        public int WriterId { get; set; }
        public string WriterName { get; set; }
        public string WriterAbout { get; set; }
        public IFormFile WriterImage { get; set; }
        public string WriterEmail { get; set; }
        public string WriterPassword { get; set; }
        public bool WriterStatus { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
