using UnityEngine;
using UnityEngine.UI;

public class PlayWindow : MonoBehaviour
{
	public GameObject CellPrefab;
	public static int Width = 10;
	public static int Height = 10;
	public float Probability;


	private  GridLayoutGroup GLG;
	private int cellSize;
	private int spacing;

	public static bool[,] mineMap;

	private void Awake()
	{
		//Instantiating Cells and mines
		mineMap = new bool[Width,Height];
		for (int i = 0; i < Height; i++)
		{
			for (int j = 0; j < Width; j++)
			{
				Cell temp = Instantiate(CellPrefab, transform).GetComponent<Cell>();
				mineMap[j, i] = temp.mine = (Random.Range(0, (int)(1/Probability)) == 0);
				temp._j = j;
				temp._i = i;
			}
		}

		//Initating numbers
		int mineCount = 0;
		for (int i = 0; i < Height; i++)
		{
			for (int j = 0; j < Width; j++)
			{
				for (int t = -1; t < 2; t++)
					for (int k = -1; k < 2; k++)
						if ((i + t >= 0 && i + t < Height && j + k >= 0 && j + k < Width) && !(k == 0 && t == 0) && mineMap[j + k, i + t]) mineCount++;
				transform.GetChild(i * Width + j).GetChild(0).GetComponent<Text>().text = (mineCount == 0 ? "" : mineMap[j, i]?"-1":mineCount.ToString());
				mineCount = 0;
			}
		}
	}

	private void Start()
	{
		//Setting GridLayoutGroup
		GLG = GetComponent<GridLayoutGroup>();

		//Computing Spacing and Cell Size	
		cellSize = Mathf.RoundToInt(1800 / (0.2f + 1.2f * Width));
		spacing = (int)(0.2f * cellSize);

		//Setting Spacing and Cell Size
		GLG.padding.left =
			GLG.padding.right =
			GLG.padding.top =
			GLG.padding.bottom = spacing;
		GLG.spacing = new Vector2(spacing,spacing);
		GLG.cellSize = new Vector2(cellSize,cellSize);
	}
}
