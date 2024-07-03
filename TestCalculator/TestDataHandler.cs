
namespace TestCalculator
{
    [TestClass]
    public class TestDataHandler
    {
        [TestMethod]
        public void ValidateData_NegativeValueThrowException()
        {
            DataHandler handler = new DataHandler();
            handler.ParseData("1,-1");
            try
            {
                handler.ValidateData();
                Assert.Fail("Failed to throw exception on negative value");
            }
            catch (Exception e)
            {
                Assert.AreEqual(e.Message, "Negative value found");
            }
            
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
