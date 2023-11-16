using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BGAnimator : MonoBehaviour
{
    [SerializeField] private float speedAnimation;

    [SerializeField] private float targetAngle;
    [SerializeField] private Vector3 targetScale;

    [SerializeField] private bool isAnimDone = true;
    private float angleCounter = 0;

    public void StartAnimation()
    {
        isAnimDone = false;
        Rotate();
        Scaling();
    }

    public void Move()
    {
        if (!angleCounter.Equals(0) && Mathf.Abs(angleCounter) < Mathf.Abs(targetAngle))
        {
            Rotate();
            Scaling();
        }
        else
            StopAnimation();
    }
    private void Rotate()
    {
        float speedRotation = speedAnimation * Mathf.Sign(targetAngle) * Time.deltaTime;
        Quaternion rotationDelta = Quaternion.Euler(0f, 0f, speedRotation);
        transform.rotation = transform.rotation * rotationDelta;
        angleCounter += speedRotation;
    }
    private void Scaling()
    {
        float speedScalingX = (speedAnimation * Time.deltaTime) / targetAngle * (targetScale.x - 1);
        float speedScalingY = (speedAnimation * Time.deltaTime) / targetAngle * (targetScale.y - 1);
        float speedScalingZ = (speedAnimation * Time.deltaTime) / targetAngle * (targetScale.z - 1);

        transform.localScale += new Vector3(speedScalingX, speedScalingY, speedScalingZ);
    }

    private void StopAnimation()
    {
        angleCounter = 0;
        isAnimDone = true;
    }

    void Update()
    {
        if (!isAnimDone)
            Move();
    }
}
