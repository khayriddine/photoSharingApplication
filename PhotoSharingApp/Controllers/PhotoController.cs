using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Globalization;
using PhotoSharingApp.Model;
using System.Net;
using System.IO;

namespace PhotoSharingApp.Controllers
{
    public class PhotoController : Controller
    {
        private PhotoSharingContext context = new PhotoSharingContext();
        // GET: Photo
        public ViewResult Index()
        {
            return View("Index",context.Photos.ToList());
        }

        public ActionResult Display(int? id)
        {
            
            Photo photo = context.Photos.Find(id);
            if (photo == null)
            {
                return HttpNotFound();
            }
            return View("Display", photo);
        }

        public ActionResult Create()
        {
            Photo photo = new Model.Photo();
            photo.CreatedDate = DateTime.Today;
            return View("Create", photo);
        }
        [HttpPost]
        public ActionResult Create(Photo photo, HttpPostedFileBase image)
        {
            photo.CreatedDate = DateTime.Today;
            if (ModelState.IsValid)
            {
                context.Photos.Add(photo);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                if(image != null)
                {
                    photo.ImageMimeType = image.ContentType;
                    photo.PhotoFile = new byte[image.ContentLength];
                    image.InputStream.Read(photo.PhotoFile,0,image.ContentLength);
                    
                }

                context.Photos.Add(photo);
                context.SaveChanges();
                return View("Create", photo);
            }
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Photo photo = context.Photos.Find(id);
            if (photo == null)
            {
                return HttpNotFound();
            }
            return View("Delete",photo);
        }
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Photo photo = context.Photos.Find(id);
            context.Photos.Remove(photo);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public FileContentResult GetImage(int? id)
        {
            Photo photo = context.Photos.Find(id);
            if(photo != null)
            {
                return   File(photo.PhotoFile, photo.ImageMimeType);
            }
            else 
            return null;
            

        }


    }
}