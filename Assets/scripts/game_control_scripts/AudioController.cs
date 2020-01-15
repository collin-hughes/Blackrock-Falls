using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour
{
	#region Singleton
	public static AudioController instance;

	
	

	private void Awake()
	{
		if (instance != null)
		{
			Debug.LogWarning("More than one instance of AudioController found!");
		}

		instance = this;
		DontDestroyOnLoad(this);
	}
	#endregion

	public float masterVolume = 80;
	public float musicVolume = 80;
	public float effectVolume = 80;

	[SerializeField] private AudioMixer audioMixer;

	[SerializeField] private AudioSource musicController;
	[SerializeField] private AudioSource playerSoundsController;

	private void Update()
	{
		audioMixer.SetFloat("masterVol", Mathf.Clamp(masterVolume - 80, -80, 0));
		audioMixer.SetFloat("musicVol", Mathf.Clamp(musicVolume - 80, -80, 0));
		audioMixer.SetFloat("effectVol", Mathf.Clamp(effectVolume - 80, -80, 0));
	}

	public void PlaySoundFX(AudioClip clip)
	{
		playerSoundsController.PlayOneShot(clip);
	}

	public void PlayMusic(AudioClip music)
	{
		musicController.clip = music;
		musicController.Play();
	}
}
