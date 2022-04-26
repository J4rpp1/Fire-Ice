using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SetVolume : MonoBehaviour
{
	public AudioMixer musicMixer;
	public AudioMixer fxMixer;

	void Start()
	{
		SetMusicLevel(0f);
	}
	public void SetMusicLevel(float sliderValue)
	{
		musicMixer.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
	}

	public void SetFxLevel(float sliderValue)
	{
		fxMixer.SetFloat("FxVolume", Mathf.Log10(sliderValue) * 20);
	}
}
