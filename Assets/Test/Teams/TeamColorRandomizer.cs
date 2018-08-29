﻿using UnityEngine;

public class TeamColorRandomizer : MonoBehaviour
{
	public TeamColor teamColor;

	private int? curIdx;

	private static Color[] Colors = new Color[]
	{
		Color.red,
		Color.blue,
		Color.green
	};

	public void Randomize()
	{
		int randomIdx;
		do
		{
			randomIdx = (int) (Random.value * Colors.Length);
		}
		while (randomIdx == curIdx);
		teamColor.Color = Colors[randomIdx];
		curIdx = randomIdx;
	}
}