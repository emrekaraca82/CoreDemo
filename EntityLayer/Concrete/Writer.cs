using CoreLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Writer: IEntity
    {
        [Key]
        public int WriterId { get; set; }
        public string WriterName { get; set; }
        public string WriterAbout { get; set; }
        public string WriterImage { get; set; }
        public string WriterEmail { get; set; }
        public string WriterPassword { get; set; }
        public bool WriterStatus { get; set; }
        public DateTime CreateDate { get; set; }
        public List<Blog> Blogs { get; set; }
        public virtual ICollection<MessageTwo> WriterSender { get; set; }
        public virtual ICollection<MessageTwo> WriterReceiver { get; set; }
    }
}
