using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : SingletonMonoBehavior<AudioManager>
{
    public AudioSource musicSource;
    public AudioSource sfxSource;

    [SerializeField] public AudioClip[] bossBattleMusic;
    [SerializeField] public AudioClip[] mainMenuMusic;
    [SerializeField] public AudioClip[] gameplayMusic;
    [SerializeField] public AudioClip ButtonClick; //Blasteriods-sfx bullet-laser
    [SerializeField] public AudioClip DefeatSFX; //Defeat Defeated
    [SerializeField] public AudioClip levelUpMusic;
    [SerializeField] public AudioClip laserBulletSFX; //Bullet SFX SFX_15c
    [SerializeField] public AudioClip BulletSFX; //Bullet-Explosion-PowerUpSFX Shoot
    [SerializeField] public AudioClip explosionSFX; //SFX- The Ultiomate 2017 16 bit mini Pack Explosion2 007 Wav
    [SerializeField] public AudioClip BossExplosionSFX;//Bullet-Explosion-PowerUpSFX Die
    [SerializeField] public AudioClip PlayerHitSFX; //SFX- The Ultiomate 2017 16 bit mini Pack Ouch 008
    [SerializeField] public AudioClip PowerUpInvulnerabilitySFX; //SFX- The Ultiomate 2017 16 bit mini Pack Powerup 006 wav
    [SerializeField] public AudioClip PowerUpGigaSFX; //SFX- The Ultiomate 2017 16 bit mini Pack Powerup 006 wav
    [SerializeField] public AudioClip PowerUpMultiShotSFX; //SFX- The Ultiomate 2017 16 bit mini Pack Powerup 006 wav


    private int currentTrackIndex = 0; 
    private AudioClip[] currentPlaylist;

    protected override void Awake()
    {
        base.Awake();
        Debug.Log("AudioManager Awake is called");
        if (Instance == this)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate instances
            return;
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded; // Listen for scene changes
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded; // Remove listener when destroyed
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (musicSource != null && !musicSource.isPlaying)
        {
            musicSource.Play(); // Resume music if it stopped
        }
    }

    private void Start()
    {
        PlayMainMenuMusic(); // Default to main menu music
    }

    public void PlayMainMenuMusic()
    {
        PlayPlaylist(mainMenuMusic);
        Debug.Log("Playing Main Menu Music");
    }

    public void PlayGameplayMusic()
    {
        PlayPlaylist(gameplayMusic);
        Debug.Log("Playing Gameplay Music");
    }

    public void PlayBossBattleMusic()
    {
        PlayPlaylist(bossBattleMusic);
        Debug.Log("Playing Boss Battle Music");
    }
    public void PlayDefeatSFX()
    {

        if (sfxSource == null || DefeatSFX == null) return;
        sfxSource.PlayOneShot(DefeatSFX);
    }
    public void PlayButtonClicks()
    {

        if (sfxSource == null || ButtonClick == null) return;
        sfxSource.PlayOneShot(ButtonClick);
    }

    public void PlayLaserBulletSFX() {

        if (sfxSource == null || laserBulletSFX == null) return;
        sfxSource.PlayOneShot(laserBulletSFX);
    }
    public void PlayBulletSFX()
    {

        if (sfxSource == null || laserBulletSFX == null) return;
        sfxSource.PlayOneShot(BulletSFX);
    }

    public void PlayExplosionSFX()
    {

        if (sfxSource == null || explosionSFX == null) return;
        sfxSource.PlayOneShot(explosionSFX);
    }
    public void PlayBossExplosionSFX()
    {

        if (sfxSource == null || BossExplosionSFX == null) return;
        sfxSource.PlayOneShot(BossExplosionSFX);
    }
    public void PlayPlayerHitSFX()
    {

        if (sfxSource == null || PlayerHitSFX == null) return;
        sfxSource.PlayOneShot(PlayerHitSFX);
    }
    public void PlayPowerUpInvulnerabilitySFX()
    {

        if (sfxSource == null || PowerUpInvulnerabilitySFX == null) return;
        sfxSource.PlayOneShot(PowerUpInvulnerabilitySFX);
    }
    public void PlayPowerUpGigaSFX()
    {

        if (sfxSource == null || PowerUpGigaSFX == null) return;
        sfxSource.PlayOneShot(PowerUpGigaSFX);
    }
    public void PlayPowerUpMultiShotSFX()
    {

        if (sfxSource == null || PowerUpMultiShotSFX == null) return;
        sfxSource.PlayOneShot(PowerUpMultiShotSFX);
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