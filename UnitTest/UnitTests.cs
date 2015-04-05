using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using IDElab2;
using System.Diagnostics;

namespace UnitTest
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void TestMethod()
        {
            IDElab2.ViewModels.ShipStatus vm = new IDElab2.ViewModels.ShipStatus();
            vm.fuel = 150;
            vm.health = -50;
            vm.sliderValue = 175;
            Assert.AreEqual(vm.health, 0);
            Assert.AreEqual(vm.fuel, 100);
            Assert.AreEqual(vm.sliderValue, 100);


        }

        [Microsoft.VisualStudio.TestPlatform.UnitTestFramework.AppContainer.UITestMethod]
        public void testFalse()
        {
            IDElab2.ViewModels.ShipStatus vm = new IDElab2.ViewModels.ShipStatus();
            vm.useHighPowerWeapons = true;
            vm.useWeapons = true;
            LogicClass.checkShipStatus(ref vm);
            Assert.AreEqual(vm.fuel, 98 - vm.sliderValue / 15);
            vm.fuel = 0;
            Assert.AreEqual(LogicClass.checkShipStatus(ref vm), false);
        }
        [Microsoft.VisualStudio.TestPlatform.UnitTestFramework.AppContainer.UITestMethod]
        public void testTrue()
        {
            IDElab2.ViewModels.ShipStatus vm = new IDElab2.ViewModels.ShipStatus();
            Assert.AreEqual(LogicClass.checkShipStatus(ref vm), true);
        }
    }
}
