using Microsoft.EntityFrameworkCore;
using Stud_io.Application.Configurations;
using Stud_io.Application.Factory;
using Stud_io.Application.Models;
using Stud_io.Application.Services.Interfaces;

namespace Stud_io.Application.Services.Implementations
{
    public class FileService : IFileService
    {
        private readonly ApplicationDbContext _context;

        public FileService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<FileDetails> PostFileAsync(IFormFile fileData)
        {
            try
            {
                //Factory pattern usage

                FileDetails fileDetails = FileFactory.CreateFileDetails(fileData);

                fileDetails.Modify(fileData);

                using (var stream = new MemoryStream())
                {
                    fileData.CopyTo(stream);
                    fileDetails.FileData = stream.ToArray();
                }

                var result = _context.FileDetails.Add(fileDetails);
                await _context.SaveChangesAsync();
                return fileDetails;
            }
            catch (Exception)
            {
                throw;
            }

        }



        public async Task DownloadFileById(int Id)
        {
            try
            {
                var file = await _context.FileDetails.FirstOrDefaultAsync(x => x.ID == Id);

                if (file != null)
                {
                    var content = new MemoryStream(file.FileData);
                    var path = Path.Combine(
                        Directory.GetCurrentDirectory(), "FileDownloaded",
                        file.FileName);

                    await CopyStream(content, path);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task CopyStream(Stream stream, string downloadPath)
        {
            using (var fileStream = new FileStream(downloadPath, FileMode.Create, FileAccess.Write))
            {
                await stream.CopyToAsync(fileStream);
            }
        }

        public FileDetails GetFileById(int fileId)
        {
            return _context.FileDetails.FirstOrDefault(s => s.ID == fileId);
        }

        public List<FileDetails> GetAll()
        {
            return _context.FileDetails.ToList();
        }
    }
}
