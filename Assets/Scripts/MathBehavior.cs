using System;
using UnityEngine;
using Wrj;
using Random = UnityEngine.Random;

public class MathBehavior
{
    public MathFunction function;
    public int value;

    public static MathFunction[] subtractiveFunctions => new MathFunction[] {MathFunction.Divide, MathFunction.Subtract};
    public static MathFunction[] additiveFunctions => new MathFunction[] {MathFunction.Multiply, MathFunction.Add};
    public static MathFunction[] allMathFunctions => new MathFunction[] {MathFunction.Divide, MathFunction.Subtract, MathFunction.Multiply, MathFunction.Add };
    public MathBehavior(MathFunction function, int value)
    {
        this.function = function;
        this.value = value;
    }
    public MathBehavior(int max, MathFunction[] fromFunctions = null)
    {
        // if no fromFunctions, choose from all.
        if (fromFunctions == null) fromFunctions = allMathFunctions;

        this.function = fromFunctions.GetRandom();
        this.value = Random.Range(1, max+1);
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

    public enum MathFunction
    {
        Divide,
        Multiply,
        Subtract,
        Add
    }
}