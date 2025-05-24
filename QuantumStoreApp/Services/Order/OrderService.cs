using AutoMapper;
using QuantumStore;
using System.Collections.Generic;
using System.Linq;

namespace QuantumStore
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public IEnumerable<OrderDTO> GetAllOrders()
        {
            var orders = _orderRepository.GetAllOrders();
            return orders.Select(o => _mapper.Map<OrderDTO>(o));
        }

        public OrderDTO GetOrderById(int id)
        {
            var order = _orderRepository.GetOrderById(id);
            return order != null ? _mapper.Map<OrderDTO>(order) : null;
        }

        public bool AddOrder(OrderDTO orderDTO)
        {
            var order = _mapper.Map<Order>(orderDTO);
            return _orderRepository.AddOrder(order);
        }

        public bool UpdateOrder(OrderDTO orderDTO)
        {
            var order = _mapper.Map<Order>(orderDTO);
            return _orderRepository.UpdateOrder(order);
        }

        public bool DeleteOrder(int id)
        {
            return _orderRepository.DeleteOrder(id);
        }
    }
}