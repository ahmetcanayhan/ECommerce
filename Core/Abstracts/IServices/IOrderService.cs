using Core.Concretes.DTOs;
using Core.Concretes.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Abstracts.IServices
{
    public interface IOrderService
    {
        Task<int?> CreateOrderAsync(string customerId);
        Task ChangeOrderStatusAsync(int orderId, OrderStatus status);
        Task<OrderDto?> GetOrderAsync(int orderId, string customer);
    }
}
