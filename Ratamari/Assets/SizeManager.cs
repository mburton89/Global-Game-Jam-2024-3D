using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SizeManager : MonoBehaviour
{
    public static SizeManager Instance;

    public int numberOfItemsNeededToCollectBeforeLevelUp;
    public int itemsCollectedForLevelUp;

    public Image radialFill;

    public TextMeshProUGUI sizeLabel;

    [HideInInspector] public bool achievedMaxSize = false;

    public enum BallSize
    { 
        Small,
        Medium,
        Large,
    }

    public BallSize currentBallSize;

    void Awake()
    {
        Instance = this;
        currentBallSize = BallSize.Small;
        radialFill.fillAmount = 0;
    }


    public void HandleItemCollected()
    {
        SoundManager.Instance.PlaySound(SoundManager.SoundEffect.SmallItemCollect);

        itemsCollectedForLevelUp++;

        if (itemsCollectedForLevelUp > numberOfItemsNeededToCollectBeforeLevelUp)
        {
            if (currentBallSize == BallSize.Small)
            {
                currentBallSize = BallSize.Medium;
                sizeLabel.SetText("M");
                itemsCollectedForLevelUp = 0;

                if (SoundManager.Instance != null)
                {
                    SoundManager.Instance.PlaySound(SoundManager.SoundEffect.StartGameSound);
                }

                numberOfItemsNeededToCollectBeforeLevelUp *= 2;

                foreach (GrannyRag rag in FindObjectsOfType<GrannyRag>())
                {
                    rag.DisableColliders();
                }
            }
            else if (currentBallSize == BallSize.Medium)
            {
                currentBallSize = BallSize.Large;
                sizeLabel.SetText("L");
                itemsCollectedForLevelUp = 0;

                if (SoundManager.Instance != null)
                {
                    SoundManager.Instance.PlaySound(SoundManager.SoundEffect.StartGameSound);
                }
            }
            else if (currentBallSize == BallSize.Large && !achievedMaxSize)
            {
                sizeLabel.SetText("XL");
                achievedMaxSize = true;
                if (SoundManager.Instance != null)
                {
                    SoundManager.Instance.PlaySound(SoundManager.SoundEffect.StartGameSound);
                }
            }
        }   

        radialFill.fillAmount = (float)itemsCollectedForLevelUp / (float)numberOfItemsNeededToCollectBeforeLevelUp;

        RunningRat.Instance.MoveUp();
    }

    public void HandleItemsLost(int itemsLost)
    {
        print("Prop was removed from ball!");

        SoundManager.Instance.PlaySound(SoundManager.SoundEffect.FartSound);

        itemsCollectedForLevelUp -= itemsLost;
        radialFill.fillAmount = (float)itemsCollectedForLevelUp / (float)numberOfItemsNeededToCollectBeforeLevelUp;

        RunningRat.Instance.MoveDown();
    }
}
