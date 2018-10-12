using Microsoft.VisualStudio.TestTools.UnitTesting;
using CRUD_LFRZ1.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;


namespace CRUD_LFRZ1.Controllers.Tests
{
    [TestClass()]
    public class EmployeeControllerTests
    {
        [TestMethod()]
        public void IndexTestSuccess()
        {
            EmployeeController controller = new EmployeeController();
            ViewResult result = controller.Index("Name", "t", 1, "Name") as ViewResult;
            Assert.IsTrue(((IPagedList)result.Model).TotalItemCount > 0 );
        }
        [TestMethod()]
        public void IndexTestFail()
        {
            EmployeeController controller = new EmployeeController();
            ViewResult result = controller.Index("Gender", "Male1", 5, "Gender desc") as ViewResult;
            Assert.IsFalse(((IPagedList)result.Model).TotalItemCount > 0);
        }

    }
}