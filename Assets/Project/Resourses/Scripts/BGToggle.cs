using Fungus;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public enum BG
{
    DungeonCorn,
    LectionGameDev,
    LectionCSharp,
    LectionUnity,
    LectionBlender,
    Campfire,
    CSLog,
    CSGame,
    DMG,
    Joly,
    Valley,
    Black
}

[Serializable]
public class Background
{
    public BG name;
    public GameObject objectBG;
}

public class BGToggle : MonoBehaviour
{
    [SerializeField] [Min(0)] private float fadeTime;
    [SerializeField] private Image fadeImage;

    [SerializeField] private List<Background> backgrounds;

    [SerializeField] private BG requiredBG;

    private Flowchart flowchart;
    private Block activeBlock;
    private Command activeCommand;

    private bool isFadePlayed = false;
    private bool isFade = true;
    private bool isToggle = false;

    private void Start()
    {
        flowchart = FindObjectOfType<Flowchart>();

        if (flowchart == null)
            throw new Exception("Flowchart is not find");
    }
    private void Update()
    {
        if (isFadePlayed)
        {
            if (isFade)
            {
                ChangeAlphaTo(1);

                if (fadeImage.color.a == 1)
                    isFade = false;
            }                

            if(!isFade)
            {
                if(!isToggle)
                    Tongle(requiredBG);
                ChangeAlphaTo(0);
            }

            if (fadeImage.color.a == 0)
            {
                isFadePlayed = false;
                isToggle = false;
                isFade = true;

                flowchart.ExecuteBlock(activeBlock, activeCommand.CommandIndex + 1);
            }                
        }
    }

    public void ChangeBG(BG name)
    {
        isFadePlayed = true;
        requiredBG = name;

        activeBlock = flowchart.SelectedBlock;
        activeCommand = activeBlock.ActiveCommand;
        flowchart.StopBlock(activeBlock.BlockName);
    }

    private void ChangeAlphaTo(float a)
    {
        if(fadeImage.color.a != a)
        {
            float direction = fadeImage.color.a < a ? 1 : -1;
            float stepAlpha = Time.deltaTime / fadeTime * 2 * direction;

            if ((fadeImage.color.a * direction) + (stepAlpha * direction) > a)
                stepAlpha = a - fadeImage.color.a;

            fadeImage.color += new Color(0, 0, 0, stepAlpha);
        }        
    }

    private void Tongle(BG name)
    {
        foreach (var background in backgrounds)
            background.objectBG.SetActive(false);

        foreach (var background in backgrounds)
            if(background.name == name)
            {
                background.objectBG.SetActive(true);
                break;
            }        

        isToggle = true;
    }
}
