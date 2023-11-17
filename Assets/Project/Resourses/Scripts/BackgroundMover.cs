using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuMover : MonoBehaviour
{
    private Vector3 currentMousePos;
    private Vector3 lastMousePos;
    private Vector3 targetPosition;

    public float moveSpeed = 5f;
    private void Start()
    {
        targetPosition = transform.position;
    }
    void Update()
    {        
        currentMousePos = Input.mousePosition;
        if (currentMousePos != lastMousePos)
        {
            Vector3 vectorDiff = lastMousePos - currentMousePos;
            float diff = vectorDiff.x * vectorDiff.x + vectorDiff.y * vectorDiff.y + vectorDiff.z * vectorDiff.z;

            targetPosition +=  moveSpeed * Time.deltaTime * ((diff > 50000) ? Vector3.zero : vectorDiff);            
        }
        lastMousePos = currentMousePos;
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime);
    }
}
