using UnityEngine;
using UnityEngine.UI;

public class CellCountInputField : MonoBehaviour
{
	private int cellCountInitially;
	private int cellCount;
	private int cellCountInput
	{
		get
		{
			return cellCount;
		}
		set
		{
			if (value >= 2 && value <= 22)
				cellCount = value;
			else if (value < 2)
				cellCount = 2;
			else
				cellCount = 22;
		}
	}
	private string typedText;

	private void Start()
	{
		transform.GetChild(0).GetComponent<Text>().text = (cellCountInitially =PlayerPrefs.GetInt("CellCount")).ToString();
	}
	public void DeleteIfTheLastCharIsNotANumber()
	{
		typedText = GetComponent<InputField>().text;
		if (typedText.Length !=0 && !char.IsNumber(typedText[typedText.Length - 1]))
			GetComponent<InputField>().text = typedText.Remove(typedText.Length - 1);
	}

	public void SetValue()
	{
		cellCountInput = System.Convert.ToInt32(typedText);
		if (typedText.Length != 0) PlayerPrefs.SetInt("CellCount",cellCountInput);	

	}
}
