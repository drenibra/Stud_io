using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stud_io.Application.Configurations;
using Stud_io.Application.Models;
using Stud_io.Application.Services.Interfaces;

namespace Stud_io.Application.Services.Implementations
{
    public class ProfileMatchService : IProfileMatchService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ProfileMatchService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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
                switch (category)
                {
                    case "Student(femije) i deshmorit":
                        extraPoints = 10;
                        break;
                    case "Student me aftesi te kufizuara":
                        extraPoints = 6;
                        break;
                    case "Student(femije) i prindit invalid te luftes":
                    case "Student i te pagjeturit":
                    case "Student invalid civil i luftes":
                        extraPoints = 5;
                        break;
                    case "Student me asistence sociale":
                    case "Student i prindit martir nga lufta":
                    case "Student i te burgosurit politik":
                        extraPoints = 4;
                        break;
                    case "Dy e me shume student nga nje familje aplikant ne QS":
                    case "Student, prindi i te cilit eshte veteran i luftes":
                        extraPoints = 3;
                        break;
                    default:
                        extraPoints = 0;
                        break;

                }
            }
            return extraPoints;
        }

        public int CalculateCityPoints(string city)
        {
            int cityPoints = 0;

            if (!string.IsNullOrEmpty(city))
            {
                switch (city)
                {
                    case "Gjilan":
                    case "Viti":
                        cityPoints = 4;
                        break;
                    case "Gjakove":
                    case "Decan":
                        cityPoints = 9;
                        break;
                    case "Peje":
                    case "Istog":
                        cityPoints = 8;
                        break;
                    case "Kamenice":
                    case "Prizren":
                        cityPoints = 7;
                        break;
                    case "Kline":
                    case "Suhareke":
                        cityPoints = 6;
                        break;
                    case "Rahovec":
                    case "Skenderaj":
                        cityPoints = 5;
                        break;
                    case "Podujeve":
                    case "Ferizaj":
                    case "Mitrovice":
                        cityPoints = 3;
                        break;
                    case "Lipjan":
                    case "Vushtrri":
                        cityPoints = 2;
                        break;
                    default:
                        cityPoints = 0;
                        break;
                }
            }

            return cityPoints;
        }

        public async Task<List<ProfileMatch>> CalculateTotalPointsForAllStudents()
        {
            var applications = await _context.Applications
                                         .Include(s => s.Student)
                                         .Include(f => f.Student.Faculty)
                                         .ToListAsync();

            foreach (var application in applications)
            {
                var profileMatch = await _context.ProfileMatches
                    .FirstOrDefaultAsync(p => p.ApplicationId == application.Id);

                if (profileMatch == null)
                {
                    profileMatch = new ProfileMatch()
                    {
                        ApplicationId = application.Id,
                        PointsForGPA = CalculateAverageGradePoints(application.Student.GPA),
                        PointsForCity = CalculateCityPoints(application.Student.City),
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
                .Include(s => s.Application.Student)
                .Include(f => f.Application.Student.Faculty)
                .OrderByDescending(p => p.TotalPoints)
                .ToListAsync();
        }

        public async Task<List<ProfileMatch>> GetTopProfileMatches()
        {
            var sortedProfileMatches = await SortByTotalPoints();
            return sortedProfileMatches.Take(10).ToList();
        }

    }
}