using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;
public class LipSync : MonoBehaviour
{

    //private Transform mouth;
    private Vector3 initialPos;
    public Vector3 endPos;

    private bool initialized = false;
    private bool microphoneClip = false;
    private AudioClip recordedClip;

    private const int FREQUENCY = 48000;
    private const int SAMPLECOUNT = 1024;
    private const float REFVALUE = 0.1f;    // RMS value for 0 dB.
    private const float THRESHOLD = 0.02f;  // Minimum amplitude to extract pitch (recieve anything)

    public float distanceToInvoke;
    private float[] samples;           // Samples
    //private float[] spectrum;          // Spectrum
    public float dbValue, rmsValue;
    private float pitchValue;          // Pitch - Hz (is this frequency?)
    public int clamp = 160;            // Used to clamp dB
    public AudioSource audio;
    private float time, elapsedTime;
    public int audioSampleRate;
    public string microphone;
    private List<string> options = new List<string>();
    public Slider volumeSlider;
    public bool hasPlayed = false;
    public UnityEvent @event;
    public Transform character, enemy;
    Vector3 charPos, enemyPos;
    public void Init()
    {
        if (initialized)
            return;
        samples = new float[SAMPLECOUNT];
        //spectrum = new float[SAMPLECOUNT];

        //mouth = transform;
        //initialPos = mouth.localPosition;
        if (audio == null)
            gameObject.AddComponent<AudioSource>();
        audio.playOnAwake = false;
        audio.loop = true;
        enabled = false;
        initialized = true;
    }

    public void StartClipLipSync(AudioClip clip, bool fromMicrophone)
    {
        Init();
        audio.clip = clip;
        audio.Play();
        enabled = true;
        microphoneClip = fromMicrophone;
        Debug.Log("Clip started for " + transform.root.gameObject.name);
    }

    public float PauseClip()
    {
        audio.Pause();
        return audio.time;
    }

    public void StopClip()
    {
        Init();
        audio.Stop();
    }

    public void RestartClip(AudioClip clip, float t)
    {
        Init();
        audio.clip = clip;
        audio.time = t;
        audio.Play();
    }

    public void RestartClip(float t)
    {
        Init();
        audio.time = t;
        audio.Play();
    }

    public void RestartClip()
    {
        Init();
        audio.Stop();
        audio.Play();
    }

    // Use this for initialization
    public void StartMicrophoneLipSync()
    {
        AudioConfiguration audioConfiguration = AudioSettings.GetConfiguration();
        audioSampleRate = audioConfiguration.sampleRate;
        options.Add("None");
        foreach (string device in Microphone.devices)
        {
            if (microphone == null)
            {
                //Set default mic to first mic found.
                microphone = device;
            }
            options.Add(device);
        }
        Init();
        if (Microphone.devices.Length > 0)
        {
            if (PlayerPrefsManager.GetMicrophone() != 0)
                microphone = options[PlayerPrefsManager.GetMicrophone()];
            else
                return;
            audio.clip = Microphone.Start(microphone, true, 999, audioSampleRate);
            while (!(Microphone.GetPosition(microphone) > 0))
            {
            }
            audio.Play();
            //audio.mute = true;
            enabled = true;
            Debug.Log("Microphone started for " + transform.root.gameObject.name);
        }
        else
            enabled = false;

        microphoneClip = true;
    }

    public AudioClip GetRecordedClip()
    {
        return recordedClip;
    }

    void OnDestroy()
    {
        if (Microphone.IsRecording(null))
            Microphone.End(null);
        Destroy(audio);
    }

    public void StopMicrophone()
    {
        if (audio == null)
            return;
        if (Microphone.IsRecording(null))
        {
            Microphone.End(null);
        }

        recordedClip = audio.clip;
        //DestroyImmediate(audio);
        initialized = false;
    }

    //This could be programmed as InvokeRepeating
    void Update()
    {
        if(initialized == true)
        AnalyzeSound();

        //if (mouth == null)
        //return;
        microphone = options[PlayerPrefsManager.GetMicrophone()];
        float freq = HumanFreq(200, 800) * 1000;
        if (freq > 2 && freq < 50)
        {

            float step = Mathf.SmoothStep(0, 1, Mathf.SmoothStep(0, 1, elapsedTime / time));
            //mouth.localPosition = Vector3.Lerp(initialPos, endPos, step);
            elapsedTime += Time.deltaTime;
        }
        else
        {
            //mouth.localPosition = initialPos;
            time = 0.3f;
            elapsedTime = 0;
        }
    }

    /// Analyzes the sound, to get volume and pitch values.
    private void AnalyzeSound()
    {
        if (audio == null)
            return;
        // Get all of our samples from the mic.
        audio.GetOutputData(samples, 0);
        // Sums squared samples
        float sum = 0;
        for (int i = 0; i < SAMPLECOUNT; i++)
        {
            sum += Mathf.Pow(samples[i], 2);
        }
        // RMS is the square root of the average value of the samples.
        rmsValue = Mathf.Sqrt(sum / SAMPLECOUNT);
        dbValue = Mathf.Clamp(30 * (rmsValue / REFVALUE), 0, 100);
        if (dbValue >= 40 && calculateDistance() <= distanceToInvoke)
        {
            @event.Invoke();
            hasPlayed = true;
        }
        volumeSlider.value = dbValue;
        float maxV = 0;
        int maxN = 0;
        float freqN = maxN;
        pitchValue = freqN * 24000 / SAMPLECOUNT;
    }
    int calculateDistance()
    {
        charPos = character.transform.position;
        enemyPos = enemy.transform.position;
        Debug.Log(((int)Vector3.Distance(charPos, enemyPos)));
        return ((int)Vector3.Distance(charPos, enemyPos));
    }
    private float HumanFreq(float fLow, float fHigh)
    {
        int n1 = (int)Mathf.Floor(fLow * SAMPLECOUNT * 2 / FREQUENCY);
        int n2 = (int)Mathf.Floor(fHigh * SAMPLECOUNT * 2 / FREQUENCY);
        float sum = 0;
        // average the volumes of frequencies fLow to fHigh
        return sum / (n2 - n1 + 1);
    }
}