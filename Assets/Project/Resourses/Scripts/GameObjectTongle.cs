using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectTongle : MonoBehaviour
{
    [SerializeField] private List<GameObject> gameObjects;

    public void Tongle(int index)
    {
        foreach (var item in gameObjects)
        {
            item.SetActive(false);
        }
        gameObjects[index].SetActive(true);
    }
}
