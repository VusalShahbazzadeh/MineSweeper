using UnityEngine;
using UnityEngine.UI;

public class WinScene : MonoBehaviour
{
	public StopWatch StopWatchReference;
	public GameObject GameManagerReference;
	public Text RecordedTimeText;
	public Text BestTimeText;

	private void Start()
	{
		gameObject.SetActive(false);
	}

	public void WinCalculations()
	{
		int bestTime;
		bestTime = PlayerPrefs.GetInt("BestTime");
		if ((bestTime > StopWatchReference.RecordedTime && StopWatchReference.RecordedTime !=0 )|| bestTime == 0)
			 PlayerPrefs.SetInt("BestTime", (int)StopWatchReference.RecordedTime);
		BestTimeText.text = GameManager.SecondsIntoTime(PlayerPrefs.GetInt("BestTime"));
		RecordedTimeText.text = GameManager.SecondsIntoTime((int)StopWatchReference.RecordedTime);
	}
}
