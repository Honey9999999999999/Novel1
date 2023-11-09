using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Scrollble : MonoBehaviour
{
    public Vector2 scrollUpDistance;
    public Vector2 scrollDownDistance;

    private Vector3 startPosition;
    private Vector2 upDistance;
    private Vector2 downDistence;

    private void Start()
    {
        startPosition = transform.localPosition;
        UpdateDisctence();
    }

    public void Move(Vector3 distance)
    {
        Vector3 requiredPos = transform.localPosition - distance;

        if (   requiredPos.y <= upDistance.y && requiredPos.y >= downDistence.y 
            && requiredPos.x <= upDistance.x && requiredPos.x >= downDistence.x)
        {
            transform.localPosition = requiredPos;
        }
    }

    private void UpdateDisctence()
    {
        upDistance = (Vector2)startPosition + scrollUpDistance;
        downDistence = (Vector2)startPosition - scrollDownDistance;
    }
}
