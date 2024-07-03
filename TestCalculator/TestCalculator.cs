
namespace TestCalculator
{
    [TestClass]
    public class TestCalculator
    {
        [TestMethod]
        public void AddValue_PostiveNumbers()
        {
            Calculator calc = new Calculator() ;
            calc.AddValue(1);
            calc.AddValue(3);
            Assert.AreEqual(calc.CurrentValue, 4);
        }

        [TestMethod]
        public void AddValue_MixedNumbers()
        {
            Calculator calc = new Calculator();
            calc.AddValue(5);
            calc.AddValue(-2);
            Assert.AreEqual(calc.CurrentValue, 3);
        }
    }
}