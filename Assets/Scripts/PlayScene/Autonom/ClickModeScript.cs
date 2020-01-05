using UnityEngine;
using UnityEngine.UI;

public class ClickModeScript : MonoBehaviour
{
	public static string ClickMode { get; set; }

	[Header("ClickModeButtons")]
	public Button OpenButton;
	public Button MarkButton;
	public Button QuestionButton;

	private void Start()
	{
		ClickMode = "Open";
		OpenButton.interactable = false;
	}
	
	public void SwapClickMode(string clickMode)
	{
		ClickMode = clickMode;
		OpenButton.interactable =
		MarkButton.interactable =
		QuestionButton.interactable = true;
		switch (clickMode)
		{
			case "Open":
				OpenButton.interactable = false;
				break;
			case "Mark":
				MarkButton.interactable = false;
				break;
			case "Question":
				QuestionButton.interactable = false;
				break;
		}
	}
}
