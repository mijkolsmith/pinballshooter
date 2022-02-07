using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
	public ColorEnum colorEnum;

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.layer == 6 || collision.gameObject.layer == 7 || collision.gameObject.layer == 8|| collision.gameObject.layer == 9)
		{
			collision.gameObject.layer = gameObject.layer;
			switch (colorEnum)
			{
				case ColorEnum.Blue:
					collision.gameObject.GetComponent<Image>().color = Color.blue * Color.HSVToRGB(240f / 360f, .8f, .8f);
					break;
				case ColorEnum.Green:
					collision.gameObject.GetComponent<Image>().color = Color.green * Color.HSVToRGB(125f / 360f, .8f, .8f);
					break;
				case ColorEnum.Red:
					collision.gameObject.GetComponent<Image>().color = Color.red * Color.HSVToRGB(0, .8f, .8f);
					break;
				case ColorEnum.Yellow:
					collision.gameObject.GetComponent<Image>().color = Color.yellow * Color.HSVToRGB(60f / 360f, .8f, .8f);
					break;
			}
		}
		Destroy(gameObject);
	}
}