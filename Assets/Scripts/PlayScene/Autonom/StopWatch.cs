using UnityEngine;
using UnityEngine.UI;

public class StopWatch : MonoBehaviour
{
	public float RecordedTime;

	public void Update()
	{
		RecordedTime = Time.timeSinceLevelLoad;
		GetComponent<Text>().text = GameManager.SecondsIntoTime((int)RecordedTime); 
	}
}