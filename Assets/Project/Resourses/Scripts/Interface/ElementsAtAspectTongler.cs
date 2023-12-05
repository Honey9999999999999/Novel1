using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElementsAtAspectTongler : MonoBehaviour
{
    [SerializeField] private float _limiterToX;
    [SerializeField] private float _limiterToY;

    [SerializeField] private List<GameObject> _gameObjects;    

    private void Update()
    {
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;

        float currentAspectX = screenWidth / screenHeight;
        float currentAspectY = screenHeight / screenWidth;

        Debug.Log(currentAspectX + "/" + currentAspectY);

        if((!_limiterToX.Equals(0) && _limiterToX > currentAspectX) || (!_limiterToY.Equals(0) && _limiterToY > currentAspectY))
        {
            SetActiveGameObjects(false);
        }
        else
        {
            SetActiveGameObjects(true);
        }
    }

    private void SetActiveGameObjects(bool value)
    {
        foreach (var item in _gameObjects)
        {
            item.SetActive(value);
        }
    }
}
