﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Globalization;
using PhotoSharingApp.Model;
using System.Net;
using System.IO;
using System.Diagnostics;

namespace PhotoSharingApp.Controllers
{
    [ValueReporter]
    public class PhotoController : Controller
    {
        private PhotoSharingContext context = new PhotoSharingContext();
        // GET: Photo
        public ViewResult Index()
        {
            return View("Index");
        }

        public ActionResult Display(int id)
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
                // context.Photos.Add(photo);
                //context.SaveChanges();
                //return RedirectToAction("Index");
                //}
                // else
                //{
                if (image != null)
                {
                    photo.ImageMimeType = image.ContentType;
                    photo.PhotoFile = new byte[image.ContentLength];
                    image.InputStream.Read(photo.PhotoFile, 0, image.ContentLength);
                }

                context.Photos.Add(photo);
                context.SaveChanges();
                
            }
            return RedirectToAction("Index");
        }
    //}
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
            return View("Index");
        }
        public FileContentResult GetImage(int id)
        {
            Photo photo = context.Photos.Find(id);
            if(photo != null)
            {
                return   new FileContentResult(photo.PhotoFile, photo.ImageMimeType);
            }
            else 
            return null;
            

        }
        [ChildActionOnly]
        public ActionResult  _PhotoGallery(int number =0)
        {
            List<Photo> photos;
            if (number == 0)
            {
                photos = context.Photos.ToList();
            }
            else
            {
                photos = (
                 from p in context.Photos
                 orderby p.CreatedDate descending
                 select p).Take(number).ToList();
            }
            return PartialView(photos);
        }


    }
}