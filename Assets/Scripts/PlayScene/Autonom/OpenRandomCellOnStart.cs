using UnityEngine;
using UnityEngine.UI;

public class OpenRandomCellOnStart : MonoBehaviour
{

	private void ModifyRandomCell()
	{
		Transform temp;
		temp = transform.GetChild(Random.Range(0, PlayWindow.Width * PlayWindow.Height));
		Cell tempCell = temp.GetComponent<Cell>();
		alreadyCalledModifyRandomCell = !tempCell.mine;
		if (temp.GetChild(0).GetComponent<Text>().text == "" && !tempCell.mine)
			tempCell.ModifyCell();
		else
			ModifyRandomCell();
	}

	private bool alreadyCalledModifyRandomCell=false;
	private void Update()
	{
		if(!alreadyCalledModifyRandomCell)
			ModifyRandomCell();
	}
}
