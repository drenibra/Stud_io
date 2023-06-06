using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using Stud_io.StudyGroups.Services.Interfaces;

namespace Stud_io.StudyGroups.Services.Implementation
{
    public class CloudinaryService : ICloudinaryService
    {
        private readonly IConfiguration _configuration;

        public CloudinaryService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //if upload fails it returns an empty string
        public async Task<string> UploadFile(IFormFile file)
        {
            var fileUrl = "";

            if (file == null)
                return fileUrl;

            var cloudinaryConfig = new Account(
                    _configuration["CloudinarySettings:CloudName"],
                    _configuration["CloudinarySettings:ApiKey"],
                    _configuration["CloudinarySettings:ApiSecret"]
                );

            var cloudinary = new Cloudinary(cloudinaryConfig);
            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(file.FileName, file.OpenReadStream())
            };

            var uploadResult = await cloudinary.UploadAsync(uploadParams);
            if (uploadResult.Error != null)
                return fileUrl;

            fileUrl = uploadResult.SecureUrl.ToString();
            return fileUrl;
        }

    }
}
