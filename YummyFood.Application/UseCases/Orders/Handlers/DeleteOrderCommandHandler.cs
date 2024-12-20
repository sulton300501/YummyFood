﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YummyFood.Application.Abstractions;
using YummyFood.Application.UseCases.Orders.Commands;
using YummyFood.Domain.Entities.DTOs;

namespace YummyFood.Application.UseCases.Orders.Handlers
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, ResponseModel>
    {
        private readonly IApplicationDbContext _context;

        public DeleteOrderCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _context.Orders.FindAsync(request.Id);
            if (order == null)
            {
                return new ResponseModel()
                {
                    Message = "Not found",
                    StatusCode = 404,
                    IsSuccess = false
                };
            }

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync(cancellationToken);

            return new ResponseModel()
            {
                Message = "Succesfully",
                StatusCode = 200,
                IsSuccess = true
            }; 
        }
    }
}
