using UnityEngine;

public class OpenMapScript : MonoBehaviour
{
	public static bool[,] OpenMap;
	private void Start()
	{
		OpenMap = new bool[PlayWindow.Width, PlayWindow.Height];
	}

	public static int countNearbyOpen(int _i, int _j)
	{
		int count = 0;
		for (int i = _i - 1; i <= _i + 1; i++)
		{
			for (int j = _j - 1; j <= _j + 1; j++)
			{
				if (i >= 0 && j >= 0 && i < PlayWindow.Height && j < PlayWindow.Width && !(i == _i && j == _j))
				{
					if (OpenMap[j, i]) count++;
				}
			}
		}
		return count;
	}
}
