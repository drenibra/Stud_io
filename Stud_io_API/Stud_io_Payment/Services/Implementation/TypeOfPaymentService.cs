using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stud_io.Payment.DTOs;
using Stud_io.Payment.Models;
using Stud_io.Payment.Services.Interfaces;
using Stud_io_Payment.Configurations;
using System.Collections.Generic;

namespace Stud_io.Payment.Services.Implementation
{
    public class TypeOfPaymentService : ITypeOfPaymentService
    {
        private readonly PaymentDbContext _context;
        private readonly IMapper _mapper;

        public TypeOfPaymentService(PaymentDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ActionResult<List<TypeOfPaymentDto>>> GetTypeOfPayments(string? sortBy, string? searchString)
        {
            //Here we retrieve all the data from the table and order them by price (by default is ascending)
            var allSorted = _mapper.Map<List<TypeOfPaymentDto>>(_context.TypeOfPayments.OrderBy(n => n.Price).ToList());

            if (!string.IsNullOrEmpty(sortBy))
            {
                switch (sortBy.ToLower())
                {
                    //in case we want to order the list descending, we reorder the "allSorted" list
                    case "price_desc":
                        allSorted = allSorted.OrderByDescending(n => n.Price).ToList();
                        break;
                    default:
                        break;
                }
            }

            if (!string.IsNullOrEmpty(searchString))
            {
                //we filter the list according to the string received as a parameter
                allSorted = allSorted.Where(n => n.Type.Contains(searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();
            }
            return allSorted;
        }

        public async Task<ActionResult<TypeOfPaymentDto>> GetTypeOfPaymentById(int id)
        {
            var mappedTypeOfPayment = _mapper.Map<TypeOfPaymentDto>(await _context.TypeOfPayments.FindAsync(id));
            return mappedTypeOfPayment == null
                ? new NotFoundObjectResult("Type of payment doesn't exist!!")
                : new OkObjectResult(mappedTypeOfPayment);
        }

        public async Task<ActionResult> AddTypeOfPayment(TypeOfPaymentDto typeOfPaymentDTO)
        {
            if (typeOfPaymentDTO == null)
                return new BadRequestObjectResult("Type of payment can not be null!!");
            var mappedtypeOfPayment = _mapper.Map<TypeOfPayment>(typeOfPaymentDTO);
            await _context.TypeOfPayments.AddAsync(mappedtypeOfPayment);
            await _context.SaveChangesAsync();
            return new OkObjectResult("Type of payment added successfully!");
        }

        public async Task<ActionResult> UpdateTypeOfPayment(int id, UpdateTypeOfPaymentDto updateTypeOfPaymentDTO)
        {
            if (updateTypeOfPaymentDTO == null)
                return new BadRequestObjectResult("Type of payment can not be null!!");

            var dbTypeOfPayment = await _context.TypeOfPayments.FindAsync(id);
            if (dbTypeOfPayment == null)
                return new NotFoundObjectResult("Type of payment doesn't exist!!");

            dbTypeOfPayment.Type = updateTypeOfPaymentDTO.Type ?? dbTypeOfPayment.Type;
            dbTypeOfPayment.Price = updateTypeOfPaymentDTO.Price ?? dbTypeOfPayment.Price;
            await _context.SaveChangesAsync();

            return new OkObjectResult("Type of payment updated successfully!");
        }

        public async Task<ActionResult> DeleteTypeOfPayment(int id)
        {
            var dbTypeOfPayment = await _context.TypeOfPayments.FindAsync(id);
            if (dbTypeOfPayment == null)
                return new NotFoundObjectResult("Type of payment doesn't exist!!");

            _context.TypeOfPayments.Remove(dbTypeOfPayment);
            await _context.SaveChangesAsync();
            return new OkObjectResult("Type of payment deleted successfully!");
        }
    }
}