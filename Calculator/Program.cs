class MainClass
{
    
    static void Main(string[] args)
    {
        bool blnDebug = false;
        DataHandler DataHandlerInstance = new DataHandler();
        Calculator CalculatorInstance = new Calculator();

        if (args.Length == 0)
        {
            Console.WriteLine("Calculator [delimited numbers]");
        }
        else
        {
            if (blnDebug == true)
            {
                int intCounter = 0;

                foreach (string strValue in args)
                {
                    Console.WriteLine("Argument " + intCounter.ToString() + ": " + strValue);
                }
            }

            try
            {
                DataHandlerInstance.ParseData(args[0]);
                DataHandlerInstance.ValidateData();

                for (int i = 0; i < DataHandlerInstance.ValueArray.Length; i++)
                {
                    CalculatorInstance.AddValue(DataHandlerInstance.ValueArray[i]);
                    Console.Write(DataHandlerInstance.ValueArray[i].ToString());
                    if (i != (DataHandlerInstance.ValueArray.Length - 1))
                    {
                        Console.Write("+");
                    }
                }
                Console.WriteLine(" = " + CalculatorInstance.CurrentValue.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine("Error - " + e.Message);
            }
            
    
        }
    }
}



