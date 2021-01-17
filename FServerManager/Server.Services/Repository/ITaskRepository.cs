using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Services.Repository
{
    public interface ITaskRepository
    {
        Task<Response> GetSystemTasksAsync();
    }
}
