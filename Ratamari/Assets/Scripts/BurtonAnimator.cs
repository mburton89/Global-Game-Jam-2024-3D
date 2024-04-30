using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BurtonAnimator : MonoBehaviour
{
    public Image image;
    public List<Sprite> sprites;

    public float secondsBetweenFrames;

    void Start()
    {
        StartCoroutine(Animate());
    }

    private IEnumerator Animate()
    {
        for (int i = 0; i < sprites.Count; i++)
        { 
            yield return new WaitForSeconds(secondsBetweenFrames);
            image.sprite = sprites[i];
        }

        StartCoroutine(Animate());
    }
}
