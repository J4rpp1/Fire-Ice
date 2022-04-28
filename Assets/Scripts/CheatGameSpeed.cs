using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatGameSpeed : MonoBehaviour
{
	[SerializeField] float speedMultiplier = 2f;
    public void MultiplyGameSpeed()
	{
		Time.timeScale = speedMultiplier;
	}
}
