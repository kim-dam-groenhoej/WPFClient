using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestCompany.Core.DataLayer.Providers;
using TestCompany.Core.DataLayer;

namespace TestCompany.Core.Tests
{
    [TestClass]
    public class ShopUnitTest
    {
        [TestMethod]
        public void TestMethodGetByDistrict()
        {
            var provider = DataProviderManager.GetShop(DataProvider.MsSql);
            var result = provider.GetByDistrict(1);
            Assert.AreEqual(true, result.Count > 0);
        }

        [TestMethod]
        public void TestMethodGetAllShops()
        {
            var provider = DataProviderManager.GetShop(DataProvider.MsSql);
            var result = provider.GetAll();
            Assert.AreEqual(true, result.Count > 0);
        }

        [TestMethod]
        public void TestMethodDeleteShop()
        {
            var provider = DataProviderManager.GetShop(DataProvider.MsSql);
            var id = provider.Insert("test company");
            Assert.AreEqual(true, provider.Delete(id));
        }


        [TestMethod]
        public void TestMethodInsertShop()
        {
            var provider = DataProviderManager.GetShop(DataProvider.MsSql);
            var result = provider.Insert("test company");
            Assert.AreEqual(true, result > 0);
        }
    }
}
