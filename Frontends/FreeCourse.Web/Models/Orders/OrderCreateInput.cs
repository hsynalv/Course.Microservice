﻿using System.Collections.Generic;

namespace FreeCourse.Web.Models.Orders
{
    public class OrderCreateInput
    {
        public OrderCreateInput()
        {
            OrderItems = new List<OrderItemCreateInput>();
        }

        public string UserId { get; set; }

        public List<OrderItemCreateInput> OrderItems { get; set; }

        public AddressCreateInput Address { get; set; }
    }
}
