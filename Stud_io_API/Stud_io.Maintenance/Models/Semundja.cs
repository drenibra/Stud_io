namespace Stud_io.Maintenance.Models
{
    public class Semundja
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SpecializimiId { get; set; }
        public Specializimi Specializimi { get; set; }
    }
}