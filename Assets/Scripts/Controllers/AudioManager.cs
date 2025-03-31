using UnityEngine;

public class AudioManager : SingletonMonoBehavior<AudioManager>
{
    public AudioSource musicSource;
    public AudioSource sfxSource;

    [SerializeField] public AudioClip[] bossBattleMusic;
    [SerializeField] public AudioClip[] mainMenuMusic;
    [SerializeField] public AudioClip[] gameplayMusic;
    [SerializeField] public AudioClip defeatMusic; //Defeat Defeated
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

    public void PlayLaserBulletSFX() {

        if (sfxSource == null || laserBulletSFX == null) return;
        sfxSource.PlayOneShot(laserBulletSFX);
    }
    public void PlayBulletSFX()
    {

        if (sfxSource == null || laserBulletSFX == null) return;
        sfxSource.PlayOneShot(laserBulletSFX);
    }

    public void PlayExplosionSFX()
    {

        if (sfxSource == null || explosionSFX == null) return;
        sfxSource.PlayOneShot(explosionSFX);
    }
    public void PlayBossExplosionSFX()
    {

        if (sfxSource == null || explosionSFX == null) return;
        sfxSource.PlayOneShot(explosionSFX);
    }
    public void PlayPlayerHitSFX()
    {

        if (sfxSource == null || explosionSFX == null) return;
        sfxSource.PlayOneShot(explosionSFX);
    }
    public void PlayPowerUpInvulnerabilitySFX()
    {

        if (sfxSource == null || explosionSFX == null) return;
        sfxSource.PlayOneShot(explosionSFX);
    }
    public void PlayPowerUpGigaSFX()
    {

        if (sfxSource == null || explosionSFX == null) return;
        sfxSource.PlayOneShot(explosionSFX);
    }
    public void PlayPowerUpMultiShotSFX()
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