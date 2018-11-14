using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using FleetManagementWebService;
using FleetManagementWebService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fleet_Management_Web_Service.Controller
{
    [Route("v1/")]
    [ApiController]
    public class FleetController : ControllerBase
    {
        private readonly IDataRepository _dataService;

        public FleetController(IDataRepository dataService)
        {
            _dataService = dataService;
        }

        [HttpGet]
        [Route("GetFleets")]
        public ActionResult<Response> GetFleets()
        {
            return
                new Response()
                {
                    ResponseCode = HttpStatusCode.OK,
                    Message = "Data retrieved successfully",
                    Status = true,
                    Data = _dataService.GetFleets()
                };
        }

        [HttpPost]
        [Route("AddFleet")]
        public ActionResult<Response> AddFleet(Fleet fleet)
        {
            fleet.Id = new Guid();
            return new Response()
            {
                ResponseCode = HttpStatusCode.Created,
                Message = "Created Successfully",
                Data = _dataService.AddFleet(fleet),
                Status = true
            };               
        }

        [HttpDelete]
        [Route("RemoveFleet")]
        public ActionResult<Response> RemoveFleet(RemoveFleet fleetId)
        {
            if (fleetId == null)
            {
                return new Response()
                {
                    ResponseCode = HttpStatusCode.BadRequest,
                    Message = "Fleet cannot be empty",
                    Status = false
                };
            }

            var fleet = new Guid(fleetId.FleetId);

            if (_dataService.RemoveFleet(fleet))
            {
                return new Response()
                {
                    ResponseCode = HttpStatusCode.OK,
                    Message = "Removed Successfully",
                    Status = true
                };
            }
            return new Response()
            {
                ResponseCode = HttpStatusCode.NotFound,
                Message = "Removal not Successful",
                Status = false
            };
        }

        [HttpPut]
        [Route("UpdateFleet")]
        public ActionResult<Response> UpdateFleet(Fleet fleet)
        {
           return new Response()
           {
               ResponseCode = HttpStatusCode.OK,
               Data = _dataService.UpdateFleet(fleet),
               Status = true,
               Message = "Updated Successfully"
           };
        }

        [HttpGet]
        [Route("GetCategories")]
        public ActionResult<Response> GetCategories()
        {
            return new Response()
            {
                Data = _dataService.GetCategories(),
                ResponseCode = HttpStatusCode.OK,
                Status = true,
                Message = "Data retrieved successfully"
            };
        }

        [HttpPost]
        [Route("AddCategory")]
        public ActionResult<Response> AddCategory(Category category)
        {
          return  new Response()
          {
              Data = _dataService.AddCategory(category),
              ResponseCode = HttpStatusCode.Created,
              Status = true,
              Message = "Created successfully"
          };
        }

        [HttpDelete]
        [Route("RemoveCategory")]
        public ActionResult<Response> RemoveCategory(RemoveCategory Id)
        {
            return new Response()
            {
                ResponseCode = HttpStatusCode.OK,
                Data = _dataService.RemoveCategory(Id.Id),
                Status = true,
                Message = "Removed successfully"
            };
        }
    }
}