
namespace TestCalculator
{
    [TestClass]
    public class TestDataHandler
    {
        [TestMethod]
        public void ValidateData_PassingValues()
        {
            DataHandler handler = new DataHandler();
            handler.ParseData("1,2");
            Assert.AreEqual(handler.ValidateData(), true);
        }

        [TestMethod]
        public void ValidateData_NonPassingValues()
        {
            DataHandler handler = new DataHandler();
            handler.ParseData("1,2,");
            handler.ValidateData();
            Assert.AreEqual(handler.ValidateData(), false);
        }

    }
}
