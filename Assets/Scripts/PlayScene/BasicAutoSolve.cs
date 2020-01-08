using UnityEngine;
using UnityEngine.UI;
using static MarkMapScript;
using static OpenMapScript;

public class BasicAutoSolve : MonoBehaviour
{
	public ClickModeScript ClickModeReference;

	private bool worked = false;
	private bool called = false;
    public void SolveBasics()
	{
		print("called");
		called = true;
		worked = false;
		for (int i = 0; i < PlayWindow.Width * PlayWindow.Height; i++)
		{
			Transform cellTransform = transform.GetChild(i);
			string cellNumber = cellTransform.GetChild(0).GetComponent<Text>().text;
			Cell cell = cellTransform.GetComponent<Cell>();
			System.Console.ReadKey();
			if (cell.CellIsOpen)
				if (System.Convert.ToInt32(cellNumber == "" ? "0" : cellNumber) != countNearbyMarked(cell._i,cell._j))
				{
					if (countNearbyCells(cell._i,cell._j) - System.Convert.ToInt32(cellNumber == "" ? "0" : cellNumber) == countNearbyOpen(cell._i, cell._j))
					{
						MarkNearby(cell._i, cell._j);
						worked = true;
					}
				}else
				{
					if (countNearbyCells(cell._i, cell._j) - System.Convert.ToInt32(cellNumber == "" ? "0" : cellNumber) != countNearbyOpen(cell._i, cell._j))
					{
						ClickModeReference.SwapClickMode("Open");
						cell.ModifyCell();
						worked = true;
					}
				}
		}
	}

	public static int countNearbyCells(int _i,int _j)
	{
		int count = 0;
		for (int i = _i-1; i <=1+_i; i++)
			for (int j = _j-1; j <=1+_j; j++)
				if (i >= 0 && j >= 0 && i < PlayWindow.Height && j < PlayWindow.Width)
					if (!(i == _i && j == _j))
						count++;
		return count;
	}


	public void MarkNearby(int _i, int _j)
	{
		for (int i = _i - 1; i <= 1 + _i; i++)
			for (int j = _j - 1; j <= 1 + _j; j++)
				if (i >= 0 && j >= 0 && i < PlayWindow.Height && j < PlayWindow.Width)
					if (!(i == _i && j == _j))
						if (!MarkMap[j,i])
						{
							ClickModeReference.SwapClickMode("Mark");
							transform.GetChild(i * PlayWindow.Width + j).GetComponent<Cell>().ModifyCell();
						}

	}

	private void Update()
	{
		if (called)
		{
			if (worked)
			{
				SolveBasics();
			}
			else
			{
				called = false;
			}
		}
	}
}
