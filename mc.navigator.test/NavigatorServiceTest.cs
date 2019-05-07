using mc.navigator.domain.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace mc.navigator.test
{
    [TestClass]
    public class NavigatorServiceTest
    {
        [TestMethod]
        public void BasicNavigatorTest()
        {
            var navigator = new NavigatorService();
            var result = navigator.Navigate(new System.Uri(@"https://www.iplocation.net/find-ip-address"), Method.get);

            Assert.IsTrue(!string.IsNullOrEmpty(result));
        }
    }
}
