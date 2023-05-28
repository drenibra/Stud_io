using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<int> CalculateAverageGradePoints(double averageGrade)
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

        public async Task<int> CalculateExtraPoints(string category)
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

        
    }
}
