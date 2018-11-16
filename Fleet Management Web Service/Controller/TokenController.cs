using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using FleetManagementWebService.Interfaces;
using FleetManagementWebService.Models;
using FleetManagementWebService.TokenService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fleet_Management_Web_Service.Controller
{
    [Route("v1/")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IToken _tokenService;
        public TokenController(IToken tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpGet]
        [Route("GetToken")]
        public ActionResult<Response> GetToken()
        {
            try
            {
                return new Response
                {

                    Data = _tokenService.GetToken(),
                    Message = "Token Generated",
                    Status = true,
                    ResponseCode = HttpStatusCode.OK
                };
            }
            catch (Exception)
            {
                return new Response
                {
                    Message = "Token Generation failed",
                    Status = false,
                    ResponseCode = HttpStatusCode.BadRequest
                };
            }
        }
    }
}