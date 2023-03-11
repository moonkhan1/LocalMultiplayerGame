using UnityEngine;
using UnityProject3.Sound;
using UnityProject3.Abstracts.Helpers;
namespace UnityProject3.Managers
{
    public class SoundManager : SingletonBase<SoundManager>
{
    public Sounds[] sounds;
    [SerializeField] public AudioSource MetalCrackSoundBullet;
    [SerializeField] public AudioSource MetalCrackSoundSword;
    [SerializeField] public AudioSource PlayerMoveSound;
    [SerializeField] public AudioSource EnemyMoveSound;
    private void Awake()
    {
        MakeSingleton(this);
        foreach (var s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.Clip;
            s.source.volume = s.Volume;
            s.source.pitch = s.Pitch;
            s.source.loop = s.Loop;
        }
    }

    private void Start() {
        Play("BackgroundMusic");
    }

    public void Play(string name) {
        Sounds s = System.Array.Find(sounds, sound => sound.Name == name);
        if (s == null)
            return;
        // s.source.Play();
        // For completely play all sounds without cutting some last of sounds
        s.source.mute = false;
        s.source.PlayOneShot(s.Clip);
    }
    public void Stop(string name) {
        Sounds s = System.Array.Find(sounds, sound => sound.Name == name);
        if (s == null)
            return;
        // s.source.Play();
        // For completely play all sounds without cutting some last of sounds
        s.source.mute = true;
    }

}
}
