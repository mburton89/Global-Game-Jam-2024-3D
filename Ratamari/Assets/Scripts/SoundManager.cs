using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [SerializeField] float minRandomPitch;
    [SerializeField] float maxRandomPitch;

    [SerializeField] List<AudioSource> obstacleHitSounds;
    int obstacleHitSoundIndex;

    [SerializeField] List<AudioSource> smallItemCollectSounds;
    int smallItemCollectSoundIndex;

    [SerializeField] List<AudioSource> mediumItemCollectSounds;
    int mediumItemCollectSoundIndex;

    [SerializeField] List<AudioSource> bigItemCollectSounds;
    int bigItemCollectSoundIndex;

    [SerializeField] List<AudioSource> squeakSounds;
    int squeakSoundIndex;

    [SerializeField] List<AudioSource> startGameSounds;
    int startGameSoundIndex;

    [SerializeField] List<AudioSource> fartSounds;
    int fartSoundIndex;

    [SerializeField] List<AudioSource> jumpSounds;
    int jumpSoundIndex;

    [SerializeField] List<AudioSource> carHornSounds;
    int carHornSoundIndex;

    [SerializeField] List<AudioSource> roadBlockSounds;
    int roadBlockSoundIndex;

    public enum SoundEffect
    {
        ObstacleHit,
        SmallItemCollect,
        MediumItemCollect,
        BigItemCollect,
        SqueakSound,
        StartGameSound,
        FartSound,
        JumpSound,
        CarHornSound,
        RoadBlockSound
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySound(SoundEffect soundEffect)
    {
        AudioSource audioSourceToPlay;
        float randPitch = Random.Range(minRandomPitch, maxRandomPitch);

        if (soundEffect == SoundEffect.ObstacleHit)
        {
            audioSourceToPlay = obstacleHitSounds[obstacleHitSoundIndex];
            if (obstacleHitSoundIndex < obstacleHitSounds.Count - 1)
            {
                obstacleHitSoundIndex++;
            }
            else
            {
                obstacleHitSoundIndex = 0;
            }
        }

        else if (soundEffect == SoundEffect.SmallItemCollect)
        {
            audioSourceToPlay = smallItemCollectSounds[smallItemCollectSoundIndex];
            if (smallItemCollectSoundIndex < smallItemCollectSounds.Count - 1)
            {
                smallItemCollectSoundIndex++;
            }
            else
            {
                smallItemCollectSoundIndex = 0;
            }
        }

        else if (soundEffect == SoundEffect.MediumItemCollect)
        {
            audioSourceToPlay = mediumItemCollectSounds[mediumItemCollectSoundIndex];
            if (mediumItemCollectSoundIndex < mediumItemCollectSounds.Count - 1)
            {
                mediumItemCollectSoundIndex++;
            }
            else
            {
                mediumItemCollectSoundIndex = 0;
            }
        }

        else if (soundEffect == SoundEffect.BigItemCollect)
        {
            audioSourceToPlay = bigItemCollectSounds[bigItemCollectSoundIndex];
            if (bigItemCollectSoundIndex < bigItemCollectSounds.Count - 1)
            {
                bigItemCollectSoundIndex++;
            }
            else
            {
                bigItemCollectSoundIndex = 0;
            }
        }

        else if (soundEffect == SoundEffect.SqueakSound)
        {
            audioSourceToPlay = squeakSounds[squeakSoundIndex];
            if (squeakSoundIndex < squeakSounds.Count - 1)
            {
                squeakSoundIndex++;
            }
            else
            {
                squeakSoundIndex = 0;
            }
        }

        else if (soundEffect == SoundEffect.StartGameSound)
        {
            audioSourceToPlay = startGameSounds[startGameSoundIndex];
            if (startGameSoundIndex < startGameSounds.Count - 1)
            {
                startGameSoundIndex++;
            }
            else
            {
                startGameSoundIndex = 0;
            }
        }

        else if (soundEffect == SoundEffect.FartSound)
        {
            audioSourceToPlay = fartSounds[fartSoundIndex];
            if (fartSoundIndex < fartSounds.Count - 1)
            {
                fartSoundIndex++;
            }
            else
            {
                fartSoundIndex = 0;
            }
        }

        else if (soundEffect == SoundEffect.JumpSound)
        {
            audioSourceToPlay = jumpSounds[jumpSoundIndex];
            if (jumpSoundIndex < jumpSounds.Count - 1)
            {
                jumpSoundIndex++;
            }
            else
            {
                jumpSoundIndex = 0;
            }
        }

        else if (soundEffect == SoundEffect.CarHornSound)
        {
            audioSourceToPlay = carHornSounds[carHornSoundIndex];
            if (carHornSoundIndex < carHornSounds.Count - 1)
            {
                carHornSoundIndex++;
            }
            else
            {
                carHornSoundIndex = 0;
            }
        }

        else if (soundEffect == SoundEffect.RoadBlockSound)
        {
            audioSourceToPlay = roadBlockSounds[roadBlockSoundIndex];
            if (roadBlockSoundIndex < roadBlockSounds.Count - 1)
            {
                roadBlockSoundIndex++;
            }
            else
            {
                roadBlockSoundIndex = 0;
            }
        }

        else
        {
            audioSourceToPlay = null;
            Debug.LogError("Audio Source Not Assigned");
        }

        audioSourceToPlay.pitch = randPitch;
        audioSourceToPlay.Play();
    }
}
