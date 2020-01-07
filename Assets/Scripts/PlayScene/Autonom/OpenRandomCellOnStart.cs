using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenRandomCellOnStart : MonoBehaviour
{

	private void ModifyRandomCell()
	{
		Cell temp;
		temp = transform.GetChild(Random.Range(0, PlayWindow.Width * PlayWindow.Height)).GetComponent<Cell>();
		alreadyCalledModifyRandomCell = !temp.mine;
		if (!temp.mine)
			temp.ModifyCell();
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
