using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NeasEnergy.Core.DataLayer.Providers;

namespace NeasEnergy.Core.Tests
{
    /// <summary>
    /// Summary description for DistrictUnitTest
    /// </summary>
    [TestClass]
    public class DistrictUnitTest
    {
        [TestMethod]
        public void TestMethodReadDistricts()
        {
            var provider = DataProviderManager.GetDistrict(DataProvider.MsSql);
            var result = provider.GetAll();

            Assert.AreEqual(true, result.Count > 0);
        }

        [TestMethod]
        public void TestMethodReadDistrictInShop()
        {
            var provider = DataProviderManager.GetDistrict(DataProvider.MsSql);
            var result = provider.GetByShop(1);

            Assert.AreEqual(true, result.Count > 0);
        }
    }
}
