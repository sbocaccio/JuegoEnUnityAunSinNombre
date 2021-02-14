using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer
{
	public Timer(float Stoptime)
	{
		stopTime = Stoptime;
	}
	public float stopTime;
	public float stopTimer = 0;
	private bool timerStopped = true;
	public void setTimer()
	{
		if (timerStopped) {
			stopTimer = stopTime;
			timerStopped = false;
		}
	}
	public bool timeOver()
	{
		stopTimer -= Time.deltaTime;
		if (stopTimer <= 0)
		{
			stopTimer = 0;
			timerStopped = true;
			return true;
		}
		else return false;
	}

	
}
