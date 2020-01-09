using UnityEngine;
using UnityEngine.UI;
using static MarkMapScript;
using static OpenMapScript;
using static PlayWindow;
using static CellMapScript;

public class BasicAutoSolve : MonoBehaviour
{
	public ClickModeScript ClickModeReference;

	private bool worked = false;
	private bool called = false;
	private int NearbyCells;
	private int NearbyMark;
	private int NearbyOpen;
    public void SolveBasics()
	{
		print("called");
		called = true;
		worked = false;
		for (int i = 0; i <Width * Height; i++)
		{
			Transform cellTransform = transform.GetChild(i);
			string cellText = cellTransform.GetChild(0).GetComponent<Text>().text;
			int cellNumber = System.Convert.ToInt32(cellText == "" ? "0" : cellText);
			Cell cell = cellTransform.GetComponent<Cell>();
			NearbyCells = countNearbyCells(cell._i, cell._j);
			NearbyOpen = countNearbyOpen(cell._i, cell._j);
			NearbyMark = countNearbyMarked(cell._i, cell._j);
			System.Console.ReadKey();
			if (cell.CellIsOpen)
				if (cellNumber != 0)
				if ( cellNumber!= NearbyMark)
				{
					if (NearbyCells -  cellNumber == NearbyOpen)
					{
						MarkNearby(cell._i, cell._j);
						worked = true;
					}
				}else
				{
					if (NearbyCells - cellNumber != NearbyOpen)
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
				if (i >= 0 && j >= 0 && i < Height && j < Width)
					if (!(i == _i && j == _j))
						count++;
		return count;
	}


	public void MarkNearby(int _i, int _j)
	{
		for (int i = _i - 1; i <= 1 + _i; i++)
			for (int j = _j - 1; j <= 1 + _j; j++)
				if (i >= 0 && j >= 0 && i < Height && j < Width)
					if (!(i == _i && j == _j))
						if (!MarkMap[j,i])
						{
							ClickModeReference.SwapClickMode("Mark");
							cellMap[j,i].ModifyCell();
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
