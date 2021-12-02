using Core.Entites;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Core.Interfaces;

namespace Infrastructure.Services
{
    public class PictureService : IPictureService
    {
        private readonly IUnitOfWork unitOfWork;

        public PictureService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<string> UploadPictureAsync(IFormFile formFile, string WebRootPath = "", string defaultFileName = "", string virtualPath = "")
        {
            var imgExt = new List<string>
            {
                ".bmp",
                ".gif",
                ".webp",
                ".jpeg",
                ".jpg",
                ".jpe",
                ".jfif",
                ".pjpeg",
                ".pjp",
                ".png",
                ".tiff",
                ".tif"
            } as IReadOnlyCollection<string>;
             
            
            //added image to upload folder//
            var fileName = formFile.FileName;
            if (string.IsNullOrEmpty(fileName) && !string.IsNullOrEmpty(defaultFileName))
                fileName = defaultFileName;
            string fullPath = "";
            if (!string.IsNullOrEmpty(formFile.Name))
            {
                string uploads = Path.Combine(WebRootPath, "uploads");
                fileName = Guid.NewGuid() + Path.GetExtension(formFile.FileName).ToLower();
                fullPath = Path.Combine(uploads, fileName);
                formFile.CopyToAsync(new FileStream(fullPath, FileMode.Create));
            }

            
            //var category = _mapper.Map<Category>(model);
            //_unitOfWork.Category.Add(category);

            //remove path (passed in IE)
            //fileName = _fileProvider.GetFileName(fileName);

            //var contentType = formFile.ContentType;

            //var fileExtension = _fileProvider.GetFileExtension(fileName);
            //if (!string.IsNullOrEmpty(fileExtension))
            //    fileExtension = fileExtension.ToLowerInvariant();

            //if (imgExt.All(ext => !ext.Equals(fileExtension, StringComparison.CurrentCultureIgnoreCase)))
            //    return null;

            //contentType is not always available 
            //that's why we manually update it here
            ////http://www.sfsu.edu/training/mimetype.htm
            //if (string.IsNullOrEmpty(contentType))
            //{
            //    switch (fileExtension)
            //    {
            //        case ".bmp":
            //            contentType = MimeTypes.ImageBmp;
            //            break;
            //        case ".gif":
            //            contentType = MimeTypes.ImageGif;
            //            break;
            //        case ".jpeg":
            //        case ".jpg":
            //        case ".jpe":
            //        case ".jfif":
            //        case ".pjpeg":
            //        case ".pjp":
            //            contentType = MimeTypes.ImageJpeg;
            //            break;
            //        case ".webp":
            //            contentType = MimeTypes.ImageWebp;
            //            break;
            //        case ".png":
            //            contentType = MimeTypes.ImagePng;
            //            break;
            //        case ".tiff":
            //        case ".tif":
            //            contentType = MimeTypes.ImageTiff;
            //            break;
            //        default:
            //            break;
            //    }
            //}

            //var picture = await InsertPictureAsync(await _downloadService.GetDownloadBitsAsync(formFile), contentType, _fileProvider.GetFileNameWithoutExtension(fileName));

            //if (string.IsNullOrEmpty(virtualPath))
            //    return picture;

            //picture.VirtualPath = _fileProvider.GetVirtualPath(virtualPath);
            //await UpdatePictureAsync(picture);

            return fileName;
        }
    }
}
