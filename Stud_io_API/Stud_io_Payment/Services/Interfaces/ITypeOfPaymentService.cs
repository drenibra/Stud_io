using Microsoft.AspNetCore.Mvc;
using Stud_io.Payment.DTOs;

namespace Stud_io.Payment.Services.Interfaces
{
    public interface ITypeOfPaymentService
    {
        public Task<ActionResult<List<TypeOfPaymentDto>>> GetTypeOfPayments(string? sortBy, string? searchString);
        public Task<ActionResult<TypeOfPaymentDto>> GetTypeOfPaymentById(int id);
        public Task<ActionResult> AddTypeOfPayment(TypeOfPaymentDto typeOfPaymentDTO);
        public Task<ActionResult> UpdateTypeOfPayment(int id, UpdateTypeOfPaymentDto updateTypeOfPaymentDTO);
        public Task<ActionResult> DeleteTypeOfPayment(int id);
    }
}