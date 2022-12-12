using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BusinessLayer;
using ModelsLayer;

namespace APIproject.Controllers
{
    [ApiController]
    [Route("api/")]
    public class ManagerController : ControllerBase
    {
        private readonly IBusinessClass _busClass;

        public ManagerController(IBusinessClass ibuss)
        {
            _busClass = ibuss;
        }


        //Get request - get's all the registered users
        [HttpGet("/GetAllUsers")]
        public async Task<ActionResult<List<Register>>> getUsers()
        {
            List<Register> allUsers = await this._busClass.getAllUsers();
            if (allUsers == null)
            {
                return Problem("List of users is empty!");
            }
            return Ok(allUsers);

        }


        //Get Request - get's all tickets by emp id
        [HttpGet("GetAllTicketsById")]
        public async Task<ActionResult<List<Register>>> getAllTasksById(int empId)
        {
            List<Tickets> allTickets = await this._busClass.getByUserId(empId);
            if (allTickets == null)
            {
                return Problem("List of users is empty!");
            }
            return Ok(allTickets);

        }


        //Get's all tickets by employe id and status pending
        [HttpGet("/GetAllTicketsByIdAndPendingStatus")]
        public async Task<ActionResult<List<Register>>> getPendingTickets(int empId, string status)
        {
            List<Tickets> allPendingTickets = await this._busClass.getAllPendingTickets(empId, status);
            if (allPendingTickets == null)
            {
                return Problem("List of users is empty!");
            }
            return Ok(allPendingTickets);

        }


        //login with username and password
        [HttpGet("login")]
        public async Task<ActionResult<Register>> currentUser(string username, string password)
        {
            Register currentUser = await this._busClass.login(username, password);
            if (currentUser == null)
            {
                return Problem("User not found!");
            }
            return Ok(currentUser);

        }


        //Post Request - register with username and password
        [HttpPost("SignupNewUser")]
        public async Task<ActionResult<Register>> signUp(Register newUser)
        {
            if (ModelState.IsValid)
            {
                Register newRegister = await this._busClass.signUp(newUser);
            }
            else
            {
                return NotFound("The model binding didn't work");
            }
            return Created("Created new user", newUser);
        }

        //Post requests - adds new ticket 
        [HttpPost("AddNewTicket")]
        public async Task<ActionResult<Tickets>> addTicket(Tickets ticket)
        {
            if (ModelState.IsValid)
            {
                Tickets newTicket = await this._busClass.addTicket(ticket);
            }
            else
            {
                return NotFound("The model binding didn't work");
            }
            return Created("Created new user", ticket);
        }
    }
}