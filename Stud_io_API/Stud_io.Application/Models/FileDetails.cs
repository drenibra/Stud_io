namespace Stud_io.Application.Models
{
    public class FileDetails
    {
        public int ID { get; set; }
        public string FileName { get; set; } = null!;
        public byte[] FileData { get; set; } = null!;

        public virtual void Modify(IFormFile file) { }
    }
}
