﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YummyFood.Domain.Entities.DTOs
{
    public class ResponseModel
    {
        public bool IsSuccess { get; set; } = false;
        public string Message { get; set; }
        public int StatusCode { get; set; }
    }
}
