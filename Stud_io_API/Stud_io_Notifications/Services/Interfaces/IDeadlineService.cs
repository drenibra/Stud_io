﻿using Microsoft.AspNetCore.Mvc;
using Notifications.Models;
using Stud_io_Notifications.DTOs;

namespace Stud_io_Notifications.Services.Interfaces
{
    public interface IDeadlineService
    {
        List<DeadlineDto> GetDeadlines();
        DeadlineDto GetDeadline(string id);
        Deadline CreateDeadline(DeadlineDto deadline);
        void UpdateDeadline(string id, UpdateDeadlineDto updateDeadlineDto);
        void RemoveDeadline(string id);
    }
}