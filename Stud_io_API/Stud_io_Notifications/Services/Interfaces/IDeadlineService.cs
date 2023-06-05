﻿using Notifications.Models;

namespace Stud_io_Notifications.Services.Interfaces
{
    public interface IDeadlineService
    {
        List<Deadline> GetDeadlines();
        Deadline GetDeadline(string id);
        Deadline CreateDeadline(Deadline deadline);
        void UpdateDeadline(string id, Deadline deadline);
        void RemoveDeadline(string id);
    }
}