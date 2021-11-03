using System;
using UnityEngine;
using Wrj;
using Random = UnityEngine.Random;

public class MathBehavior
{
    public MathFunction function;
    public int value;
    public MathBehavior(MathFunction function, int value)
    {
        this.function = function;
        this.value = value;
    }
    public int PerformFunction(int input)
    {
        switch (function)
        {
            case MathFunction.Divide:
                return Mathf.RoundToInt(input / value);
            case MathFunction.Multiply:
                return input * value;
            case MathFunction.Add:
                return input + value;
            default: // subtract
                return input - value;
        }
    }   
    public override string ToString()
    {
        string result = string.Empty;
        switch (function)
        {
            case MathFunction.Divide:
                result = "÷";
                break;
            case MathFunction.Multiply:
                result = "×";
                break;
            case MathFunction.Add:
                result = "+";
                break;
            case MathFunction.Subtract:
                result = "−";
                break;
        }
        result += $"{value}";
        return result;
    }
    public static MathBehavior RandomMath(int max)
    {
        Array functionValues = Enum.GetValues(typeof(MathFunction));
        MathFunction func = (MathFunction)functionValues.GetValue(Random.Range(0, functionValues.Length));
        return new MathBehavior(func, Random.Range(1, max+1));
    }
}
public enum MathFunction
{
    Divide,
    Multiply,
    Subtract,
    Add
}