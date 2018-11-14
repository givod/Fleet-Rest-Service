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
        public ActionResult<Response> AddFleet(Fleet fleet)
        {
            return new Response()
            {
                ResponseCode = HttpStatusCode.Created,
                Message = "Created Successfully",
                Data = _dataService.AddFleet(fleet),
                Status = true
            };               
        }

        [HttpDelete]
        public ActionResult<Response> RemoveFleet(Guid fleetId)
        {
            return new Response()
            {
                ResponseCode = HttpStatusCode.OK,
                Message = "Removed Successfully",
                Status = _dataService.RemoveFleet(fleetId)
            };
        }

        [HttpPut]
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
        public ActionResult<Response> RemoveCategory(int id)
        {
            return new Response()
            {
                ResponseCode = HttpStatusCode.OK,
                Data = _dataService.RemoveCategory(id),
                Status = true,
                Message = "Removed successfully"
            };
        }
    }
}