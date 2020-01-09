using UnityEngine;
using UnityEngine.UI;
using static System.DateTime;
using System;

public class StopWatch : MonoBehaviour
{
	public double RecordedTime;
	public DateTime startTime;

	public void Start()
	{
		startTime = Now;
	}

	private bool paused;
	private bool FirstFrameOfPause=true;
	private bool FirstFrameOfContinue = false;
	private DateTime PauseTime;
	private DateTime ContinueTime;

	public void Update()
	{
		paused = Time.timeScale == 0f;
		if (!paused)
		{
			if (FirstFrameOfContinue)
				Continue();
			else
				RecordedTime = Now.Subtract(startTime).TotalSeconds;
		}
		else
		{
			if (FirstFrameOfPause)
				Pause();
		}
		//RecordedTime = Time.timeSinceLevelLoad;
		GetComponent<Text>().text = GameManager.SecondsIntoTime((int)RecordedTime); 
	}

	public void Pause()
	{
		FirstFrameOfPause = false;
		FirstFrameOfContinue = true;
		PauseTime = Now;
	}

	public void Continue()
	{
		FirstFrameOfContinue = false;
		FirstFrameOfPause = true;
		ContinueTime = Now;
		startTime = startTime.Add(ContinueTime.Subtract(PauseTime));
	}
}