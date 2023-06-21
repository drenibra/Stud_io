namespace Stud_io.Maintenance.Models
{
    public class Specializimi
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Semundja> Semundjet { get; set; } = new List<Semundja>();
    }
}
