namespace hw_25._10._24
{
    public interface IFileService
    {
        Task<string?> SaveFile(IFormFile file);

        Task DeleteFile(string path);
    }
}
