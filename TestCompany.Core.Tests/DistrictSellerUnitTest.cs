using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestCompany.Core.DataLayer.Providers;

namespace TestCompany.Core.Tests
{
    [TestClass]
    public class DistrictSellerUnitTest
    {
        [TestMethod]
        public void TestMethodInsertDeleteDistrictSeller()
        {
            var provider = DataProviderManager.GetDistrictSeller(DataProvider.MsSql);
            var result = provider.Insert(1, 2, true);
            var result2 = provider.Delete(1, 2);

            Assert.AreEqual(true, result2 == result);
        }

        [TestMethod]
        public void TestMethodUpdateDistrictSeller()
        {
            var provider = DataProviderManager.GetDistrictSeller(DataProvider.MsSql);
            var result = provider.Update(2, 1, false);
            var result2 = provider.Update(2, 1, true);

            Assert.AreEqual(true, result == result2);
        }
    }
}
