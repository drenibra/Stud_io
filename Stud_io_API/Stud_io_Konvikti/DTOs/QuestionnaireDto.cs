namespace Stud_io.Dormitory.DTOs
{
    public class QuestionnaireDto
    {
        public Boolean shareBelongings { get; set; }
        public string sleepingHabits { get; set; } = null!;
        public Boolean havingGuests { get; set; }
        public string roomCleanliness { get; set; } = null!;
        public string studyTime { get; set; } = null!;
        public string studyPlace { get; set; } = null!;
        public string Token { get; set; }
    }

    public class UpdateQuestionnaireDto
    {
        public Boolean? shareBelongings { get; set; }
        public string? sleepingHabits { get; set; } 
        public Boolean? havingGuests { get; set; }
        public string? roomCleanliness { get; set; }
        public string? studyTime { get; set; } 
        public string? studyPlace { get; set; }

    }
}
