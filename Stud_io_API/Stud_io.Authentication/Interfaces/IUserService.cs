using Microsoft.AspNetCore.Mvc;
using Stud_io.Authentication.DTOs;
using Stud_io.Authentication.DTOs.ServiceCommunication.Complaint;
using Stud_io.Authentication.DTOs.ServiceCommunication.Dormitory;
using Stud_io.Authentication.DTOs.ServiceCommunication.StudyGroup;
using Stud_io.DTOs;

namespace Stud_io.Authentication.Interfaces
{
    public interface IUserService
    {
        Task<ActionResult<IEnumerable<UserDto>>> GetUsers();
        Task<ActionResult<UserDto>> GetUserById(string id);
        Task<IActionResult> DeleteUser(string id);
        Task<ActionResult<List<DormitoryStudentDto>>> GetDormitoryStudents();
        Task<ActionResult<List<MemberStudentDto>>> GetStudyGroupStudents(int id);
        Task<ActionResult<List<MemberStudentDto>>> GetGroupEventStudents(int id);
        Task<ActionResult<string>> GetStudentsCustomerId(string email);
        Task<ActionResult> AddStudyGroupMembers(int groupId, List<string> studentIds);
        Task<ActionResult> AddGroupEventStudent(int groupEventId, string studentId);
        Task<ActionResult<List<ComplaintStudentDto>>> GetComplaintStudents();
    }
}