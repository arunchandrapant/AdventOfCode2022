using Day01;

namespace Day01Tests
{
    [TestClass]
    public class ElfCaloriesTests
    {

        private readonly IEnumerable<IEnumerable<long>> elvesEatables = ElfCalories.GetElvesEatablesFromInput("./data/test_input");


        [TestMethod]
        public void Test_GetMaxCaloriesWithAnyElf()
        {
            // Arrange

            // Act
            var maxCalories = ElfCalories.GetMaxCaloriesWithAnyElf(elvesEatables);

            // Assert
            Assert.AreEqual(maxCalories, 24000);
        }

        [TestMethod]
        public void Test_GetTotalCaloriesWithTopThreeElves()
        {
            // Arrange

            // Act
            var topThreeCalories = ElfCalories.GetTotalCaloriesWithTopThreeElves(elvesEatables);

            // Assert
            Assert.AreEqual(topThreeCalories, 45000);
        }
    }
}