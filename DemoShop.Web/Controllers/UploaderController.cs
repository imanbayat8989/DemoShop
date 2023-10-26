using DemoShop.Application.Extensions;
using DemoShop.Application.Utils;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DemoShop.Web.Controllers
{
    public class UploaderController : SiteBaseController
    {
        [HttpPost]
        public IActionResult UploadImage(IFormFile upload, string CKEditorFuncName, string CKEditor, string langCode)
        {
            if (upload.Length <= 0) return null;
            if (!upload.IsImage())
            {
                var notImageMessage = "لطفا یک تصویر انتخاب کنید";
                var notImage = JsonConvert.DeserializeObject("{'uploaded':0, 'error': {'message': \" " + notImageMessage + " \"}}");
                return Json(notImage);
            }

            var fileName = Guid.NewGuid() + Path.GetExtension(upload.FileName).ToLower();
            upload.AddImageToServer(fileName, PathExtensions.UploadImageServer, null, null);
            return Json(new
            {
                uploaded = true,
                url = $"{PathExtensions.UploadImage}{fileName}"
            });
        }
    }
}
