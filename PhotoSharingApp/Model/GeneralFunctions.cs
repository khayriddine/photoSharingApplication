using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoSharingApp.Model
{
    public class GeneralFunctions
    {
        public static byte[] getPhotoFileByName(string filename)
        {
            return System.IO.File.ReadAllBytes(filename);

        }
    }
}