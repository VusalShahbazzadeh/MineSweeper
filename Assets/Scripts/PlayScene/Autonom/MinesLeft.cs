﻿using UnityEngine;
using UnityEngine.UI;
using static PlayWindow;

public class MinesLeft : MonoBehaviour
{
	public GameObject PlayWindowReference;

	public static int mineCount=0;
	public static int markedCount=0;
	public static int minesLeft=0;
	public static int openCount;


	private void Update()
	{
		//count mines
		mineCount = 0;
		try
		{
			for (int i = 0; i < Height; i++)
				for (int j = 0; j < Width; j++)
					if (mineMap[j, i])
						mineCount++;
		}
		catch
		{
			mineMap = new bool[Width, Height];
			for (int i = 0; i < Height; i++)
			{
				for (int j = 0; j < Width; j++)
				{
					mineMap[j, i] = PlayWindowReference.transform.
						GetChild(i * Width + j)
						.GetComponent<Cell>()
						.mine;
				}
			}
		}
		//count marked
		markedCount = 0;
		for (int i = 0; i < Width * Height; i++)
			if (PlayWindowReference.transform.GetChild(i).GetComponent<Cell>().Marked) markedCount++;

		//ount mines left
		minesLeft = mineCount - markedCount;

		//open count
		openCount = 0;
		for (int i = 0; i < Width * Height; i++)
			if (PlayWindowReference.transform.GetChild(i).GetComponent<Cell>().CellIsOpen) openCount++;

		GetComponent<Text>().text = minesLeft.ToString();
	}
}
