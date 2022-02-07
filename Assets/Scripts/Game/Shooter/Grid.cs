using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Grid : MonoBehaviour
{
	private Cube[,] cubes;
	private List<GameObject> cubeObjects;

	[SerializeField] GameObject cubePrefab;

	private int width = 46;
	private int height = 46;

	private void Start()
	{
		cubes = new Cube[width, height];
		
		GenerateCubes();
		cubeObjects = new List<GameObject>();

		int i = 0;
		foreach (Cube cube in cubes)
		{
			RectTransform fieldRt = transform.parent.GetComponent<RectTransform>();
			RectTransform cubeRt = cubePrefab.GetComponent<RectTransform>();

			// The -1f is to center the field of cubes
			float widthMod = fieldRt.sizeDelta.x * fieldRt.localScale.x / 2f - 1f - cubeRt.sizeDelta.x * fieldRt.localScale.x / 2f;
			float heightMod = fieldRt.sizeDelta.y * fieldRt.localScale.y / 2f - 1f - cubeRt.sizeDelta.x * fieldRt.localScale.x / 2f;

			cubeObjects.Add(Instantiate(cubePrefab, new Vector2(cube.x * 15 - widthMod, cube.y * 15 - heightMod), Quaternion.identity));
			cubeObjects[i].transform.SetParent(transform.GetChild(0), false);
			cubeObjects[i].name = "cube" + i;
			cubeObjects[i].GetComponent<Image>().color = cube.color;
			cubeObjects[i].layer = (int)cube.colorEnum + 6;

			i++;
		}
	}

	private void GenerateCubes()
	{
		int i = 0;
		for (int x = 0; x < width; x++)
		{
			for (int y = 0; y < height; y++)
			{
				Color c;
				ColorEnum colorEnum;

				if (x < width / 2)
				{
					if (y < height / 2)
					{
						c = Color.green * Color.HSVToRGB(125f / 360f, .8f, .8f);
						colorEnum = ColorEnum.Green;
					}
					else
					{
						c = Color.blue * Color.HSVToRGB(240f / 360f, .8f, .8f);
						colorEnum = ColorEnum.Blue;
					}
				}
				else
				{
					if (y < height / 2)
					{
						c = Color.yellow * Color.HSVToRGB(60f / 360f, .8f, .8f);
						colorEnum = ColorEnum.Yellow;
					}
					else
					{
						c = Color.red * Color.HSVToRGB(0, .8f, .8f);
						colorEnum = ColorEnum.Red;
					}
				}

				cubes[x, y] = new Cube(x, y, c, colorEnum);
				i++;
			}
		}
	}
}