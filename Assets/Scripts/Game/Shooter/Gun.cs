using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
	private Quaternion startRot, endRot;
	private Transform pivot;
	private float step = 0;
	[SerializeField] private float animationSpeed = .2f;
	private bool rotatePositive = false;

	[SerializeField] private GameObject bulletPrefab;
	public ColorEnum colorEnum;

	private void Start()
	{
		pivot = transform.parent;

		startRot = Quaternion.Euler(0, 0, pivot.localRotation.eulerAngles.z - 60);
		endRot = Quaternion.Euler(0, 0, pivot.localRotation.eulerAngles.z + 60);
	}

	private void Update()
	{
		if (step < 1) step += Time.deltaTime * animationSpeed;
		if (step >= 1)
		{
			rotatePositive = !rotatePositive;
			step = 0;
		}

		// Lerp z-rotation around pivot between -60 and +60
		if (rotatePositive == true)
		{
			pivot.localRotation = Quaternion.Slerp(startRot, endRot, step);
		}
		else
		{
			pivot.localRotation = Quaternion.Slerp(endRot, startRot, step);
		}
	}

	public void Shoot()
	{
		Vector3 dir = (pivot.transform.position - transform.position).normalized;
		GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity, transform.parent.parent);
		bullet.layer = (int) colorEnum + 6;
		bullet.GetComponent<Bullet>().colorEnum = colorEnum;
		
		switch (colorEnum)
		{
			case ColorEnum.Blue:
				bullet.GetComponent<Image>().color = Color.blue * Color.HSVToRGB(240f / 360f, 1f, 1f);
				break;
			case ColorEnum.Green:
				bullet.GetComponent<Image>().color = Color.green * Color.HSVToRGB(125f / 360f, 1f, 1f);
				break;
			case ColorEnum.Red:
				bullet.GetComponent<Image>().color = Color.red * Color.HSVToRGB(0, 1f, 1f);
				break;
			case ColorEnum.Yellow:
				bullet.GetComponent<Image>().color = Color.yellow * Color.HSVToRGB(60f / 360f, 1f, 1f);
				break;
		}
		bullet.GetComponent<Rigidbody2D>().AddForce(-dir * 2500);
	}
}