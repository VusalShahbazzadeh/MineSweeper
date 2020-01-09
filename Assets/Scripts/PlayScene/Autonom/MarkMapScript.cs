using UnityEngine;
using static PlayWindow;

public class MarkMapScript : MonoBehaviour
{
	public static bool[,] MarkMap;
	private void Start()
	{
		MarkMap = new bool[PlayWindow.Width, PlayWindow.Height];
	}

	public static int countNearbyMarked(int _i, int _j)
	{
		int count = 0;
		for (int i = _i-1; i <= _i+1; i++)
		{
			for (int j = _j - 1; j <= _j + 1; j++)
			{
				if (i >= 0 && j >= 0 && i < Height && j < Width && !(i==_i && j == _j))
				{
					if (MarkMap[j, i]) count++;
				}
			}
		}
		return count;
	}
}
