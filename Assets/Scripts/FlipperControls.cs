using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperControls : MonoBehaviour
{
    [SerializeField] private GameObject leftFlipper;
    [SerializeField] private GameObject rightFlipper;
    [SerializeField] private KeyCode leftInput;
    [SerializeField] private KeyCode leftInputAlternate;
    [SerializeField] private KeyCode rightInput;
    [SerializeField] private KeyCode rightInputAlternate;

    private Quaternion leftStartRot;
    private Quaternion rightStartRot;
    private Quaternion leftEndRot;
    private Quaternion rightEndRot;
    private float animationSpeed = 50;

	private void Start()
	{
        leftInput = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("leftInput", KeyCode.LeftArrow.ToString()));
        leftInputAlternate = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("leftInputAlternate", KeyCode.A.ToString()));
        rightInput = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("rightInput", KeyCode.RightArrow.ToString()));
        rightInputAlternate = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("rightInputAlternate", KeyCode.D.ToString()));

        leftStartRot = leftFlipper.transform.rotation;
        rightStartRot = rightFlipper.transform.rotation;
        leftEndRot = Quaternion.Euler(0, 0, 40);
        rightEndRot = Quaternion.Euler(0, 0, -40);
    }

	private void Update()
    {
        //TODO: Customizable key controls
        if(Input.GetKey(leftInput) || Input.GetKey(leftInputAlternate))
		{
            leftFlipper.transform.rotation = Quaternion.Slerp(leftFlipper.transform.rotation, leftEndRot, animationSpeed * Time.deltaTime);
		}
        else
		{
            leftFlipper.transform.rotation = Quaternion.Slerp(leftFlipper.transform.rotation, leftStartRot, animationSpeed / 2 * Time.deltaTime);
        }
        if (Input.GetKey(rightInput) || Input.GetKey(rightInputAlternate))
        {
            rightFlipper.transform.rotation = Quaternion.Slerp(rightFlipper.transform.rotation, rightEndRot, animationSpeed * Time.deltaTime);
        }
        else
		{
            rightFlipper.transform.rotation = Quaternion.Slerp(rightFlipper.transform.rotation, rightStartRot, animationSpeed / 2 * Time.deltaTime);
        }
    }
}