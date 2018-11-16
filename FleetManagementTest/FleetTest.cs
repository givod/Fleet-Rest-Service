using System;
using FleetManagementWebService;
using FleetManagementWebService.Models;
using Fleet_Management_Web_Service.Controller;
using Xunit;

namespace FleetManagementTest
{
    public class FleetControllerTest
    {
        private FleetController _controller;
        private IDataRepository _service;

        public FleetControllerTest()
        {
            _service = new DataRepositoryFake();
            _controller = new FleetController(_service);
        }

        [Fact]
        public void GetFleet_Return_ResponseOK()
        {
            var okResult = _controller.GetFleets().Value;
            Assert.IsType<Response>(okResult);
        }


        [Fact]
        public void AddFleet_Return_ResponseWithAddedFleet()
        {
            
            var fleet = new Fleet()
            {
                Id = new Guid(),
                Category = 1,
                Description = "TextFleet",
                DateAcquired = DateTime.UtcNow
            };
            var result = _controller.AddFleet(fleet).Value;
            Assert.IsType<Response>(result);
        }

        

        [Fact]
        public void UpdateFleet_Return_ResponseWithUpdatedFleet()
        {
            Fleet fleet = new Fleet()
            {
                Id = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200"),
                Category = 3,
                Description = "XXX123TX",
                DateAcquired = DateTime.UtcNow
            };
            var result = _controller.UpdateFleet(fleet).Value;
            Assert.IsType<Response>(result);
        }

        [Fact]
        public void RemoveFleet_Return_ResponseWithStatusofbool()
        {
            var guid = new RemoveFleet()
            {
                FleetId = "ab2bd817-98cd-4cf3-a80a-53ea0cd9c200"
            };
            var result = _controller.RemoveFleet(guid).Value;
            Assert.IsType<Response>(result);
        }

    }
}
