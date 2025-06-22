using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip collectClip;
    public AudioClip orderTingClip;
    public AudioClip cashCollectedClip;
    public AudioClip milkSpawnnedClip;
    public AudioClip eggSpawnnedClip;

    public void PlayAudio(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
