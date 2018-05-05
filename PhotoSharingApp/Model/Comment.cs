using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoSharingApp.Model
{
    public class Comment
    {
        public string CommentID { get; set; }
        public string User { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public int PhotosID { get; set; }
    }
}