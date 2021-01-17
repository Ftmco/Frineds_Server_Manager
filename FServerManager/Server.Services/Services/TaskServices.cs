/*
 FtmCo Development Tm 2021 
 */

namespace Server.Services.Services
{
    using Server.Services.Repository;
    using System.Diagnostics;
    using System.Threading.Tasks;

    public class TaskServices : ITaskRepository
    {
       
        public async Task<Response> GetSystemTasksAsync()
        {
            return await Task.Run(async () => await RunCmdAsync("tasklist"));
        }

        public async Task<Response> KillTaskAsync(string pName)
        {
            return await Task.Run(async () => await RunCmdAsync($"Stop-process -name {pName}"));
        }

        public async Task<Response> RunCmdAsync(string cmd)
        {
            return await Task.Run(async () =>
            {
                ProcessStartInfo processStartInfo = new()
                {
                    Arguments = cmd,
                    RedirectStandardError = true,
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    FileName = "powershell.exe"
                };
                Process process = new()
                {
                    StartInfo = processStartInfo
                };
                process.Start();

                var cmdStandardOutPut = await process.StandardOutput.ReadToEndAsync();
                var cmdStandardErrors = await process.StandardError.ReadToEndAsync();
                process.Dispose();

                return new Response
                {
                    StandardErrors = cmdStandardErrors,
                    StandardOutPot = cmdStandardOutPut
                };
            });
        }

    }
}

