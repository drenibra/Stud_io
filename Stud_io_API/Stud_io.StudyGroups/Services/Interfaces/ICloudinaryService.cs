namespace Stud_io.StudyGroups.Services.Interfaces
{
    public interface ICloudinaryService
    {
        Task<string> UploadFile(IFormFile file);
    }
}
