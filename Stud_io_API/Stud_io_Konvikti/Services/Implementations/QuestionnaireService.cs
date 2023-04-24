using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stud_io.Dormitory.DTOs;
using Stud_io.Dormitory.Models;
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
        public async Task<ActionResult> AddQuestionnaire(QuestionnaireDto questionnaireDTO)
        {
            if (questionnaireDTO == null)
                return new BadRequestObjectResult("Questionnaire can not be null!!");
            var mappedQuestionnaire = _mapper.Map<Questionnaire>(questionnaireDTO);
            await _context.Questionnaires.AddAsync(mappedQuestionnaire);
            await _context.SaveChangesAsync();
            return new OkObjectResult("Questionnaire added successfully!");
        }

        public async Task<ActionResult> UpdateQuestionnaire(int id, UpdateQuestionnaireDto updateQuestionnaireDTO)
        {
            if (updateQuestionnaireDTO == null)
                return new BadRequestObjectResult("Questionnaire can not be null!!");

            var dbQuestionnaire = await _context.Questionnaires.FindAsync(id);
            if (dbQuestionnaire == null)
                return new NotFoundObjectResult("Questionnaire doesn't exist!!");

            dbQuestionnaire.shareBelongings = updateQuestionnaireDTO.shareBelongings ?? dbQuestionnaire.shareBelongings;
            dbQuestionnaire.sleepingHabits = updateQuestionnaireDTO.sleepingHabits ?? dbQuestionnaire.sleepingHabits;
            dbQuestionnaire.havingGuests = updateQuestionnaireDTO.havingGuests ?? dbQuestionnaire.havingGuests;
            dbQuestionnaire.roomCleanliness = updateQuestionnaireDTO.roomCleanliness ?? dbQuestionnaire.roomCleanliness;
            dbQuestionnaire.studyTime = updateQuestionnaireDTO.studyTime ?? dbQuestionnaire.studyTime;
            dbQuestionnaire.studyPlace = updateQuestionnaireDTO.studyPlace ?? dbQuestionnaire.studyPlace;
            await _context.SaveChangesAsync();

            return new OkObjectResult("Questionnaire updated successfully!");
        }

        public async Task<ActionResult> DeleteQuestionnaire(int id)
        {
            var dbQuestionnaire = await _context.Questionnaires.FindAsync(id);
            if (dbQuestionnaire == null)
                return new NotFoundObjectResult("Questionnaire doesn't exist!!");

            _context.Questionnaires.Remove(dbQuestionnaire);
            await _context.SaveChangesAsync();
            return new OkObjectResult("Questionnaire deleted successfully!");
        }
    }
}
