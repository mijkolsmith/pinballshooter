using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Effect
{
	Double,
	Shoot
}

public class UseEffect : MonoBehaviour
{
	[SerializeField] private Effect effect;
	[SerializeField] private int player;

	protected virtual void OnCollisionEnter2D(Collision2D collision)
	{
		switch (effect)
		{
			case Effect.Shoot:
				GameManager.Instance.Shoot(player);
				break;
			case Effect.Double:
				GameManager.Instance.Double(player);
				break;
			default:
				Debug.Log("Shoot/Double effect enum undefined");
				break;
		}
		Destroy(collision.gameObject);
	}
}