﻿using FreeCourse.Services.Order.Application.DTOs;
using FreeCourse.Shared.DTOs;
using MediatR;
using System.Collections.Generic;

namespace FreeCourse.Services.Order.Application.Queries
{
    public class GetOrdersByUserIdQuery : IRequest<Response<List<OrderDto>>>
    {
        public string UserId { get; set; }
    }
}
