using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stud_io.Dormitory.DTOs;
using Stud_io.Dormitory.Services.Interfaces;

namespace Stud_io.Dormitory.Controllers
{
    [Route("")]
    [ApiController]
    public class QuestionnaireController : ControllerBase
    {
        private readonly IQuestionnaireService _questionnaireService;

        public QuestionnaireController(IQuestionnaireService questionnaireService)
        {
            _questionnaireService = questionnaireService;
        }

        [HttpGet("GetQuestionnaires")]
        public async Task<ActionResult<List<QuestionnaireDto>>> GetQuestionnaires()
        {
            return await _questionnaireService.GetQuestionnaires();
        }

        [HttpGet("GetQuestionnaireById/{id}")]
        public async Task<ActionResult<QuestionnaireDto>> GetQuestionnaireById(int id)
        {
            return await _questionnaireService.GetQuestionnaireById(id);
        }

        [HttpPost("AddQuestionnaire")]
        public async Task<ActionResult> AddQuestionnaire(QuestionnaireDto questionnaireDto)
        {
            return await _questionnaireService.AddQuestionnaire(questionnaireDto);
        }

        [HttpPut("UpdateQuestionnaire")]
        public async Task<ActionResult> UpdateQuestionnaire(int id, UpdateQuestionnaireDto questionnaireDto)
        {
            return await _questionnaireService.UpdateQuestionnaire(id, questionnaireDto);
        }


        [HttpDelete("DeleteQuestionnaire/{id}")]
        public async Task<ActionResult> DeleteQuestionnaire(int id)
        {
            return await _questionnaireService.DeleteQuestionnaire(id);
        }
    }
}
