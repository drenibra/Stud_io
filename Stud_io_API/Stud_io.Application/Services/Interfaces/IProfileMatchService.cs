﻿using Microsoft.AspNetCore.Mvc;
using Stud_io.Application.DTOs;
using Stud_io.Application.Models;

namespace Stud_io.Application.Services.Interfaces
{
    public interface IProfileMatchService
    {

        public int CalculateAverageGradePoints(double averageGrade);
        public int CalculateExtraPoints(string category);
        public int CalculateCityPoints(string city);
        public Task<List<ProfileMatch>> GetMatches();
        public Task<ActionResult<List<ProfileMatch>>> CalculateTotalPointsForAllStudents(string token);
        public Task<List<ProfileMatch>> SortByTotalPoints();
        public Task<List<ProfileMatch>> GetTopProfileMatches();
        public Task<List<ProfileMatch>> GetLastProfileMatches();
    }
}
