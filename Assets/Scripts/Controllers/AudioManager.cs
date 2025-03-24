using UnityEngine;

public class AudioManager : SingletonMonoBehavior<AudioManager>
{
    public AudioSource audioSource;
    public AudioSource sfxSource;

    public AudioClip[] mainMenuMusic;
    public AudioClip[] gameplayMusic;
    public AudioClip[] bossBattleMusic;
    public AudioClip defeatMusic;

    private int currentTrackIndex = 0; 
    private AudioClip[] currentPlaylist; 

    protected override void Awake()
    {
        base.Awake();
        if (Instance == this)
        {
            DontDestroyOnLoad(gameObject); // Keep this across scenes
        }
    }

    private void Start()
    {
        PlayMainMenuMusic(); // Default to main menu music
    }

    public void PlayMainMenuMusic()
    {
        PlayPlaylist(mainMenuMusic);
    }

    public void PlayGameplayMusic()
    {
        PlayPlaylist(gameplayMusic);
    }

    public void PlayBossBattleMusic()
    {
        PlayPlaylist(bossBattleMusic);
    }
    public void PlayDefeatMusic()
    {
        if (audioSource == null || defeatMusic == null) return;

        audioSource.Stop();
        audioSource.clip = defeatMusic;
        audioSource.loop = false; // No looping for defeat sound
        audioSource.Play();
    }

    private void PlayPlaylist(AudioClip[] playlist)
    {
        if (playlist == null || playlist.Length == 0 || audioSource == null) return;

        currentPlaylist = playlist;
        currentTrackIndex = 0;
        PlayCurrentTrack();
    }

    private void PlayCurrentTrack()
    {
        if (currentPlaylist == null || currentPlaylist.Length == 0) return;

        audioSource.Stop();
        audioSource.clip = currentPlaylist[currentTrackIndex];
        audioSource.Play();

        // Schedule the next track to play when the current one ends
        Invoke(nameof(PlayNextTrack), audioSource.clip.length);
    }

    private void PlayNextTrack()
    {
        if (currentPlaylist == null || currentPlaylist.Length == 0) return;

        currentTrackIndex = (currentTrackIndex + 1) % currentPlaylist.Length; // Loop through playlist
        PlayCurrentTrack();
    }
}