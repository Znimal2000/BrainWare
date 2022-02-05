using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Web.Controllers.API;

namespace Tests.Controllers
{
	[TestClass]
	public class OrderControllorTest
	{
		[TestMethod]
		public void GetOrders()
		{
			WebConfigurationManager.AppSettings["connectionString"] = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=BrainWAre;Integrated Security=SSPI;AttachDBFilename=C:\Projects\BrainWare\Web\App_Data\BrainWare.mdf";
			// Arrange
			OrderController controller = new OrderController();

			// Act
			var result = controller.GetOrders(1);

			// Assert
			Assert.IsNotNull(result);
			Assert.AreEqual(3, result.Count());
		}
	
    }
}
