﻿using Microsoft.AspNetCore.Mvc;
using Stud_io.Application.DTOs;
using Stud_io.Application.Models;

namespace Stud_io.Application.Services.Interfaces
{
    public interface IProfileMatchService
    {
        
        public Task<int> CalculateAverageGradePoints(double averageGrade);
        public Task<int> CalculateExtraPoints(string category);

    }
}
