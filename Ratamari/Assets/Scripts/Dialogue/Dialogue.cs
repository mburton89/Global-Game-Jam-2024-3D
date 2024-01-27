using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Dialogue
{
    public string name;

    //Probably convert from Sprite to Image for editor access
    public Image portrait;

    [TextArea(3, 10)]
    public string[] sentences;
}
