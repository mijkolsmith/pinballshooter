using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperAI : MonoBehaviour
{
    [SerializeField] private GameObject leftFlipper;
    [SerializeField] private GameObject rightFlipper;

    private HingeJoint2D lhj;
    private HingeJoint2D rhj;

    private void Start()
    {
        lhj = leftFlipper.GetComponent<HingeJoint2D>();
        rhj = rightFlipper.GetComponent<HingeJoint2D>();
    }

    private void Update()
    {
        //TODO: AI implementation
        /*if (false)
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
        if (false)
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
        }*/
    }
}