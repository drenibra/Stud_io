using Microsoft.AspNetCore.Mvc;
using Stud_io.Payment.DTOs;
using Stud_io.Payment.Services.Implementation;
using Stud_io.Payment.Services.Interfaces;

namespace Stud_io.Payment.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TypeOfPaymentController : ControllerBase
    {
        private readonly ITypeOfPaymentService _typeOfPaymentService;

        public TypeOfPaymentController(ITypeOfPaymentService typeOfPaymentService)
        {
            _typeOfPaymentService = typeOfPaymentService;
        }

        [HttpGet("TypeOfPayments")]
        public async Task<ActionResult<List<TypeOfPaymentDto>>> GetTypeOfPayments(string? sortBy, string? searchString)
        {
            return await _typeOfPaymentService.GetTypeOfPayments(sortBy, searchString);
        }

        [HttpGet("TypeOfPayment/{id}")]
        public async Task<ActionResult<TypeOfPaymentDto>> GetTypeOfPaymentById(int id)
        {
            return await _typeOfPaymentService.GetTypeOfPaymentById(id);
        }

        [HttpPost("TypeOfPayment")]
        public async Task<ActionResult> AddTypeOfPayment(TypeOfPaymentDto typeOfPaymentDto)
        {
            return await _typeOfPaymentService.AddTypeOfPayment(typeOfPaymentDto);
        }

        [HttpPut("TypeOfPayment")]
        public async Task<ActionResult> UpdateTypeOfPayment(int id, UpdateTypeOfPaymentDto updateTypeOfPaymentDto)
        {
            return await _typeOfPaymentService.UpdateTypeOfPayment(id, updateTypeOfPaymentDto);
        }

        [HttpDelete("TypeOfPayment/{id}")]
        public async Task<ActionResult> DeleteTypeOfPayment(int id)
        {
            return await _typeOfPaymentService.DeleteTypeOfPayment(id);
        }
    }
}