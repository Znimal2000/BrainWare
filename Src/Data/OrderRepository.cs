using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
				var sql1 =
					"SELECT c.name, o.description, o.order_id FROM company c INNER JOIN [order] o on c.company_id=o.company_id";

				var sqlQuery = new SqlCommand(sql1, connection);
				var reader1 = sqlQuery.ExecuteReader();
				var values = new List<Order>();

				while (reader1.Read())
				{
					var record1 = (IDataRecord)reader1;

					values.Add(new Order()
					{
						CompanyName = record1.GetString(0),
						Description = record1.GetString(1),
						OrderId = record1.GetInt32(2),
						OrderProducts = new List<OrderProduct>()
					});

				}

				reader1.Close();

				//Get the order products
				var sql2 =
					"SELECT op.price, op.order_id, op.product_id, op.quantity, p.name, p.price FROM orderproduct op INNER JOIN product p on op.product_id=p.product_id";
				var sqlQuery2 = new SqlCommand(sql2, connection);
				var reader2 = sqlQuery2.ExecuteReader();

				var values2 = new List<OrderProduct>();

				while (reader2.Read())
				{
					var record2 = (IDataRecord)reader2;

					values2.Add(new OrderProduct()
					{
						OrderId = record2.GetInt32(1),
						ProductId = record2.GetInt32(2),
						Price = record2.GetDecimal(0),
						Quantity = record2.GetInt32(3),
						Product = new Product()
						{
							Name = record2.GetString(4),
							Price = record2.GetDecimal(5)
						}
					});
				}

				reader2.Close();

				foreach (var order in values)
				{
					foreach (var orderproduct in values2)
					{
						if (orderproduct.OrderId != order.OrderId)
							continue;

						order.OrderProducts.Add(orderproduct);
						order.OrderTotal = order.OrderTotal + (orderproduct.Price * orderproduct.Quantity);
					}
				}

				return values;

			}
		}
	}
}
