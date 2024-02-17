using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class OrderManager : IOrderService
    {
        public IOrderDal? _orderDal { get; set; }
        public OrderManager(IOrderDal? orderDal)
        {
            _orderDal = orderDal;
        }

        //[SuppressMessage("ReSharper.DPA", "DPA0007: Large number of DB records")]
        public List<Order> GetAll()
        {
            return _orderDal.GetAll();
        }

        public Order GetById(int id)
        {
            return _orderDal.Get(o => o.OrderID == id);
        }
    }
}
