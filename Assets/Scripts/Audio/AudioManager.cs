using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Singleton Pattern
    // 1. Static access point
    public static AudioManager Instance;

    [Header("PlayList")]
    [SerializeField] private AudioPlaylist playlist;

    [Header("Music")]
    [Tooltip("Playing looping background tracks")]
    [SerializeField] private AudioSource musicSource;

    [Header("SFX")]
    [Tooltip("Plays one-shot sound effects")]
    [SerializeField] private AudioSource sfxSource;

    private void Awake()
    {
        // Singleton Pattern Logic
        // 2. Create the reference to the instance, if it hasn't been created yet!
        if(Instance == null)
        {
            // I'm the first one, I am THE instance
            Instance = this;

            // Persist this across scenes. 
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // If another audiomanager is trying to be created, destroy it.
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Safety check!
        if (playlist != null && playlist.menuTheme != null)
        {
            PlayMenuMusic();
        }
    }

    /*
    public void PlayMenuMusic()
    {
        PlayMusic(playlist.menuTheme);
    }
    */
    public void PlayMenuMusic() => PlayMusic(playlist.menuTheme);
    public void PlayLevelMusic() => PlayMusic(playlist.levelTheme);
    public void PlayJumpSFX() => sfxSource.PlayOneShot(playlist.jump);

    private void PlayMusic(AudioClip clip)
    {
        if(musicSource.clip == clip)
        {
            return; // If I am playing the same clip, just return. Prevents restarting if already playing
        }

        musicSource.clip = clip;
        musicSource.Play();
    }
}
