using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmDeactivation : MonoBehaviour
{
    private Animator animator;
    private BoxCollider playerCollider;
    private BoxCollider leftHand;
    private BoxCollider rightHand;
    private BoxCollider leftFoot;
    private BoxCollider rightFoot;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        playerCollider = GetComponent<BoxCollider>();
        leftHand = GameObject.Find("mixamorig1:LeftHand").GetComponent<BoxCollider>();
        rightHand = GameObject.Find("mixamorig1:RightHand").GetComponent<BoxCollider>();
        leftFoot = GameObject.Find("mixamorig1:LeftToeBase").GetComponent<BoxCollider>();
        rightFoot = GameObject.Find("mixamorig1:RightToeBase").GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

        if (stateInfo.IsName("PunchingLeft") || stateInfo.IsName("PunchingRight"))
        {
            leftHand.enabled = true;
            rightHand.enabled = true;
        }
        else
        {
            leftHand.enabled = false;
            rightHand.enabled = false;
        }

        if (stateInfo.IsName("LeftKick") || stateInfo.IsName("RightKick"))
        {
            leftFoot.enabled = true;
            rightFoot.enabled = true;
        }
        else
        {
            leftFoot.enabled = false;
            rightFoot.enabled = false;
        }

        if (stateInfo.IsName("Bouncing Fight Idle") || stateInfo.IsName("Running") || stateInfo.IsName("Walking Backwards") || stateInfo.IsName("FlinchAnimation"))
        {
            playerCollider.enabled = true;
        }
        else
        {
            playerCollider.enabled = false;
        }
    }
}
