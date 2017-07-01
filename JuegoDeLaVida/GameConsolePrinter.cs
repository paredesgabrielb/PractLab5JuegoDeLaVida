﻿using System;

public static class GameConsolePrinter
{
	public static void Print (Juego g)
	{
		for (int x = 0; x < g.SizeX; x++)
		{
			for (int y = 0; y < g.SizeY; y++)
				Console.Write ("|{0}", g.GetValue (x, y) ? "X" : " ");
			Console.WriteLine ("|");
		}
	}
}

