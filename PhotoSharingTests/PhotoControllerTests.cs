using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Web.Mvc;
using PhotoSharingApp.Model;
using PhotoSharingApp.Controllers;
using System.Linq;
using PhotoSharingTests.Doubles;

namespace PhotoSharingTests
{
    [TestClass]
    public class PhotoControllerTests
    {
        [TestMethod]
        public void Test_Index_Return_View()
        {
            var context = new FakePhotoSharingContext();
            var controller = new PhotoController(context);
            var result = controller.Index() as ViewResult;
            Assert.AreEqual("Index",  result.ViewName);
        }
        [TestMethod]
        public void Test_PhotoGallery_Model_Type()
        {
            var context = new FakePhotoSharingContext();
            context.Photos = new[] {
            new Photo(),
            new Photo(),
            new Photo(),
            new Photo()
            }.AsQueryable();
            var controller = new PhotoController(context);
        }
        [TestMethod]
        public void Test_GetImage_Return_Type()
        {
            var context = new FakePhotoSharingContext();
            context.Photos = new[] {
            new Photo{ PhotoID = 1, PhotoFile = new byte[1], ImageMimeType = "image/jpeg" },
            new Photo{ PhotoID = 2, PhotoFile = new byte[1], ImageMimeType = "image/jpeg" },
            new Photo{ PhotoID = 3, PhotoFile = new byte[1], ImageMimeType = "image/jpeg" },
            new Photo{ PhotoID = 4, PhotoFile = new byte[1], ImageMimeType = "image/jpeg" }
            }.AsQueryable();
            var controller = new PhotoController(context);
        }
    }
}
