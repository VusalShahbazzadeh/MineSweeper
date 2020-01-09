using UnityEngine;
using static PlayWindow;

public class CellMapScript : MonoBehaviour
{
	public static Cell[,] cellMap;

	private void Start()
	{
		cellMap = new Cell[Width, Height];
		for (int i = 0; i < Width*Height; i++)
		{
			cellMap[i % Width, i / Width] = transform.GetChild(i).GetComponent<Cell>();
		}
	}
}
