using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Threading.Tasks;
using Data;
using Model;

namespace Service
{
  
    public class OrderService
    {

	    private OrderRepository _repo;

	    public OrderService(string dbString)
	    {
		    _repo = new OrderRepository(dbString);
	    }
        public List<Order> GetOrdersForCompany(int CompanyId)
        {
	        return _repo.GetOrderList(CompanyId);
        }
    }
}