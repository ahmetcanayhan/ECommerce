using Core.Concretes.Entities;
using Core.Concretes.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Concretes.DTOs
{
    public class OrderDto
    {
        public int Id { get; set; }
        public IEnumerable<OrderItemDto> Items { get; set; } = [];
        public OrderStatus Status { get; set; }
    }
}
