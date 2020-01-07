using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsButton : MonoBehaviour
{
	public void LoadOptions()
	{
		SceneManager.LoadScene(3);
	}
}
