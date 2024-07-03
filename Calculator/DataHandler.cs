using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class DataHandler
{
    int[] _intArrayValues = null;
    string _strErrorMessage = null;
    char _chrCustomDelimeter = '\0';

    public char CustomDelimeter
    {
        get { return _chrCustomDelimeter; }
    }

    public int[] ValueArray
    {
        get { return _intArrayValues; }
    }

    public string ErrorMessage
    {
        get { return _strErrorMessage; }
    }

    public DataHandler()
    {

    }

    public bool CheckCustomDelimeter(string strValue)
    {
        bool blnDelimeterFound = false;

        if ((strValue.Length == 3)
            && strValue[0] == '/'
            && strValue[1] == '/')
        {
            blnDelimeterFound = true;
            _chrCustomDelimeter = strValue[2];
        }

        return blnDelimeterFound;
    }

    public void ParseData(string strCSV)
    {
        bool blnIsNumeric;
        int intTempValue;
        string[] strArrayDelimiters = new string[2] { ",", "\\n" };
        string[] strArrayValues = strCSV.Split(strArrayDelimiters, StringSplitOptions.None);
        
        if (CheckCustomDelimeter(strArrayValues[0]) == true)
        {
            strArrayDelimiters = new string[3] { ",", "\\n", _chrCustomDelimeter.ToString() };
            strCSV = strCSV.Remove(0, 5);
            strArrayValues = strCSV.Split(strArrayDelimiters, StringSplitOptions.None);
        }
        _intArrayValues = new int[strArrayValues.Length];
 
        for (int i = 0; i < strArrayValues.Length; i++)
        {
            _intArrayValues[i] = 0;
            blnIsNumeric = int.TryParse(strArrayValues[i], out intTempValue);
            if (blnIsNumeric == true)
            {
                if (intTempValue <= 1000)
                {
                    _intArrayValues[i] = intTempValue;
                }
            }
        }


    }

    public void ValidateData()
    {

        foreach (int intValue in _intArrayValues)
        {
            if (intValue < 0)
            {
                throw new Exception("Negative value found");
            }
        }
    }

}

