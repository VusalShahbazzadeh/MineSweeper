using UnityEngine;
using UnityEngine.UI;
using static PlayWindow;

public class Cell : MonoBehaviour
{
	[Header("Sprites")]
	public Sprite MineSprite;
	public Sprite MarkSprite;
	public Sprite QuestionSprite;
	public Sprite BlankSprite;
	public Sprite CoveredCellSprite;

	public Text CellText;
	public Image CellImage;
	public bool mine { get; set; }
	public bool Marked { get; set; } = false;
	public bool CellIsOpen { get; set; } = false;
	public bool modified { get; set; } = false;
	public int _j { get; set; }
	public int _i { get; set; }
	

	
	public void Start()
	{
		CellImage.sprite = CoveredCellSprite;
	}
	

	public void ModifyCell()
	{
		if (CellIsOpen)
		{
			if (!modified)
			{
				modified = true;
				FindObjectOfType<ClickModeScript>().SwapClickMode("Open");
				string temp = transform.GetChild(0).GetComponent<Text>().text;
				if (System.Convert.ToInt32(temp == "" ? "0" : temp) == countNearbyMarked())
					for (int i = _i - 1; i < 2 + _i; i++)
						for (int j = _j - 1; j < 2 + _j; j++)
						{
							if (i >= 0 && j >= 0 && i < Height && j < Width && !(i == _i && j == _j))
							{
								Cell tempCell = FindObjectOfType<PlayWindow>().transform.GetChild(i * Width + j).GetComponent<Cell>();
								if (!tempCell.Marked)
									tempCell.ModifyCell();
							}
						}
			}

			}
			else
				switch (ClickModeScript.ClickMode)
				{
					case "Open":
						if (!Marked)
						{
							if (mine)
								FindObjectOfType<GameManager>().Die();
							CellText.enabled = !mine;
							CellImage.sprite = mine ? MineSprite : BlankSprite;
							CellIsOpen = true;
							if (transform.GetChild(0).GetComponent<Text>().text == "")
								ModifyCell();
						}
						break;
					case "Mark":
						CellImage.sprite = (CellImage.sprite == MarkSprite) ? CoveredCellSprite : MarkSprite;
						Marked = (CellImage.sprite == MarkSprite);
						break;
					case "Question":
						CellImage.sprite = CellImage.sprite == QuestionSprite ? CoveredCellSprite : QuestionSprite;
						Marked = CellImage.sprite == QuestionSprite;
						break;
				}
	}

	private int countNearbyMarked()
	{
		int count = 0;
		for (int i = _i-1; i < 2+_i ; i++)
			for (int j = _j-1; j < 2+_j; j++)
				if (i >= 0 && j >= 0 && i < Height&& j < Width&& !(i==_i &&j==_i))
					if (FindObjectOfType<PlayWindow>().transform.GetChild(i*Width+j).GetComponent<Cell>().Marked) count++;
		return count;
	}
}