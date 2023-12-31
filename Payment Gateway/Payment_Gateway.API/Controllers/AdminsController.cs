﻿using Microsoft.AspNetCore.Mvc;
using Payment_Gateway.BLL.Implementation;
using Payment_Gateway.BLL.Infrastructure;
using Payment_Gateway.BLL.Interfaces;
using Payment_Gateway.BLL.Interfaces.IServices;
using Swashbuckle.AspNetCore.Annotations;

namespace Payment_Gateway.API.Controllers
{
    [ApiController]
    [Route("api/admins")]
    public class AdminsController : ControllerBase
    {
        private readonly IAdminServices _adminServices;
        private readonly IUserService _userServices;
        private readonly ITransactionService _transactionServices;


        public AdminsController(IAdminServices adminServices, IUserService userService, ITransactionService transactionService)
        {
            _adminServices = adminServices;
            _userServices = userService;
            _transactionServices = transactionService;
        }



        //[Authorize]
        //[Route("list-bank")]
        [HttpGet("check-balance", Name = "check-admin-balance")]
        [SwaggerOperation(Summary = "Check account balance")]
        [SwaggerResponse(StatusCodes.Status200OK, Description = "successful", Type = typeof(SuccessResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Description = "failed", Type = typeof(ErrorResponse))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Description = "It's not you, it's us", Type = typeof(ErrorResponse))]
        public async Task<ActionResult<object>> CheckBalance()
        {
            var response = await _adminServices.CheckBalance();
            return Ok(response);
        }



        //[Authorize]
        //[Route("list-bank")]
        [HttpGet("check-ledger", Name = "Check-Ledger")]
        [SwaggerOperation(Summary = "Check Ledger balance")]
        [SwaggerResponse(StatusCodes.Status200OK, Description = "successful", Type = typeof(SuccessResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Description = "failed", Type = typeof(ErrorResponse))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Description = "It's not you, it's us", Type = typeof(ErrorResponse))]
        public async Task<ActionResult<object>> FetchLedger()
        {
            var response = await _adminServices.FetchLedger();
            return Ok(response);
        }



        //[Authorize]
        //[Route("list-bank")]
        [HttpGet("all-users", Name ="all-users")]
        [SwaggerOperation(Summary = "Get All Registered Users")]
        [SwaggerResponse(StatusCodes.Status200OK, Description = "successful", Type = typeof(SuccessResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Description = "failed", Type = typeof(ErrorResponse))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Description = "It's not you, it's us", Type = typeof(ErrorResponse))]
        public async Task<IActionResult> GetAllUsers()
        {
            var response = await _adminServices.GetAllUsers();
            if (response.Success)
                return Ok(response);

            return BadRequest(response);
        }



        //[Authorize]
        //[Route("list-bank")]
        [HttpGet("all-users-balance", Name= "All-Users-Balance")]
        [SwaggerOperation(Summary = "Get All Registered Users With Their Account Balance")]
        [SwaggerResponse(StatusCodes.Status200OK, Description = "successful", Type = typeof(SuccessResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Description = "failed", Type = typeof(ErrorResponse))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Description = "It's not you, it's us", Type = typeof(ErrorResponse))]
        public async Task<IActionResult> GetAllUsersWithBalance()
        {
            var response = await _adminServices.GetAllUsersWithBalance();
            if (response.Success)
                return Ok(response);

            return BadRequest(response);
        }



        //[Authorize]
        //[Route("list-bank")]
        [HttpGet("deleteUser", Name ="Delete-User")]
        [SwaggerOperation(Summary = "Delete A user")]
        [SwaggerResponse(StatusCodes.Status200OK, Description = "successful", Type = typeof(SuccessResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Description = "failed", Type = typeof(ErrorResponse))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Description = "It's not you, it's us", Type = typeof(ErrorResponse))]
        public async Task<IActionResult> DeleteUser(string userId)
        {
            var response = await _adminServices.DeleteUser(userId);
            if (response.Success)
                return Ok(response);

            return BadRequest(response);
        }



