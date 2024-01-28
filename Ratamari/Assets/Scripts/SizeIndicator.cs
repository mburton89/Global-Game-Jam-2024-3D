using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SizeIndicator : MonoBehaviour
{
    public static SizeIndicator Instance;

    public TextMeshProUGUI levelText;
    public TMP_Text currentSize;

    public Image level1Fill;
    public Image level2Fill;
    public Image level3Fill;

    #region "Making leveling up dynamic"
    /*public Image currentImageToFill;
    public GameObject[] levels;

    private bool isCurrentLevel;
    public int maxLevel;
    private int currentLevel;

    //Amount required to level;
    private float currentXP;
    public float xpToSize2 = 1000;
    public float xpToSize3 = 3000;*/
    #endregion

    void Awake()
    {
        Instance = this;
    }

    private void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            AddToSize(0.1f);
        }
    }

    public void AddToSize(float sizeToAdd)
    {
        if (level1Fill.fillAmount < 1f)
        {
            level1Fill.fillAmount += sizeToAdd;
        }
        else if (level2Fill.fillAmount < 1f && level1Fill.fillAmount >= 1f)
        {
            level2Fill.fillAmount += sizeToAdd;
            levelText.text = "2";
        }
        else if (level3Fill.fillAmount < 1f && level1Fill.fillAmount >= 1f && level2Fill.fillAmount >= 1f)
        {
            level3Fill.fillAmount += sizeToAdd;
            levelText.text = "3";
        }
    }
    
    /*
    #region "Honestly I'm Lost"
    public void CurrentSizeDeterminer()
    {
        if (currentXP >= xpToSize2 && currentXP < xpToSize3)
        {
            LevelUP();
        }
    }

    public void LevelUP()
    {
        currentLevel = levels.Length + 1;

        for (int i = 0; i < levels.Length; i++)
        {
            levels[i].SetActive(i == currentLevel);
        }
    }
    #endregion
    */
}
