namespace Stud_io.Dormitory.Models
{
    public class Questionnaire
    {
        public int Id { get; set; }
        public Boolean shareBelongings { get; set; }
        public string sleepingHabits { get; set; } = null!;
        public Boolean havingGuests { get; set; }
        public string roomCleanliness { get; set; } = null!;
        public string studyTime { get; set; } = null!;
        public string studyPlace { get; set; } = null!;

    }
}
