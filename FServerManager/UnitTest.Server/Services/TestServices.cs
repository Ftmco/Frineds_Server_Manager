using NUnit.Framework;
using Server.Services.Repository;
using Server.Services.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTest.Server.Services
{
    class TestServices
    {
        private ITaskRepository _task;

        public TestServices()
        {
            _task = new TaskServices();
        }

        [SetUp]
        public void SetUp()
        {

        }

        [Test]
        public void Test()
        
        {
            var response = _task.GetSystemTasksAsync().Result;
            Assert.Equals(response.StandardErrors, "");
            Assert.Pass();
        }
    }
}
