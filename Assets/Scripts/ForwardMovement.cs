using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardMovement : MonoBehaviour
{
    public float speed;

    private float SpeedOverTime => speed * Time.deltaTime;
    void Update()
    {
        transform.position = transform.PosInDir(forward: SpeedOverTime);
    }
}
