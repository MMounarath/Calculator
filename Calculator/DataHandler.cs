using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

public class DataHandler
{
    int[] _intArrayValues = null;
    string _strErrorMessage = null;
    string[] _strCustomDelimeters = null;

    public string[] CustomDelimeters
    {
        get { return _strCustomDelimeters; }
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

    public bool CheckCustomDelimeters(string strValue)
    {
        bool blnDelimeterFound = false;

        if (strValue[0] == '/'
            && strValue[1] == '/'
            && strValue[2] == '['
            && strValue[strValue.Length - 1] == ']')        
        {
            var regex = new Regex("\\[(.*?)\\]");
            var matches = regex.Matches(strValue);
            
            _strCustomDelimeters = new string[matches.Count];

            for (int i = 0; i < matches.Count; i++)
            {
                _strCustomDelimeters[i] = matches[i].Groups[1].Value; 
                blnDelimeterFound = true;
            }

        }
        
        return blnDelimeterFound;
    }

    public void ParseData(string strCSV)
    {
        bool blnIsNumeric;
        int intTempValue;
        string[] strArrayDelimiters = { ",", "\\n" };
        string[] strArrayValues = strCSV.Split(strArrayDelimiters, StringSplitOptions.None);
        
        if (CheckCustomDelimeters(strArrayValues[0]) == true)
        {
            strArrayDelimiters = new string[_strCustomDelimeters.Length + 2];
            _strCustomDelimeters.CopyTo(strArrayDelimiters, 0);
            strArrayDelimiters[_strCustomDelimeters.Length] = ",";
            strArrayDelimiters[_strCustomDelimeters.Length + 1] = "\\n";
            strCSV = strCSV.Remove(0, strArrayValues[0].Length + 2);
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