        //[Authorize]
        //[Route("list-bank")]
        [HttpGet("GetUser", Name ="Get-User")]
        [SwaggerOperation(Summary = "Get A Registered User")]
        [SwaggerResponse(StatusCodes.Status200OK, Description = "successful", Type = typeof(SuccessResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Description = "failed", Type = typeof(ErrorResponse))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Description = "It's not you, it's us", Type = typeof(ErrorResponse))]
        public async Task<IActionResult> GetUser(string userId)
        {
            var response = await _adminServices.GetUser(userId);
            if (response.Success)
                return Ok(response);

            return BadRequest(response);
        }



        //[Authorize]
        //[Route("list-bank")]
        [HttpGet("get-user-details", Name = "get-user-details")]
        [SwaggerOperation(Summary = "Get All Registered User Details")]
        [SwaggerResponse(StatusCodes.Status200OK, Description = "successful", Type = typeof(SuccessResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Description = "failed", Type = typeof(ErrorResponse))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Description = "It's not you, it's us", Type = typeof(ErrorResponse))]
        public async Task<IActionResult> GetUserDetails(string userId)
        {
            var response = await _adminServices.GetUserDetails(userId);
            if (response.Success)
                return Ok(response);

            return BadRequest(response);
        }



        //[Authorize]
        //[Route("list-bank")]
        [HttpGet("users-transactions", Name = "users-transactions")]
        [SwaggerOperation(Summary = "Get A Registered User Transaction")]
        [SwaggerResponse(StatusCodes.Status200OK, Description = "successful", Type = typeof(SuccessResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Description = "failed", Type = typeof(ErrorResponse))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Description = "It's not you, it's us", Type = typeof(ErrorResponse))]
        public async Task<IActionResult> GetUserTransactions(string walletId)
        {
            var response = await _transactionServices.GetTransactionsDetails(walletId);
            if (response.Success)
                return Ok(response);

            return BadRequest(response);
        }



        //[Authorize]
        //[Route("list-bank")]
        [HttpGet("user-transaction", Name = "user-transaction")]
        [SwaggerOperation(Summary = "Get All Registered User Transaction")]
        [SwaggerResponse(StatusCodes.Status200OK, Description = "successful", Type = typeof(SuccessResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Description = "failed", Type = typeof(ErrorResponse))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Description = "It's not you, it's us", Type = typeof(ErrorResponse))]
        public async Task<IActionResult> UserTransaction([FromBody] GetTransactionRequest request)
        {
            var response = await _transactionServices.GetTransaction(request);
            if (response.Success)
                return Ok(response);

            return BadRequest(response);
        }



        //[Authorize]
        //[Route("list-bank")]
        [HttpGet("user-debit-transactions", Name = "User-Debit-Transactions")]
        [SwaggerOperation(Summary = "Get user debit trans details")]
        [SwaggerResponse(StatusCodes.Status200OK, Description = "successful", Type = typeof(SuccessResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Description = "failed", Type = typeof(ErrorResponse))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Description = "It's not you, it's us", Type = typeof(ErrorResponse))]
        public async Task<IActionResult> GetUserDebitTransactions(string walletId)
        {
            var response = await _transactionServices.GetDebitTransactions(walletId);
            if (response.Success)
                return Ok(response);

            return BadRequest(response);
        }



        //[Authorize]
        //[Route("list-bank")]
        [HttpGet("user-credit-transactions", Name = "User-Credit-Transactions")]
        [SwaggerOperation(Summary = "Get user credit trans details")]
        [SwaggerResponse(StatusCodes.Status200OK, Description = "successful", Type = typeof(SuccessResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Description = "failed", Type = typeof(ErrorResponse))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Description = "It's not you, it's us", Type = typeof(ErrorResponse))]
        public async Task<IActionResult> GetUserCreditTransactions(string walletId)
        {
            var response = await _transactionServices.GetCreditTransactions(walletId);
            if (response.Success)
                return Ok(response);

            return BadRequest(response);
        }
    }
}
