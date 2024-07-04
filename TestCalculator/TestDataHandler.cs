
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
        public void CheckCustomDelimter()
        {
            DataHandler handler = new DataHandler();
            handler.CheckCustomDelimeters("//[###]");
            Assert.AreEqual(handler.CustomDelimeters[0], "###");
        }

        [TestMethod]
        public void CheckCustomDelimters()
        {
            DataHandler handler = new DataHandler();
            handler.CheckCustomDelimeters("//[###][$$$]");
            Assert.AreEqual(handler.CustomDelimeters[0], "###");
            Assert.AreEqual(handler.CustomDelimeters[1], "$$$");
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
        public void ParseData_WithCustomDelimeter()
        {
            DataHandler handler = new DataHandler();
            handler.ParseData("//[***]\\n11***22***33");
            Assert.AreEqual(handler.CustomDelimeters[0], "***");
            Assert.AreEqual(handler.ValueArray[0], 11);
            Assert.AreEqual(handler.ValueArray[1], 22);
            Assert.AreEqual(handler.ValueArray[2], 33);
        }

        [TestMethod]
        public void ParseData_WithCustomDelimeter3()
        {
            DataHandler handler = new DataHandler();
            handler.ParseData("//[*][!!][r9r]\\n11r9r22*hh*33!!44");
            Assert.AreEqual(handler.CustomDelimeters[0], "*");
            Assert.AreEqual(handler.CustomDelimeters[1], "!!");
            Assert.AreEqual(handler.CustomDelimeters[2], "r9r");
            Assert.AreEqual(handler.ValueArray[0], 11);
            Assert.AreEqual(handler.ValueArray[1], 22);
            Assert.AreEqual(handler.ValueArray[2], 0);
            Assert.AreEqual(handler.ValueArray[3], 33);
            Assert.AreEqual(handler.ValueArray[4], 44);
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

        [TestMethod]
        public void ParseData_CleanGreaterThan1000()
        {
            DataHandler handler = new DataHandler();
            handler.ParseData("1,1001,3");
            Assert.AreEqual(handler.ValueArray[0], 1);
            Assert.AreEqual(handler.ValueArray[1], 0);
            Assert.AreEqual(handler.ValueArray[2], 3);
        }
    }
}
