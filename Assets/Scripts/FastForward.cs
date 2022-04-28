using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastForward : MonoBehaviour
{
	[SerializeField] float timeToSkip = 1;
	[SerializeField] float skipSpeed = 5;
	
	public void SkipForward()
	{
		StartCoroutine(SkipForSeconds());
	}
	IEnumerator SkipForSeconds()
	{
		Debug.Log("Skipping forward for "+timeToSkip+" seconds at "+skipSpeed+"x speed");
		float startSpeed = Time.timeScale;
		Time.timeScale = skipSpeed;

		yield return new WaitForSeconds(timeToSkip);
		Time.timeScale = startSpeed;
	}
}
