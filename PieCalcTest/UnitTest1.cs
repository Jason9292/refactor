using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PieCalcTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMaxPiesGenerated()
        {
            PieIngredients pieIngredients = generateApplePie.GeneratePieValues(3, 2, 1, 2);
            Assert.AreEqual(pieIngredients.maxPies, 1);
            Assert.AreEqual(pieIngredients.leftOverApples, 0);	
            Assert.AreEqual(pieIngredients.leftOverSugar, 0);
            Assert.AreEqual(pieIngredients.leftOverFlour, 0);
            Assert.AreEqual(pieIngredients.leftOverCinnamon, 0);	
        }
    }
}
