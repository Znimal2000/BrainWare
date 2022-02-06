using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Model;

namespace Data
{
	public class OrderRepository : IOrderRepository
	{
		private readonly DbConnectionBuilder _dbBuilder;
		public OrderRepository(string dbString)
		{
			_dbBuilder = new DbConnectionBuilder(dbString);
		}
		
		public List<Order> GetOrderList(int companyId)
		{
			using (var connection = _dbBuilder.CreateDbConnection())
			{
				connection.Open();
				// Get the orders
				var sql1 = @"select OT.OrderId, C.[name] as CompanyName, O.[description], OT.OrderTotal from 
					(SELECT  order_id as OrderId, SUM(price * quantity) AS OrderTotal FROM[OrderProduct]
				GROUP BY ROLLUP(order_id)) OT inner join[order] O on OT.OrderId = O.order_id
				inner join Company C on C.company_id = O.company_id
				where C.company_id = " + companyId;

				var values = new List<Order>();

				values.AddRange(connection.Query<Order>(sql1, CommandType.Text));


				foreach (var order in values)
				{
					var sql2 = @"select order_id as OrderId, product_id as ProductId, Price, Quantity from [OrderProduct] where order_id = " + order.OrderId;
					order.OrderProducts = new List<OrderProduct>();
					order.OrderProducts.AddRange(connection.Query<OrderProduct>(sql2, CommandType.Text));

					foreach (var orderProduct in order.OrderProducts)
					{
						var sql3 = @"select [Name], Price from [Product] where product_id = " + orderProduct.ProductId;
						orderProduct.Product = connection.Query<Product>(sql3, CommandType.Text).FirstOrDefault();
					}
				}

				return values;
			}
		}
	}
}
