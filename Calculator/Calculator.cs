using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Calculator
{
    int _intCurrentValue;

    public Calculator()
    {
        _intCurrentValue = 0;
    }

    public int CurrentValue
    { get { return _intCurrentValue; } }

    public void AddValue(int intValue)
    {
        _intCurrentValue += intValue;
    }

    public void ClearValue()
    {
        _intCurrentValue = 0;
    }
}

