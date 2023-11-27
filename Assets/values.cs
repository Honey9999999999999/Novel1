using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class values : MonoBehaviour
{
    Text text;
    Save save;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        save = Progress.instance.save;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = $"level = {save.level}\n" +
            $"unity = {save.playerInfo.unity}\n" +
            $"blender = {save.playerInfo.blender}\n" +
            $"CSharp = {save.playerInfo.cSharp}\n" +
            $"morgan = {save.playerInfo.morgan}\n" +
            $"joly = {save.playerInfo.joly}\n" +
            $"vondarm = {save.playerInfo.vondarm}";
    }
}
