﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Services.Repository;
using Server.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerManager.Server.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        #region __Dependency__

        private readonly ITaskRepository _task;

        public TaskController()
        {
            _task = new TaskServices();
        }

        #endregion

        [HttpGet]
        [Route("GetServerTask")]
        public async Task<IActionResult> GetServerTask()
        {
            return Ok(await _task.GetSystemTasksAsync());
        }
    }
}
