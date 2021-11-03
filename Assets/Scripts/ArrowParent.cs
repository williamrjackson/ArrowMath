using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Wrj;

public class ArrowParent : MonoBehaviour
{
    [SerializeField]
    private LayoutGroupSunflower layoutGroup;
    [SerializeField]
    private ObjectPool pool;
    [SerializeField]
    float smoothTime = 1f;
    [SerializeField]
    float speed = 1f;
    [SerializeField]
    Vector2 positionBoundaries = Vector2.one;

    private int _childCount;
    public int ChildCount
    {
        set
        {
            _childCount = value;
            UpdateChildCount(_childCount);
        }
        get
        {
            return _childCount;
        }
    }
    private void Start()
    {
        UpdateChildCount(1);
    }
    private void UpdateChildCount(int count)
    {
        var activeArrows = pool.ActiveObjects;
        if (activeArrows.Count > count)
        {
            for (int i = 0; i < activeArrows.Count - count; i++)
            {
                pool.FinishWithObject(activeArrows[i]);
            }
        }
        else
        {
            for (int i = 0; i < count - activeArrows.Count; i++)
            {
                pool.GetObject();
            }
        }
        layoutGroup.Refresh();
    }
    private void OnTriggerEnter(Collider other)
    {
        // Debug.Log($"Collider: {other.gameObject.name}");
        GateCollider gate = other.gameObject.GetComponent<GateCollider>();
        if (gate != null)
        {
            UpdateChildCount(gate.PerformMath(pool.ActiveObjects.Count));
        }
    }

    Vector2 draggingMousePos;
    Vector2 mousePos;
    Vector2 vel;
    private void Update()
    {
        mousePos = Input.mousePosition;
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Down");
            draggingMousePos = mousePos;
        }
        else if (Input.GetMouseButton(0))
        {
            draggingMousePos = Vector2.SmoothDamp(draggingMousePos, mousePos, ref vel, smoothTime, float.MaxValue);
        }
        else {return;}
        var delta = (mousePos - draggingMousePos) * speed;
        Debug.Log($"Delta: {delta}");
        Vector3 target = transform.LocalPosInDir(up: delta.y, right: delta.x);
        float xLimit = Mathf.Abs(positionBoundaries.x);
        float yLimit = Mathf.Abs(positionBoundaries.y);
        target.x = Mathf.Clamp(target.x, -xLimit, xLimit);
        target.y = Mathf.Clamp(target.y, -yLimit, yLimit);
        transform.localPosition = target;
    }
}
