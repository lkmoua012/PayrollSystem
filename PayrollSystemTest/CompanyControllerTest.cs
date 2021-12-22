using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PayrollSystem;
using PayrollWeb.Models;

namespace PayrollWeb.Controllers
{
    [TestClass]
    public class CompanyControllerTest
    {
        private IPaySystemService svc;
        private CompanyController controller;
        [TestInitialize]
        public void TestSetup()
        {
            svc = Mock.Of<IPaySystemService>();
            Mock.Get(svc).Setup(s => s.GetCompanyDetail(1)).Returns(("123", "Acme", "123 Easy"));
            controller = new CompanyController(svc);
        }

        [TestMethod]
        public void TestCompanyControllerGetDetail()
        {
            var result = controller.Detail(1);
            Mock.Get(svc).Verify(s => s.GetCompanyDetail(1));
        }

        [TestMethod]
        public void TestCompanyControllerSaveDetail()
        {
            var model = new CompanyDetailViewModel()
            {
                Id = 0,
                TaxId = "12-1234567",
                StreetAddress = "123 Easy",
                Name = "Acme"
            };
            var result = controller.SaveDetail(model);
            Mock.Get(svc).Verify(s => s.SaveCompanyDetail(0, "12-1234567", "Acme", "123 Easy"));
        }
    }
}
