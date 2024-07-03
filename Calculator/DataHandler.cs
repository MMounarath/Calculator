﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class DataHandler
{
    int[] _intArrayValues = null;
    string _strErrorMessage = null;

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

    public void ParseData(string strCSV)
    {
        bool blnIsNumeric;
        int intTempValue;
        string[] strArrayDelimiters = { ",", "\\n" };

        string[] strArrayValues = strCSV.Split(strArrayDelimiters, StringSplitOptions.None);
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

