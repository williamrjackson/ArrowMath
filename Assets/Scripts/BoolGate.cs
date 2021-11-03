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
    
    // Start is called before the first frame update
    void Start()
    {
        _left.SetMath(MathBehavior.RandomMath(10));
        _right.SetMath(MathBehavior.RandomMath(10));
    }
}

