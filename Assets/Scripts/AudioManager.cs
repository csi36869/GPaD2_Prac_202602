using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("Audio Sources")]
    [SerializeField] private AudioSource sfxSource;
    [SerializeField] private AudioSource musicSource;

    [Header("BGM")]
    public AudioClip bgm;

    [Header("Sound Effects")]
    public AudioClip hitWall;
    public AudioClip hitEnemy;
    public AudioClip fire;

    void Start()
    {
        PlayMusic(bgm);
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySFX(AudioClip clip)
    {
        if (clip != null)
        {
            sfxSource.PlayOneShot(clip);
        }
    }

    public void StopSFX()
    {
        sfxSource.Stop();
    }

    public void PlayMusic(AudioClip music)
    {
        if (musicSource.clip == music) return;

        musicSource.clip = music;
        musicSource.loop = true;
        musicSource.Play();
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }
}