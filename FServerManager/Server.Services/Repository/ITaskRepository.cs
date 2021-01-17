/*
 FtmCo Development Tm 2021 
 */

namespace Server.Services.Repository
{
    using System.Threading.Tasks;

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
