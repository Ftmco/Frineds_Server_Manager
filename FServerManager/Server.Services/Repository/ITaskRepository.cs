using System.Threading.Tasks;

namespace Server.Services.Repository
{
    /// <summary>
    /// Task Services 
    /// Run Power Shell
    /// </summary>
    public interface ITaskRepository
    {
        Task<Response> GetSystemTasksAsync();
        Task<Response> KillTaskAsync(string pId);
        Task<Response> RunCmdAsync(string cmd);
    }
}
