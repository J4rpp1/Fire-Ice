using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX : MonoBehaviour
{
	//[SerializeField] AudioClip enemyHurtSound, enemyBlockSound, bombSound;
	public AudioSource sounds;
	public static SFX instance; //Refer to it by SFX.instance. followed by method or variable
	void Awake() //Make static singleton instance
	{
		if (instance != null)
			GameObject.Destroy(instance);
		else
			instance = this;
		DontDestroyOnLoad(this);
	}

	void Start() 
	{
		sounds = GetComponent<AudioSource>();
	}

	public void PlayClip(AudioClip audioClip, float volume)
	{
		sounds.PlayOneShot(audioClip, volume);
	}

	public void StopClips()
	{
		sounds.Stop();
	}
	
}
