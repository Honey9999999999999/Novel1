using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class MainMenuMover : MonoBehaviour
{
    private Vector3 currentMousePos;
    private Vector3 lastMousePos;
    private Vector3 targetPosition;

    public float moveSpeed = 5f;

    private Image image;

    private void Start()
    {
        targetPosition = transform.localPosition;
        image = GetComponent<Image>();
    }
    void Update()
    {
        currentMousePos = Input.mousePosition;
        if (currentMousePos != lastMousePos)
        {
            Vector3 vectorDiff = lastMousePos - currentMousePos;
            float diff = vectorDiff.x * vectorDiff.x + vectorDiff.y * vectorDiff.y + vectorDiff.z * vectorDiff.z;

            Vector3 add = moveSpeed * Time.deltaTime * ((diff > 50000) ? Vector3.zero : vectorDiff);
            if (Mathf.Abs((targetPosition + add).x) <= image.preferredWidth / 4 &&
                Mathf.Abs((targetPosition + add).y) <= image.preferredHeight / 4)
                targetPosition += add;            
        }
        lastMousePos = currentMousePos;
        transform.localPosition = Vector3.Lerp(transform.localPosition, targetPosition, Time.deltaTime);
    }
}
