using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NeasEnergy.Core.DataLayer.Providers;

namespace NeasEnergy.Core.Tests
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
