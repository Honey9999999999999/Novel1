using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneComplition : MonoBehaviour
{
    [SerializeField] private Sprite sprite;

    [SerializeField] private List<Image> images = new List<Image>();

    void Start()
    {
        int counter = 0;
        foreach (var item in Progress.instance.save.stars.Keys)
        {
            if (Progress.instance.save.stars[item] == true && counter < images.Count)
                images[counter].sprite = sprite;
            counter++;
        } 
    }
}
