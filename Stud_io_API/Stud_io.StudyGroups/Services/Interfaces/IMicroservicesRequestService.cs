namespace Stud_io.StudyGroups.Services.Interfaces
{
    public interface IMicroservicesRequestService
    {
        Task<string> GetRequestAt(string uri);
        Task<string> PostRequestAt(string uri, List<string> studentIds);
    }
}
