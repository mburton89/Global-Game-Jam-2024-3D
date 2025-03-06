using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

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

    [SerializeField] List<AudioSource> musicTracks;
    int musicSoundIndex;

    public AudioSource clipPlayer;

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
        RoadBlockSound,
        musicTracks
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

    private void Start()
    {
        PlayMusic(SoundEffect.musicTracks);
    }

    public void PlayMusic(SoundEffect soundEffect)
    {
        AudioSource audioSourceToPlay;
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
            PortraitManager.Instance.HitCarFace();
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
            PortraitManager.Instance.HitRoadblockFace();
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

    public void PlayAudioClip(AudioClip audioClip)
    {
        if (audioClip == null)
        {
            Debug.Log("Fart");
            PlaySound(SoundEffect.FartSound);
        }
        else
        {
            Debug.Log("sfxPLayed");
            clipPlayer.clip = audioClip;
            float randPitch = Random.Range(minRandomPitch, maxRandomPitch);
            clipPlayer.pitch = randPitch;
            clipPlayer.Play();
        }
        
    }
    public void FadeToSonicMusic()
    {
        musicTracks[0].DOFade(0, 2f);
        musicTracks[1].DOFade(1, 2f);
    }

    public void FadeToCheeseMusic()
    {
        musicTracks[1].DOFade(0, 2f);
        musicTracks[0].DOFade(1, 2f);
    }
}
