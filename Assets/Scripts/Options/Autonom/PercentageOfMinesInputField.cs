using UnityEngine;
using UnityEngine.UI;

public class PercentageOfMinesInputField : MonoBehaviour
{
	private int PercentageInitially;
	private int Percentage;
	private int PercentageInput
	{
		get => Percentage;
		set => Percentage = value >= 100 ? 100 : value <= 0 ? 0 : value;
	}

	private string typedText;
	private void Start()
	{
		transform.GetChild(0).GetComponent<Text>().text = (PercentageInitially = PlayerPrefs.GetInt("PercentageOfMines")).ToString();
	}

	public void DeleteIfTheLastCharIsNotANumber()
	{
		typedText = GetComponent<InputField>().text;
		if (typedText.Length != 0 && !char.IsNumber(typedText[typedText.Length - 1]))
			GetComponent<InputField>().text = typedText.Remove(typedText.Length - 1);
	}

	public void SetValue()
	{

		typedText = GetComponent<InputField>().text;
		PercentageInput = System.Convert.ToInt32(typedText);
		if (typedText.Length != 0) PlayerPrefs.SetInt("PercentageOfMines", PercentageInput);

	}
}
