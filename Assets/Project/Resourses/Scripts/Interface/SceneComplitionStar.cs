using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndStarComplition : MonoBehaviour
{
    [SerializeField] private Sprite simpleStar;
    [SerializeField] private Sprite secretStar;

    [SerializeField] private List<Image> images = new List<Image>();

    void Start()
    {
        Refresh();
    }

    public void Refresh()
    {
        for (int i = 0; i < Progress.instance.save.stars.Count; i++)
        {
            if (Progress.instance.save.stars[i] == true)
                if (i == 4)
                    images[i].sprite = secretStar;
                else
                    images[i].sprite = simpleStar;
        }
    }
}
