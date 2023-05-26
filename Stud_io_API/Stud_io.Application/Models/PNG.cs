namespace Stud_io.Application.Models
{
    public class PNG : FileDetails
    {
        public DateTime DateUploaded { get; set; } = DateTime.Now;
        public override void Modify(IFormFile file)
        {
            ID = 0;
            FileName = file.FileName;

        }
    }
}
