using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stud_io.Dormitory.DTOs;
using Stud_io.Dormitory.Services.Interfaces;
using Stud_io_Dormitory.Configurations;

namespace Stud_io.Dormitory.Services.Implementations
{
    public class QuestionnaireService : IQuestionnaireService
    {
        private readonly DormitoryDbContext _context;
        private readonly IMapper _mapper;

        public QuestionnaireService(DormitoryDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ActionResult<List<QuestionnaireDto>>> GetQuestionnaires() =>
            _mapper.Map<List<QuestionnaireDto>>(await _context.Questionnaires.ToListAsync());

        public async Task<ActionResult<QuestionnaireDto>> GetQuestionnaireById(int id)
        {
            var mappedQuestionnaire = _mapper.Map<QuestionnaireDto>(await _context.Questionnaires.FindAsync(id));
            return mappedQuestionnaire == null
                ? new NotFoundObjectResult("Questionnaire doesn't exist!!")
                : new OkObjectResult(mappedQuestionnaire);
        }
    }
}
