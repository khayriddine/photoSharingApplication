using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhotoSharingApp.Model
{
    public class Photo
    {
        public int PhotoID { get; set; }
        public String Title { get; set; }
        [DisplayName("Picture")]
        public byte[] PhotoFile { get; set; }
        [DataType(DataType.MultilineText)]
        public String Description { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayName("Created Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yy}", ApplyFormatInEditMode = true)]
        public DateTime CreatedDate { get; set; }
        public String Owner { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }



    }
}