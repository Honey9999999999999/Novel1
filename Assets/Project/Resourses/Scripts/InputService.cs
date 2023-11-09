using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class InputService : MonoBehaviour
{
    public delegate void Clicker();
    public delegate void Scroller(Vector2 scroll);

    public static event Clicker OnClick0;
    public static event Scroller OnScroll;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnClick0?.Invoke();
        }
        if(Input.mouseScrollDelta != Vector2.zero)
        {
            OnScroll?.Invoke(Input.mouseScrollDelta);
        }
    }
}
