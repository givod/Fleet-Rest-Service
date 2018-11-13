using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FleetManagementWebService;
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
        public ActionResult GetFleets()
        {
            return Ok();
        }
    }
}