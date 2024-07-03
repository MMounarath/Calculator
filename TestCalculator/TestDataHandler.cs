
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

        [TestMethod]
        public void ParseData()
        {
            DataHandler handler = new DataHandler();
            handler.ParseData("1,2,3");
            Assert.AreEqual(handler.ValueArray[0], 1);
            Assert.AreEqual(handler.ValueArray[1], 2);
            Assert.AreEqual(handler.ValueArray[2], 3);
        }

        [TestMethod]
        public void ParseData_WithCharacters()
        {
            DataHandler handler = new DataHandler();
            handler.ParseData("5,tytyt");
            Assert.AreEqual(handler.ValueArray[0], 5);
            Assert.AreEqual(handler.ValueArray[1], 0);
        }

        [TestMethod]
        public void ParseData_WithEmpty()
        {
            DataHandler handler = new DataHandler();
            handler.ParseData("2,");
            Assert.AreEqual(handler.ValueArray[0], 2);
            Assert.AreEqual(handler.ValueArray[1], 0);
        }

        [TestMethod]
        public void ParseData_WithNewLine()
        {
            DataHandler handler = new DataHandler();
            handler.ParseData("1\\n2,3");
            Assert.AreEqual(handler.ValueArray[0], 1);
            Assert.AreEqual(handler.ValueArray[1], 2);
            Assert.AreEqual(handler.ValueArray[2], 3);        
        }
    }
}
