using Stud_io.Application.Models;

namespace Stud_io.Application.Factory
{
    public class FileFactory
    {
        // RIP pattern
        private static Dictionary<string, FileDetails> FilesDictionary =
            new Dictionary<string, FileDetails>()
            {
                {"application/pdf", new PDF() },
                { "image/png", new PNG()}
            };
        //factory pattern
        public static FileDetails CreateFileDetails(IFormFile fileData)
        {
            return FilesDictionary[fileData.ContentType];


            /* if (fileData.ContentType.Equals("application/pdf"))
             {
                 return new PDF()
                 {
                     ID = 0,
                     FileName = fileData.FileName,
                 };
             }
             else if (fileData.ContentType.Equals("image/png"))
             {
                 return new PNG()
                 {
                     ID = 1,
                     FileName = fileData.FileName,
                 };
             }
             else
             {
                 throw new Exception("Unsupported file type.");
             }
            */
        }
    }
}
