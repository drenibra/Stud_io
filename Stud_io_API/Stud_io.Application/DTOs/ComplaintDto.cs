﻿namespace Stud_io.Application.DTOs
{
    public class ComplaintDto
    {
        public string Description { get; set; }
        public string StudentsId { get; set; }
    }

    public class UpdateComplaintDto
    {
        public string? Description { get; set; }
        public string? StudentsId { get; set; }
    }
}