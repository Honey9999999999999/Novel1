using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneComplition : MonoBehaviour
{
    [SerializeField] private Sprite simpleStar;
    [SerializeField] private Sprite secretStar;

    [SerializeField] private List<Image> images = new List<Image>();

    void Start()
    {
        int counter = 0;
        foreach (var item in Progress.instance.save.stars.Keys)
        {
            if (Progress.instance.save.stars[item] == true && counter < images.Count)
                if(counter == 4)
                    images[counter].sprite = secretStar;
                else
                    images[counter].sprite = simpleStar;
            counter++;
        } 
    }
}
