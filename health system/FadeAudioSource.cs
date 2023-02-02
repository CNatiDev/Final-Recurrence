using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FadeAudioSource : MonoBehaviour
{
    [Header("Audio")]
    public AudioSource fadeInaudioSource;
    public AudioSource fadeOutaudioSource;
    public AudioSource heartBeat;
    public AudioSource whispers;
    public AudioClip clip;
    public AudioClip[] differentWhispers;
    public AudioClip lastClip, newClip;
    [Space]
    [Header("Parameters")]
    public float durationOut, durationIn, TargetVolumeOut, TargetVolumeIn, timeToRepeat, delay = 0;
    public bool fadedOut = false, playingAudio = false, shouldFadeOutOnCollision, shouldChangePan = false;
    [SerializeField] public bool randomSound;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && fadedOut == false && shouldFadeOutOnCollision == true)
        {
            AudioSourceFadeOut();
        }
    }
    private void Start()
    {
        //This will make the audio source play a random given sound if true
        if (randomSound == true)
            PlayRandomClip();
    }
    public void toBeInvoked()
    {
        //This will call the function every timeToRepeat seconds to play a random sound
        Invoke("PlayRandomClip", timeToRepeat);
    }
    public void PlayRandomClip()
    {
        //The function to play a random sound
        newClip = differentWhispers[Random.Range(0, differentWhispers.Length)];
        if (lastClip == null || lastClip != newClip)
            whispers.clip = newClip;
        else
            while(lastClip == newClip)
                newClip = differentWhispers[Random.Range(0, differentWhispers.Length)];
        lastClip = newClip;
        if (timeToRepeat == 0)
        timeToRepeat = whispers.clip.length + delay;
        if (shouldChangePan == true)
        {
            var chance = Random.Range(0, 1);
            if(chance <= 0.49f)
            {
                whispers.panStereo = Random.Range(-1f, -0.5f);
            }
            else
            {
                whispers.panStereo = Random.Range(0.5f, 1f);
            }
        }
        whispers.Play();
        toBeInvoked();
    }
    public void AudioSourceFadeOut()
    {
        //If faded out is false, then the song is playing so we want to fade it out
        if(fadedOut == false)
        StartCoroutine(StartFadeOut(fadeOutaudioSource, durationOut, TargetVolumeOut));
        playingAudio = false;
    }
    public void JustFadeIn()
    {
        //This will just fade in whatever audio source we gave
        StartCoroutine(StartFadeIn(fadeInaudioSource, durationIn, TargetVolumeIn));
    }
    public void JustFadeOut()
    {
        //This will just fade out whatever audio source we gave
        StartCoroutine(StartFadeOut(fadeOutaudioSource, durationOut, TargetVolumeOut));
    }
    public void AudioSourceFadeIn()
    {
        //If faded out is true, it means that we are no longer playing the audio, so we want to fade it in
        //If playing audio is false then we will also play a random heartbeat sound
        if(fadedOut == true)
        StartCoroutine(StartFadeIn(fadeInaudioSource, durationIn, TargetVolumeIn));
        if (fadedOut == false && playingAudio == false)
        {
            heartBeat.PlayOneShot(clip);
            StartCoroutine(PlayHeartBeat(clip.length));
            playingAudio = true;
        }
    }
    public IEnumerator StartFadeOut(AudioSource audioSource, float duration, float targetVolume)
    {
        //Simple fade out script
        float currentTime = 0;
        float start = audioSource.volume;

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
            yield return null;
        }
        Debug.Log("Sursa: " + this.name + "Nume clip " + audioSource.clip.name);
        fadedOut = true;
        yield break;
    }
    public IEnumerator StartFadeIn(AudioSource audioSource, float duration, float targetVolume)
    {
        //Copy pasted and made it into fading in
        float currentTime = 0;
        float start = audioSource.volume;
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
            yield return null;
        }
        fadedOut = false;
        yield break;
    }
    public IEnumerator PlayHeartBeat(float clipLength)
    {
        //Wait for the length of the clip before playing another one again
        yield return new WaitForSeconds(clipLength);
        playingAudio = false;
    }
    //StartCoroutine(FadeAudioSource.StartFade(AudioSource audioSource, float duration, float targetVolume));
}