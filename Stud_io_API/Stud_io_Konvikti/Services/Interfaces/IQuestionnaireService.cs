using Microsoft.AspNetCore.Mvc;
using Stud_io.Dormitory.DTOs;

namespace Stud_io.Dormitory.Services.Interfaces
{
    public interface IQuestionnaireService
    {
        public Task<ActionResult<List<QuestionnaireDto>>> GetQuestionnaires();
        public Task<ActionResult<QuestionnaireDto>> GetQuestionnaireById(int id);
    }
}
