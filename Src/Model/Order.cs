﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
	public class Order
	{
		public int OrderId { get; set; }

		public string CompanyName { get; set; }

		public string Description { get; set; }

		public decimal OrderTotal { get; set; }

		public List<OrderProduct> OrderProducts { get; set; }

	}
}
