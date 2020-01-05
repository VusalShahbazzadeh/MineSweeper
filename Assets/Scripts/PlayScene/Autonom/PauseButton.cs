using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseButton : MonoBehaviour
{
	public GameObject PauseSceneReference;
	public static bool paused = false;

	public void Pause()
	{
		paused = !paused;
		PauseSceneReference.SetActive(paused);
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (paused)
			{
				SceneManager.LoadScene(0);
			}
			else
			{
				Pause();
			}
		}
	}
}
