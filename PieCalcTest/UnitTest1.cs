using Interview_Refactor1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PieCalcTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMaxPiesGenerated()
        {
            List<RecipeIngredientCalculator.Ingredient> ingredients = new List<RecipeIngredientCalculator.Ingredient>();
            ingredients.Add(new RecipeIngredientCalculator.Ingredient(){ quantity = 2, measurementUnit = "cups", name = "orange juice"});

            List<RecipeIngredientCalculator.Ingredient> recipe = new List<RecipeIngredientCalculator.Ingredient>();
            recipe.Add(new RecipeIngredientCalculator.Ingredient(){ quantity = 1, measurementUnit = "cups", name = "orange juice"});

            int maxAmount = RecipeIngredientCalculator.CalculateMaxAmount(ingredients, recipe);

            Assert.AreEqual(maxAmount, 2);
        }

        [TestMethod]
        public void TestMaxPiesGenerated()
        {
            List<RecipeIngredientCalculator.Ingredient> ingredients = new List<RecipeIngredientCalculator.Ingredient>();
            ingredients.Add(new RecipeIngredientCalculator.Ingredient(){ quantity = 2, measurementUnit = "cups", name = "orange juice"});

            List<RecipeIngredientCalculator.Ingredient> recipe = new List<RecipeIngredientCalculator.Ingredient>();
            recipe.Add(new RecipeIngredientCalculator.Ingredient(){ quantity = 1, measurementUnit = "cups", name = "orange juice"});

            List<RecipeIngredientCalculator.Ingredient> leftOvers = RecipeIngredientCalculator.CalculateLeftovers(ingredients, recipe, 1);

            Assert.AreEqual(leftOvers[0].quantity, 1);
        }
    }
}
