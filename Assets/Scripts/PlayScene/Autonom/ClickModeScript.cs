using UnityEngine;
using UnityEngine.UI;

public class ClickModeScript : MonoBehaviour
{
	private static string clickMode;
	public static string ClickMode => clickMode;

	[Header("ClickModeButtons")]
	public Button OpenButton;
	public Button MarkButton;
	public Button QuestionButton;

	private void Start()
	{
		clickMode = "Open";
		OpenButton.interactable = false;
	}
	
	public void SwapClickMode(string _clickMode)
	{
		clickMode = _clickMode;
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
