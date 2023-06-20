using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stud_io.Dormitory.DTOs;
using Stud_io.Dormitory.DTOs.Deserializer;
using Stud_io.Dormitory.Models;
using Stud_io.Dormitory.Services.Interfaces;
using Stud_io_Dormitory.Configurations;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace Stud_io.Dormitory.Services.Implementations
{
    public class QuestionnaireService : IQuestionnaireService
    {
        private readonly DormitoryDbContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpClientFactory _httpClientFactory;

        public QuestionnaireService(DormitoryDbContext context, IMapper mapper, IHttpClientFactory httpClientFactory)
        {
            _context = context;
            _mapper = mapper;
            _httpClientFactory = httpClientFactory;
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
                   var httpClient = _httpClientFactory.CreateClient();

                   var uri = "http://localhost:5274/api/v1/User/GetStudentById";

                   //Dreni to handle the token

                   var authentication = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiJlNjZiZDg2ZS1lMmQ0LTRkMGMtYWYwMC04NjkzZjgxMzA1ZmIiLCJ1bmlxdWVfbmFtZSI6InN1bWVqYSIsImVtYWlsIjoic3VtZWphQGdtYWlsLmNvbSIsInJvbGUiOiJTdHVkZW50IiwibmJmIjoxNjg3MjM3NTAwLCJleHAiOjE2ODc4NDIzMDAsImlhdCI6MTY4NzIzNzUwMH0.QNdRVPnro4fLJJG-a2kX0QRDmdV6n_oiq3MffIijDF4");
                   httpClient.DefaultRequestHeaders.Authorization = authentication;

                   var response = await httpClient.GetAsync(uri);

                   var responseAsString = await response.Content.ReadAsStringAsync();

                   var student = JsonSerializer.Deserialize<QuestionnaireStudentDto>(responseAsString);

                   if (questionnaireDTO == null)
                       return new BadRequestObjectResult("Questionnaire can not be null!!");

                    var questionnaire = new Questionnaire()
                    {
                        shareBelongings = questionnaireDTO.shareBelongings,
                        sleepingHabits = questionnaireDTO.sleepingHabits,
                        havingGuests = questionnaireDTO.havingGuests,
                        roomCleanliness = questionnaireDTO.roomCleanliness,
                        studyTime = questionnaireDTO.studyTime,
                        studyPlace = questionnaireDTO.studyPlace,
                        studentId = student.id
                    };


                   await _context.Questionnaires.AddAsync(questionnaire);
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



        private static readonly Dictionary<string, int> PropertyWeights = new Dictionary<string, int>
        {
            { nameof(Questionnaire.shareBelongings), 10 },
            { nameof(Questionnaire.sleepingHabits), 10 },
            { nameof(Questionnaire.havingGuests), 10 },
            { nameof(Questionnaire.roomCleanliness), 10 },
            { nameof(Questionnaire.studyTime), 10 },
            { nameof(Questionnaire.studyPlace), 10 }
        };

        // calculating compatibility between questionnaires
        public int CalculateCompatibility(int q1Id, int q2Id)
        {
            var q1 = _context.Questionnaires.FirstOrDefault(q => q.Id == q1Id);
            var q2 = _context.Questionnaires.FirstOrDefault(q => q.Id == q2Id);
            if (q1 == null || q2 == null)
            {
                throw new ArgumentException("Invalid questionnaire id");
            }

            int score = 0;

            foreach (var property in typeof(Questionnaire).GetProperties())
            {
                if (PropertyWeights.TryGetValue(property.Name, out int weight))
                {
                    if (property.GetValue(q1) is string q1Value && property.GetValue(q2) is string q2Value)
                    {
                        if (string.Equals(q1Value, q2Value))
                        {
                            score += weight;
                        }
                    }
                    else if (property.GetValue(q1) is bool q1BoolValue && property.GetValue(q2) is bool q2BoolValue)
                    {
                        if (q1BoolValue == q2BoolValue)
                        {
                            score += weight;
                        }
                    }
                }
            }

            return score;
        }

        public int FindBestMatch(int studentQuestionnaireId)
        {
            var studentQuestionnaire = _context.Questionnaires.FirstOrDefault(q => q.Id == studentQuestionnaireId);
            if (studentQuestionnaire == null)
            {
                throw new ArgumentException("Invalid questionnaire id");
            }

            int bestMatchId = -1;
            int highestCompatibilityScore = -1;

            var otherQuestionnaires = _context.Questionnaires
                .Where(q => q.Id != studentQuestionnaireId) // Exclude the student's own questionnaire
                .AsNoTracking()
                .ToList();

            foreach (var otherQuestionnaire in otherQuestionnaires)
            {
                int compatibilityScore = CalculateCompatibility(studentQuestionnaireId, otherQuestionnaire.Id);

                if (compatibilityScore > highestCompatibilityScore)
                {
                    highestCompatibilityScore = compatibilityScore;
                    bestMatchId = otherQuestionnaire.Id;
                }
            }

            return bestMatchId;
        }
    }
}
