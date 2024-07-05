﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YummyFood.Domain.Entities.DTOs;

namespace YummyFood.Application.UseCases.Cards.Commands
{
    public class DeleteCardCommand : IRequest<ResponseModel>
    {
        public long Id { get; set; }
    }
}
