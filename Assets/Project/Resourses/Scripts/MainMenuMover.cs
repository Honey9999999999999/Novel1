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
        lastMousePos = Input.mousePosition;
        targetPosition = transform.position;
    }
    void Update()
    {
        currentMousePos = Input.mousePosition;
        if (currentMousePos != lastMousePos)
        {
            targetPosition += (lastMousePos - currentMousePos) * moveSpeed * Time.deltaTime;
            
            lastMousePos = currentMousePos;
        }
        transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }
}
