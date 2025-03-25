using UnityEngine;

public class AudioManager : SingletonMonoBehavior<AudioManager>
{
    public AudioSource musicSource;
    public AudioSource sfxSource;

    [SerializeField] public AudioClip[] bossBattleMusic;
    [SerializeField] public AudioClip[] mainMenuMusic;
    [SerializeField] public AudioClip[] gameplayMusic;
    [SerializeField] public AudioClip defeatMusic;
    [SerializeField] public AudioClip levelUpMusic;
    [SerializeField] public AudioClip laserBulletSFX;
    [SerializeField] public AudioClip explosionSFX;

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
        if (musicSource == null || defeatMusic == null) return;

        musicSource.Stop();
        musicSource.clip = defeatMusic;
        musicSource.loop = false; // No looping for defeat sound
        musicSource.Play();
    }

    public void PlayLaserSFX() {

        if (sfxSource == null || laserBulletSFX == null) return;
        sfxSource.PlayOneShot(laserBulletSFX);
    }
    public void PlayExplosionSFX()
    {

        if (sfxSource == null || explosionSFX == null) return;
        sfxSource.PlayOneShot(explosionSFX);
    }

    private void PlayPlaylist(AudioClip[] playlist)
    {
        if (playlist == null || playlist.Length == 0 || musicSource == null) return;

        currentPlaylist = playlist;
        currentTrackIndex = 0;
        PlayCurrentTrack();
    }

    private void PlayCurrentTrack()
    {
        if (currentPlaylist == null || currentPlaylist.Length == 0) return;

        musicSource.Stop();
        musicSource.clip = currentPlaylist[currentTrackIndex];
        musicSource.Play();

        // Schedule the next track to play when the current one ends
        Invoke(nameof(PlayNextTrack), musicSource.clip.length);
    }

    private void PlayNextTrack()
    {
        if (currentPlaylist == null || currentPlaylist.Length == 0) return;

        currentTrackIndex = (currentTrackIndex + 1) % currentPlaylist.Length; // Loop through playlist
        PlayCurrentTrack();
    }
}