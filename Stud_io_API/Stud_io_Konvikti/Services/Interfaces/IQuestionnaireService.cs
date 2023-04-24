using Microsoft.AspNetCore.Mvc;
using Stud_io.Dormitory.DTOs;
using Stud_io.Dormitory.Models;

namespace Stud_io.Dormitory.Services.Interfaces
{
    public interface IQuestionnaireService
    {
        public Task<ActionResult<List<QuestionnaireDto>>> GetQuestionnaires();
        public Task<ActionResult<QuestionnaireDto>> GetQuestionnaireById(int id);
        public Task<ActionResult> AddQuestionnaire(QuestionnaireDto questionnaireDTO);
        public Task<ActionResult> UpdateQuestionnaire(int id, UpdateQuestionnaireDto updateQuestionnaireDTO);
        public Task<ActionResult> DeleteQuestionnaire(int id);
        public int CalculateCompatibility(int q1Id, int q2Id);
    }
}
