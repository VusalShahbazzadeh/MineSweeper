using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour
{
	public void LoadMenu()
	{
		SceneManager.LoadScene(0);
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
			LoadMenu();
	}
}
