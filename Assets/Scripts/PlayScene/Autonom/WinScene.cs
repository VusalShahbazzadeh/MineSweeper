using UnityEngine;
using UnityEngine.UI;

public class WinScene : MonoBehaviour
{
	public StopWatch StopWatchReference;
	public GameObject GameManagerReference;
	public Text ComplexityLevelText;
	public Text MineCellRatioText;
	public Text RecordedTimeText;
	public Text BestTimeText;

	private void Start()
	{
		gameObject.SetActive(false);
	}

	public void WinCalculations()
	{
		int bestTime;
		bestTime = PlayerPrefs.GetInt("BestTime " + PlayerPrefs.GetInt("CellCount").ToString()+":" + PlayerPrefs.GetInt("PercentageOfMines"));
		if ((bestTime > StopWatchReference.RecordedTime && StopWatchReference.RecordedTime !=0 )|| bestTime == 0)
			 PlayerPrefs.SetInt("BestTime " + PlayerPrefs.GetInt("CellCount").ToString() + ":" + PlayerPrefs.GetInt("PercentageOfMines"), (int)StopWatchReference.RecordedTime);
		BestTimeText.text = GameManager.SecondsIntoTime(PlayerPrefs.GetInt("BestTime " + PlayerPrefs.GetInt("CellCount").ToString() + ":" + PlayerPrefs.GetInt("PercentageOfMines")));
		RecordedTimeText.text = GameManager.SecondsIntoTime((int)StopWatchReference.RecordedTime);
		ComplexityLevelText.text = "Complexity Level is :  " + PlayerPrefs.GetInt("CellCount");
		MineCellRatioText.text = "Mine-Cell ratio is :  " + PlayerPrefs.GetInt("PercentageOfMines") + "%";
	}
}
