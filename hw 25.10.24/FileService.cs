
namespace hw_25._10._24
{
    public class FileService : IFileService
    {
        // Const variables for generations of paths
        private const string WWWROOT_NAME = "wwwroot";
        private const string DIRECTORY_NAME = "UploadedFiles";

        public async Task<string?> SaveFile(IFormFile file)
        {
            if (file is null || file.Length == 0)
                return null;

            string directoryPath = Path.Combine(Directory.GetCurrentDirectory(), WWWROOT_NAME, DIRECTORY_NAME);

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            // Giving new unique file name
            string pictureNewName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

            string absolutePath = Path.Combine(directoryPath, pictureNewName);

            using (FileStream stream = new FileStream(absolutePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
                await stream.FlushAsync();
            }

            // Path of stored picture starting from /wwwroot/
            return Path.Combine("/", DIRECTORY_NAME, pictureNewName);
        }


        public Task DeleteFile(string path)
        {
            string absolutePath = Path.Combine(Directory.GetCurrentDirectory(), WWWROOT_NAME, path.Substring(1));

            if (File.Exists(absolutePath))
            {
                File.Delete(absolutePath);
            }

            return Task.CompletedTask;
        }
    }
}
