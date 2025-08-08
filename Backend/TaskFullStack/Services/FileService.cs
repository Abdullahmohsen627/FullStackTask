using TaskFullStack.IServices;

namespace TaskFullStack.Services
{
    public class FileService:IFileService
    {
        #region Field
        private readonly IWebHostEnvironment _env;
        private readonly string webRootPath;
        #endregion

        #region Constructor
        public FileService(IWebHostEnvironment env)
        {
            _env = env;
            webRootPath = _env.WebRootPath ?? Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
        }
        #endregion
        public string UploadLogo(IFormFile file)
        {
            string extension = Path.GetExtension(file.FileName);
            var uploadsFolder = Path.Combine(webRootPath, "uploads", "images");
            Directory.CreateDirectory(uploadsFolder);
            string filename = Guid.NewGuid().ToString() + extension;
            string path = Path.Combine(uploadsFolder,filename);
            using FileStream stream = new FileStream(path,FileMode.Create);
            file.CopyTo(stream);
            return filename;
        }
    }
}
