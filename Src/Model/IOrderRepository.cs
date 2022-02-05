using System.Collections.Generic;
using System.Threading.Tasks;

namespace Model
{
	public interface IOrderRepository
	{
		List<Order> GetOrderList(int companyId);

	}
}
