using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PhotoSharingApp.Model
{
    public class PhotoSharingInitializer : DropCreateDatabaseAlways<PhotoSharingContext>
    {
        protected override void Seed(PhotoSharingContext context)
        {
            Photo MyPhoto1 = new Photo();
            MyPhoto1.Owner = "Khayri";
            MyPhoto1.Title = "khayri";
            MyPhoto1.PhotoFile = GeneralFunctions.getPhotoFileByName("Images/khayri.jpg");

            Photo MyPhoto2 = new Photo();
            MyPhoto2.Owner = "Khayri";
            MyPhoto2.Title = "khayri";
            MyPhoto2.PhotoFile = GeneralFunctions.getPhotoFileByName("Image/hcen.jpg");

            context.Photos.Add(MyPhoto1);
            context.Photos.Add(MyPhoto2);

            Collection<Comment> Comments = new Collection<Comment>();
            Comment MyComment = new Comment();
            MyComment.Body = "Test Comment";
            MyComment.User = "khayri";
            MyComment.PhotoID = 1;
            MyComment.Subject = "This comment should appear in photo 1";

            Comments.Add(MyComment);
            context.Comments.AddRange(Comments);
            context.SaveChanges();

            base.Seed(context);
        }
    }
}