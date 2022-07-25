using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PieCalcTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMaxPiesGenerated()
        {
            ApplePieGenerator.PieValues pieValues = ApplePieGenerator.GeneratePieValues(3, 2, 1, 2, 8);
            Assert.AreEqual(pieValues.maxCinnamonPies, 1);
            Assert.AreEqual(pieValues.maxRegularPies, 0);
            Assert.AreEqual(pieValues.leftOverApples, 0);	
            Assert.AreEqual(pieValues.leftOverSugar, 0);
            Assert.AreEqual(pieValues.leftOverFlour, 0);
            Assert.AreEqual(pieValues.leftOverCinnamon, 0);
            Assert.AreEqual(pieValues.leftOverButter, 2);
        }
    }
}
