using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stud_io.Application.Configurations;
using Stud_io.Application.DTOs.Deserializer;
using Stud_io.Application.Models;
using Stud_io.Application.Services.Interfaces;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace Stud_io.Application.Services.Implementations
{
    public class ProfileMatchService : IProfileMatchService
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpClientFactory _httpClientFactory;

        public ProfileMatchService(ApplicationDbContext context, IHttpClientFactory httpClientFactory)
        {
            _context = context;
            _httpClientFactory = httpClientFactory;
        }

        public int CalculateAverageGradePoints(double averageGrade)
        {
            int averageGradePoints;
            if (averageGrade >= 6.00 && averageGrade <= 6.99)
            {
                averageGradePoints = 1;
            }
            else if (averageGrade >= 7.00 && averageGrade <= 7.99)
            {
                averageGradePoints = 2;
            }
            else if (averageGrade >= 8.00 && averageGrade <= 8.99)
            {
                averageGradePoints = 3;
            }
            else if (averageGrade >= 9.00 && averageGrade <= 10.00)
            {
                averageGradePoints = 4;
            }
            else
            {
                averageGradePoints = 1;
            }
            return averageGradePoints;
        }

        public int CalculateExtraPoints(string category)
        {
            int extraPoints = 0;
            if (!string.IsNullOrEmpty(category))
            {
                extraPoints = category switch
                {
                    "Student(femije) i deshmorit" => 10,
                    "Student me aftesi te kufizuara" => 6,
                    "Student(femije) i prindit invalid te luftes" or "Student i te pagjeturit" or "Student invalid civil i luftes" => 5,
                    "Student me asistence sociale" or "Student i prindit martir nga lufta" or "Student i te burgosurit politik" => 4,
                    "Dy e me shume student nga nje familje aplikant ne QS" or "Student, prindi i te cilit eshte veteran i luftes" => 3,
                    _ => 0,
                };
            }
            return extraPoints;
        }

        public int CalculateCityPoints(string city)
        {
            int cityPoints = 0;

            if (!string.IsNullOrEmpty(city))
            {
                cityPoints = city switch
                {
                    "Gjilan" or "Viti" => 4,
                    "Gjakove" or "Decan" => 9,
                    "Peje" or "Istog" => 8,
                    "Kamenice" or "Prizren" => 7,
                    "Kline" or "Suhareke" => 6,
                    "Rahovec" or "Skenderaj" => 5,
                    "Podujeve" or "Ferizaj" or "Mitrovice" => 3,
                    "Lipjan" or "Vushtrri" => 2,
                    _ => 0,
                };
            }
            return cityPoints;
        }

        public async Task<List<ProfileMatch>> GetMatches()
        {
            var matches = await _context.ProfileMatches.Include(a => a.Application).ToListAsync();
            return matches;
        }

        public async Task<ActionResult<List<ProfileMatch>>> CalculateTotalPointsForAllStudents(string token)
        {
            var httpClient = _httpClientFactory.CreateClient();

            var applications = await _context.Applications.ToListAsync();

            foreach (var application in applications)
            {
                var profileMatch = await _context.ProfileMatches
                    .FirstOrDefaultAsync(p => p.ApplicationId == application.Id);

                var uri = "http://localhost:5274/api/v1/User/GetStudentById/" + application.StudentId;

                var authentication = new AuthenticationHeaderValue("Bearer", token);
                httpClient.DefaultRequestHeaders.Authorization = authentication;

                var response = await httpClient.GetAsync(uri);
                var responseAsString = await response.Content.ReadAsStringAsync();

                var student = JsonSerializer.Deserialize<StudentProfileDeserializer>(responseAsString);

                if (profileMatch == null)
                {
                    profileMatch = new ProfileMatch()
                    {
                        ApplicationId = application.Id,
                        PointsForGPA = CalculateAverageGradePoints((double)student.gpa),
                        PointsForCity = CalculateCityPoints(student.city),
                        ExtraPoints = CalculateExtraPoints(application.SpecialCategoryReason)
                    };
                    profileMatch.TotalPoints = profileMatch.PointsForCity + profileMatch.PointsForGPA + profileMatch.ExtraPoints;

                    _context.ProfileMatches.Add(profileMatch);
                }
                await _context.SaveChangesAsync();
            }
            return await _context.ProfileMatches.ToListAsync();
        }

        public async Task<List<ProfileMatch>> SortByTotalPoints()
        {
            return await _context.ProfileMatches
                .Include(a => a.Application)
                .OrderByDescending(p => p.TotalPoints)
                .ToListAsync();
        }

        public async Task<List<ProfileMatch>> GetTopProfileMatches()
        {
            var sortedProfileMatches = await SortByTotalPoints();
            foreach(var profileMatch in sortedProfileMatches)
            {
                var student = profileMatch.Application.StudentId;

                await SetIsAcceptedById(student, true);
            }
            return sortedProfileMatches.Take(4).ToList();
        }

        private async Task SetIsAcceptedById(string id, bool isAccepted)
        {
            var httpClient = _httpClientFactory.CreateClient();

            var uri = "http://localhost:5274/api/v1/User/set-is-accepted/" + id + "/" + isAccepted;

            var authentication = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiI1OWEyNGUxNS1iNTIyLTRmNTItYTQ1ZS1kNTRiMGEyMmY5NDMiLCJ1bmlxdWVfbmFtZSI6ImZhdGkiLCJlbWFpbCI6ImZzNTE3MDFAdWJ0LXVuaS5uZXQiLCJyb2xlIjoiQWRtaW4iLCJuYmYiOjE2ODcyNjEzMzksImV4cCI6MTY4Nzg2NjEzOSwiaWF0IjoxNjg3MjYxMzM5fQ.0M33QBcyJEskjvU44EP8AGr8gfwSP4JiTbKtcGPS0QE");
            httpClient.DefaultRequestHeaders.Authorization = authentication;

            var content = new StringContent("", Encoding.UTF8, "application/json");

            await httpClient.PutAsync(uri, content);
        }

        public async Task<List<ProfileMatch>> GetLastProfileMatches()
        {
            var sortedProfileMatches = await SortByTotalPoints();
            var lastMatches = sortedProfileMatches.Skip(4).ToList();
            foreach (var profileMatch in lastMatches)
            {
                var student = profileMatch.Application.StudentId;

                await SetIsAcceptedById(student, false);
            }
            return lastMatches;
        }
    }
}