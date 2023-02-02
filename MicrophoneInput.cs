using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine.Events;
[RequireComponent(typeof(AudioSource))]
public class MicrophoneInput : MonoBehaviour
{
	//Variables
	public static MicrophoneInput instance;
	public UnityEvent @event;
	public float changeSpeed;
	bool hasPlayed = false;
	public int audioSampleRate;
	public string microphone;
	public FFTWindow fftWindow;
	public Dropdown micDropdown;
	public Slider volumeSlider;
	public bool shouldCaptureMicrophone;
	public AudioMixerGroup mixerGroupMicrophone, mixerGroupMaster;

	public List<string> options = new List<string>();
	private int samples = 8192;
	private AudioSource audioSource;

	private void Awake()
	{
		if (instance)
			instance = this;
    }
	public void Start()
	{
		//Change the sample rate to unity's audio configuration, there might be errors if you set it manually so yeah, smarter method
		AudioConfiguration audioConfiguration = AudioSettings.GetConfiguration();
		audioSampleRate = audioConfiguration.sampleRate;
		//Get components you'll need
		audioSource = GetComponent<AudioSource>();
		options.Add("None");
		//Get all available microphones
		foreach (string device in Microphone.devices)
		{
			if (microphone == null)
			{
				//Set default mic to first mic found.
				microphone = device;
			}
			options.Add(device);
		}
        //if(options.Count != 0)
		//microphone = options[PlayerPrefsManager.GetMicrophone()];

		//Add microphone to dropdown list
		micDropdown.AddOptions(options);
/*		micDropdown.onValueChanged.AddListener(delegate {
			micDropdownValueChangedHandler(micDropdown);
		});*/

		//Initialize input with default mic if a default mic exists
		if (options.Count != 0)
			UpdateMicrophone();
        if (PlayerPrefsManager.GetMicrophone() != 0)
            micDropdown.value = PlayerPrefsManager.GetMicrophone();
    }
	public void StopRecording()
    {
		audioSource.Stop();
	}
	public void UpdateMicrophone()
	{
		audioSource.Stop();
		//Start recording to audioclip from the mic
		audioSource.outputAudioMixerGroup = mixerGroupMicrophone;
		if(shouldCaptureMicrophone)
		audioSource.clip = Microphone.Start(microphone, true, 10, audioSampleRate);
		audioSource.loop = true;
		// Mute the sound with an Audio Mixer group becuase we don't want the player to hear it

		if (Microphone.IsRecording(microphone))
		{
			//Check that the mic is recording, otherwise you'll get stuck in an infinite loop waiting for it to start
			/*			while (!(Microphone.GetPosition(microphone) > 0))
						{
						} // Wait until the recording has started. */

			// Start playing the audio source so we can hear the sound (it's muted anyways, so..)
			audioSource.Play();
		}
		else
		{
			//If microphone doesn't work for some reason
			audioSource.outputAudioMixerGroup = mixerGroupMaster;
			Debug.Log(microphone + " doesn't work!");
		}
	}

    private void Update()
    {
		if(shouldCaptureMicrophone == true)
        {
			//If we actually want to record the volume, we won't in the first levels
			if(EnemyAiTutorial.instance)
            {
				if (GetAveragedVolume() >= 60 && hasPlayed == false && EnemyAiTutorial.instance.playerInAttackRange)
				{
					//Microphone volume was over 60 and you didn't get attacked in the place you're hiding, yet.
					@event.Invoke();
					hasPlayed = true;
				}
            }
        }
	}
/*    public void micDropdownValueChangedHandler(Dropdown mic)
	{
		microphone = options[mic.value];
		PlayerPrefsManager.SetMicrophone(options[mic.value]);
		UpdateMicrophone();
	}*/
    public void changeMicrophone(int mic)
    {
        microphone = options[mic];
        PlayerPrefsManager.SetMicrophone(mic);
        UpdateMicrophone();
    }
    public float GetAveragedVolume()
	{
		float[] data = new float[256];
		float a = 0;
		audioSource.GetOutputData(data, 0);
		foreach (float s in data)
		{
			a += Mathf.Abs(s);
		}
        Debug.Log(a);
        volumeSlider.value = a;//Mathf.Lerp(volumeSlider.value, a, 5f);
		return a;
	}
}