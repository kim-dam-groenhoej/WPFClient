using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestCompany.Core.DataLayer.Providers;

namespace TestCompany.Core.Tests
{
    [TestClass]
    public class SellerUnitTest
    {
        [TestMethod]
        public void TestMethodReadSellerByDistrict()
        {
            var provider = DataProviderManager.GetSeller(DataProvider.MsSql);
            var result = provider.GetByDistrict(1);

            Assert.AreEqual(true, result.Count > 0);
        }
    }
}
