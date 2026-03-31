using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Concretes.DTOs
{
    public class CartDto
    {
        public string CustomerId { get; set; } = null!;
        public IEnumerable<CartItemDto> Items { get; set; } = [];
    }
}
