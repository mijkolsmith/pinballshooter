using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ColorEnum
{
	Blue,
	Green,
	Red,
	Yellow
}

public class Cube
{
	public int x;
	public int y;
	public int neighboursAlive;
	public Color color;
	public ColorEnum colorEnum;

	public Cube(int x, int y, Color color, ColorEnum colorEnum)
	{
		this.x = x;
		this.y = y;
		this.color = color;
		this.colorEnum = colorEnum;
	}
}