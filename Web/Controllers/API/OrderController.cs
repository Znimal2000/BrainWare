using Model;
using System.Collections.Generic;
using System.Web.Configuration;
using System.Web.Http;
using Service;


namespace Web.Controllers.API
{
	public class OrderController : ApiController
    {
        [HttpGet]
        public IEnumerable<Order> GetOrders(int id = 1)
        {
            string connectionString = WebConfigurationManager.AppSettings["connectionString"].ToString();
            var data = new OrderService(connectionString);
            return data.GetOrdersForCompany(id);
        }
    }
}
