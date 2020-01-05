﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
	public void LoadMenu() => SceneManager.LoadScene(0);

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape)) LoadMenu();
	}
}
