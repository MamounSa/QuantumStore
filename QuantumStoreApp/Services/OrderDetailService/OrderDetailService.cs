using AutoMapper;
using System.Collections.Generic;
using System.Linq;

namespace QuantumStore
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IMapper _mapper;

        public OrderDetailService(IOrderDetailRepository orderDetailRepository, IMapper mapper)
        {
            _orderDetailRepository = orderDetailRepository;
            _mapper = mapper;
        }

        public IEnumerable<OrderDetailDTO> GetAllOrderDetails()
        {
            var orderDetails = _orderDetailRepository.GetAllOrderDetails();
            return orderDetails.Select(od => _mapper.Map<OrderDetailDTO>(od));
        }

        public OrderDetailDTO GetOrderDetailById(int id)
        {
            var orderDetail = _orderDetailRepository.GetOrderDetailById(id);
            return orderDetail != null ? _mapper.Map<OrderDetailDTO>(orderDetail) : null;
        }

        public bool AddOrderDetail(OrderDetailDTO orderDetailDTO)
        {
            var orderDetail = _mapper.Map<OrderDetail>(orderDetailDTO);
            return _orderDetailRepository.AddOrderDetail(orderDetail);
        }

        public bool UpdateOrderDetail(OrderDetailDTO orderDetailDTO)
        {
            var orderDetail = _mapper.Map<OrderDetail>(orderDetailDTO);
            return _orderDetailRepository.UpdateOrderDetail(orderDetail);
        }

        public bool DeleteOrderDetail(int id)
        {
            return _orderDetailRepository.DeleteOrderDetail(id);
        }
    }
}
