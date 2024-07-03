using System.Net.Http.Headers;
using System.Runtime.CompilerServices;

class MainClass
{
    
    static void Main(string[] args)
    {
        bool blnDebug = false;
        DataHandler DataHandlerInstance = new DataHandler();
        Calculator CalculatorInstance = new Calculator();

        if (args.Length == 0)
        {
            Console.WriteLine("Calculator [comma-delimited numbers]");
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

            DataHandlerInstance.ParseData(args[0]);

            foreach (int intValue in DataHandlerInstance.ValueArray)
            {
                CalculatorInstance.AddValue(intValue);
            }
            Console.WriteLine("Total value equals " + CalculatorInstance.CurrentValue.ToString());
           
            
    
        }
    }
}



