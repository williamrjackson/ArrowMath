using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Wrj;

public class BoolGate : MonoBehaviour
{
    [SerializeField]
    private GateCollider _left;
    [SerializeField]
    private GateCollider _right;
    
    void Start()
    {
        _left.OnPassed += UpdatePosition;
        _right.OnPassed += UpdatePosition;
        Reset();
    }
    private void UpdatePosition()
    {
        Utils.DeferredExecution(.2f, () => 
        {
            transform.localPosition = transform.LocalPosInDir(forward:90f);
            Reset();
        });
    }
    private void Reset()
    {
        Color randCol = Utils.RandomBrightColor;
        Color oppCol = ColorHarmony.Complementary(randCol);
        MathBehavior.MathFunction[] randFunc;
        MathBehavior.MathFunction[] oppFunc;
        if (Utils.CoinFlip)
        {
            randFunc = MathBehavior.additiveFunctions;
            oppFunc = MathBehavior.subtractiveFunctions;
        }
        else
        {
            randFunc = MathBehavior.subtractiveFunctions;
            oppFunc = MathBehavior.additiveFunctions;
        }
        _left.SetMath(new MathBehavior(10, randFunc));
        _left.SetColor(randCol);
        _right.SetMath(new MathBehavior(10, oppFunc));
        _right.SetColor(oppCol);
    }
}

