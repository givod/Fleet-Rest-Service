using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using FleetManagementWebService;
using FleetManagementWebService.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fleet_Management_Web_Service.Controller
{
    [Route("v1/"), Authorize]
    [ApiController]
    public class FleetController : ControllerBase
    {
        private readonly IDataRepository _dataService;

        public FleetController(FleetDatabaseContext context)
        {
            _dataService = new DataRepository(context);
        }

        [HttpGet]
        [Route("GetFleets")]
        public ActionResult<Response> GetFleets()
        {
            try
            {
                return new Response() { ResponseCode = HttpStatusCode.OK, Message = "Data retrieved successfully", Status = true, Data = _dataService.GetFleets() };
            }
            catch (Exception e)
            {
                return new Response
                {
                    Status = false,
                    Message = "Something went wrong from our part, and we are currently working on it.",
                    ResponseCode = HttpStatusCode.OK
                };
            }
        }

        [HttpPost]
        [Route("AddFleet")]
        public ActionResult<Response> AddFleet(FleetTable fleet)
        {
            try {

                fleet.Id = new Guid();
                fleet.DateAcquired = DateTime.Now;
                fleet.DateAcquired = DateTime.Now;
                return new Response()
                {
                    ResponseCode = HttpStatusCode.Created,
                    Message = "Created Successfully",
                    Data = _dataService.AddFleet(fleet),
                    Status = true
                };
            }
            catch (Exception e) {
                return new Response
                {
                    Status = false,
                    Message = "Something went wrong from our part, and we are currently working on it.",
                    ResponseCode = HttpStatusCode.OK
                };
            }
                         
        }

        [HttpDelete]
        [Route("RemoveFleet")]
        public async Task<ActionResult<Response>> RemoveFleet(RemoveFleet fleetId)
        {

            try {
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
                var status = await _dataService.RemoveFleet(fleet);

                if (status)
                {
                    return new Response()
                    {
                        ResponseCode = HttpStatusCode.OK,
                        Message = "Removed Successfully",
                        Status = true
                    };
                }
                else
                {
                    return new Response()
                    {
                        ResponseCode = HttpStatusCode.NotFound,
                        Message = "Removal not Successful",
                        Status = false
                    };
                }
                
            }
            catch (Exception e)
            {
                return new Response
                {
                    Status = false,
                    Message = "Something went wrong from our part, and we are currently working on it.",
                    ResponseCode = HttpStatusCode.OK
                };
            }
            
        }

        [HttpPut]
        [Route("UpdateFleet")]
        public ActionResult<Response> UpdateFleet(FleetTable fleet)
        {
            try {
                var result = _dataService.UpdateFleet(fleet).Result;
                if (result)
                {
                    return new Response()
                    {
                        ResponseCode = HttpStatusCode.OK,
                        Data = result,
                        Status = true,
                        Message = "Updated Successfully"
                    };
                }
                else
                {
                    return new Response
                    {
                        Status = false,
                        Message = "Something went wrong from our part, and we are currently working on it.",
                        ResponseCode = HttpStatusCode.BadRequest
                    };
                }
                
            }
            catch (Exception e){
                return new Response
                {
                    Status = false,
                    Message = "Something went wrong from our part, and we are currently working on it.",
                    ResponseCode = HttpStatusCode.OK
                };
            }
          
        }

        [HttpGet]
        [Route("GetCategories")]
        public ActionResult<Response> GetCategories()
        {
            try {
                return new Response()
                {
                    Data = _dataService.GetCategories(),
                    ResponseCode = HttpStatusCode.OK,
                    Status = true,
                    Message = "Data retrieved successfully"
                };
            }
            catch (Exception e)
            {
                return new Response
                {
                    Status = false,
                    Message = "Something went wrong from our part, and we are currently working on it.",
                    ResponseCode = HttpStatusCode.OK
                };
            }
            
        }

        [HttpPost]
        [Route("AddCategory")]
        public ActionResult<Response> AddCategory(Category category)
        {
            try {
                return new Response()
                {
                    Data = _dataService.AddCategory(category),
                    ResponseCode = HttpStatusCode.Created,
                    Status = true,
                    Message = "Created successfully"
                };
            }
            catch(Exception e) {
                return new Response
                {
                    Status = false,
                    Message = "Something went wrong from our part, and we are currently working on it.",
                    ResponseCode = HttpStatusCode.OK
                };
            }
          
        }

        [HttpDelete]
        [Route("RemoveCategory")]
        public async Task<ActionResult<Response>> RemoveCategory(RemoveCategory Id)
        {
            try {
                var result = await _dataService.RemoveCategory(Id.Id);

                if (result)
                {
                    return new Response()
                    {
                        ResponseCode = HttpStatusCode.OK,
                        Data = result,
                        Status = result,
                        Message = "Removed successfully"
                    };
                }
                else
                {
                    return new Response
                    {
                        Status = result,
                        Message = "Something went wrong from our part, and we are currently working on it.",
                        ResponseCode = HttpStatusCode.OK
                    };
                }
                
            }
            catch(Exception e)
            {
                return new Response
                {
                    Status = false,
                    Message = "Something went wrong from our part, and we are currently working on it.",
                    ResponseCode = HttpStatusCode.OK
                };
            }
            
        }
    }
}