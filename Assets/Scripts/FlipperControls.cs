using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperControls : MonoBehaviour
{
    [SerializeField] private GameObject leftFlipper;
    [SerializeField] private GameObject rightFlipper;

    private HingeJoint2D lhj;
    private HingeJoint2D rhj;

    private KeyCode leftInput;
    private KeyCode leftInputAlternate;
    private KeyCode rightInput;
    private KeyCode rightInputAlternate;

    /*private Quaternion leftStartRot;
    private Quaternion rightStartRot;
    private Quaternion leftEndRot;
    private Quaternion rightEndRot;
    private float animationSpeed = 50;*/

	private void Start()
	{
        leftInput = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("leftInput", KeyCode.LeftArrow.ToString()));
        leftInputAlternate = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("leftInputAlternate", KeyCode.A.ToString()));
        rightInput = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("rightInput", KeyCode.RightArrow.ToString()));
        rightInputAlternate = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("rightInputAlternate", KeyCode.D.ToString()));

        lhj = leftFlipper.GetComponent<HingeJoint2D>();
        rhj = rightFlipper.GetComponent<HingeJoint2D>();

        // Old, I use hinge joints now
        /*leftStartRot = leftFlipper.transform.rotation;
        rightStartRot = rightFlipper.transform.rotation;
        leftEndRot = Quaternion.Euler(0, 0, 40);
        rightEndRot = Quaternion.Euler(0, 0, -40);*/
    }

	private void Update()
    {
        if (Input.GetKey(leftInput) || Input.GetKey(leftInputAlternate))
        {
            lhj.useMotor = true;
        }
        else
		{
            lhj.useMotor = false;
        }
        if (Input.GetKey(rightInput) || Input.GetKey(rightInputAlternate))
        {
            rhj.useMotor = true;
        }
        else
        {
            rhj.useMotor = false;
        }

        // Old, I use hinge joints now
        /*if(Input.GetKey(leftInput) || Input.GetKey(leftInputAlternate))
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
        }*/
    }
}