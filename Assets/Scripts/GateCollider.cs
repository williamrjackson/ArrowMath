using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Wrj;

public class GateCollider : MonoBehaviour
{
    [SerializeField]
    private TextMeshPro text;
    private MathBehavior mathBehavior;

    public void SetMath(MathFunction function, int value)
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
        transform.Color(Utils.RandomBrightColor, .25f);
    }
    public int PerformMath(int input)
    {
        return mathBehavior.PerformFunction(input);
    }
}
