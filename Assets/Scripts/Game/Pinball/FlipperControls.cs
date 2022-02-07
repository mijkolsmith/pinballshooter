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

	private void Start()
	{
        leftInput = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("leftInput", KeyCode.LeftArrow.ToString()));
        leftInputAlternate = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("leftInputAlternate", KeyCode.A.ToString()));
        rightInput = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("rightInput", KeyCode.RightArrow.ToString()));
        rightInputAlternate = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("rightInputAlternate", KeyCode.D.ToString()));

        lhj = leftFlipper.GetComponent<HingeJoint2D>();
        rhj = rightFlipper.GetComponent<HingeJoint2D>();
    }

	private void Update()
    {
        if (Input.GetKey(leftInput) || Input.GetKey(leftInputAlternate))
        {
            JointMotor2D ljm = lhj.motor;
            ljm.motorSpeed = -500000;
            lhj.motor = ljm;
        }
        else
		{
            JointMotor2D ljm = lhj.motor;
            ljm.motorSpeed = 500000;
            lhj.motor = ljm;
        }
        if (Input.GetKey(rightInput) || Input.GetKey(rightInputAlternate))
        {
            JointMotor2D rjm = rhj.motor;
            rjm.motorSpeed = 500000;
            rhj.motor = rjm;
        }
        else
        {
            JointMotor2D rjm = rhj.motor;
            rjm.motorSpeed = -500000;
            rhj.motor = rjm;
        }
    }
}