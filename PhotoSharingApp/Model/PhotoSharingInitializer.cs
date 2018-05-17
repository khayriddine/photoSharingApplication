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
            Collection<Photo> Photos = new Collection<Photo>();
            Photo MyPhoto1 = new Photo();
            MyPhoto1.Owner = "Khayri";
            MyPhoto1.Title = "khayri";
            MyPhoto1.Description= "khayri";
            MyPhoto1.CreatedDate = DateTime.Now;
            MyPhoto1.PhotoFile = GeneralFunctions.getPhotoFileByName("C:/CSharp/p1/photoSharingApplication/Images/khayri.jpg");
            MyPhoto1.ImageMimeType = "image/jpg";
            Photos.Add(MyPhoto1);
            context.SaveChanges();
            Photo MyPhoto2 = new Photo();
            MyPhoto2.Owner = "hcen";
            MyPhoto2.Title = "hcen";
            MyPhoto2.CreatedDate = DateTime.Now;
            MyPhoto2.PhotoFile = GeneralFunctions.getPhotoFileByName("C:/CSharp/p1/photoSharingApplication/Images/hcen.jpg");
            MyPhoto2.ImageMimeType = "image/jpg";
            Photos.Add(MyPhoto2);
            context.Photos.AddRange(Photos);
            context.SaveChanges();

            base.Seed(context);
        }
    }
}