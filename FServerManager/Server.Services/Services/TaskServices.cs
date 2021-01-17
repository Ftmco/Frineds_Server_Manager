﻿using Server.Services.Repository;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Server.Services.Services
{
    public class TaskServices : ITaskRepository
    {
        public async Task<Response> GetSystemTasksAsync()
        {
            return await Task.Run(async () =>
            {
                ProcessStartInfo processStartInfo = new()
                {
                    Arguments = "tasklist",
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
