using UnityEngine;
using UnityEngine.SceneManagement;
using static PlayWindow;
using static MinesLeft;

public class GameManager : MonoBehaviour
{
	public GameObject DeadScenePanelReference;
	public GameObject WinScenePanelReference;
	public GameObject PauseScenePanelReference;

	public void Die() => DeadScenePanelReference.SetActive(true);

	private void Update()
	{
		Time.timeScale = (WinScenePanelReference.activeSelf || DeadScenePanelReference.activeSelf || PauseScenePanelReference.activeSelf)?0f:1f;
		if (minesLeft == 0)
		{
			if (Width * Height - markedCount == openCount)
			{
				if (!WinScenePanelReference.activeSelf)
				{
					WinScenePanelReference.SetActive(true);
					WinScenePanelReference.GetComponent<WinScene>().WinCalculations();
				}
			}				
		}
	}

	public void Retry() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

	public void LoadMenu() => SceneManager.LoadScene(0);

	public static string SecondsIntoTime(int timeInSeconds)
	{
		int seconds = timeInSeconds % 60;
		int minutes = timeInSeconds / 60;

		string secondsStrings = seconds < 10 ? "0" + seconds.ToString() : seconds.ToString();
		string minutesStrings = minutes < 10 ? "0" + minutes.ToString() : minutes.ToString();
		return minutesStrings + ":" + secondsStrings;
	}
}
