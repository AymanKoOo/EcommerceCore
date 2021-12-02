using Core.Entites;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public interface IPictureService
    {
        public Task<string> UploadPictureAsync(IFormFile formFile, string WebRootPath = "", string defaultFileName = "", string virtualPath = "");
    }
}
