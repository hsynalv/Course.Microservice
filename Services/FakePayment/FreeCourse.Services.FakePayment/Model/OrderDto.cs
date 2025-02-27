﻿using System;
using System.Collections.Generic;

namespace FreeCourse.Services.FakePayment.Model
{
    public class OrderDto
    {
        public OrderDto()
        {
            OrderItems = new List<OrderItemDto>();
        }

        public string UserId { get; set; }

        public List<OrderItemDto> OrderItems { get; set; }

        public AdressDto Address { get; set; }
    }

    public class OrderItemDto
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string PictureUrl { get; set; }
        public decimal Price { get; set; }
    }

    public class AdressDto
    {
        public string Province { get; set; }
        public string District { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public string Line { get; set; }
    }
}
