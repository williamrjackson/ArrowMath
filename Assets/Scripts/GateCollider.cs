using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using Wrj;

public class GateCollider : MonoBehaviour
{
    [SerializeField]
    private TextMeshPro text;
    private MathBehavior mathBehavior;

    public UnityAction OnPassed;

    public void SetMath(MathBehavior.MathFunction function, int value)
    {
        mathBehavior = new MathBehavior(function, value);
        RefreshLabel();
        RefreshColor();
    }
    public void SetMath(MathBehavior behavior)
    {
        mathBehavior = behavior;
        RefreshLabel();
        RefreshColor();
    }
    public void RefreshLabel()
    {
        if (mathBehavior != null)
        {
            text.text = mathBehavior.ToString();
        }
    }
    public void RefreshColor()
    {
        SetColor(Utils.RandomBrightColor);
    }
    public void SetColor(Color color)
    {
        transform.Color(color, .25f);
    }
    public int PerformMath(int input)
    {
        return mathBehavior.PerformFunction(input);
    }
    public void ReportPassage()
    {
        OnPassed();
    }
}
