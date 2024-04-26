using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimbActivation : MonoBehaviour
{
    public Dictionary<string, bool> activatedLimbs;
    private Animator animator;
    private AnimatorStateInfo stateInfo;
    private AnimatorClipInfo[] clipInfo;

    // Start is called before the first frame update
    void Start()
    {
        activatedLimbs = new Dictionary<string, bool>();
        animator = GetComponent<Animator>();
        BoxCollider[] bcs = GetComponentsInChildren<BoxCollider>();

        foreach (BoxCollider bc in bcs)
        {
            activatedLimbs.Add(bc.gameObject.name, false);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        clipInfo = animator.GetCurrentAnimatorClipInfo(0);
        float currentFrame = (int)(stateInfo.normalizedTime * (clipInfo[0].clip.length * clipInfo[0].clip.frameRate));
        if (stateInfo.IsName("PunchingLeft"))
        {
            if (currentFrame < 6) ActivateLimbs(true, "LeftHand");//, "LeftForeArm");
        }
        else
        {
            ActivateLimbs(false, "LeftHand");//, "LeftForeArm");
        }

        if (stateInfo.IsName("PunchingRight"))
        {
            if (currentFrame < 7) ActivateLimbs(true, "RightHand");//, "RightForeArm");
        }
        else
        {
            ActivateLimbs(false, "RightHand");//, "RightForeArm");
        }

        if (stateInfo.IsName("LeftKick"))
        {
            if (currentFrame < 7) ActivateLimbs(true, "LeftUpLeg");//, "LeftLeg", "LeftToeBase");
        }
        else
        {
            ActivateLimbs(false, "LeftUpLeg");//, "LeftLeg", "LeftToeBase");
        }

        if (stateInfo.IsName("RightKick"))
        {
            if (currentFrame < 7) ActivateLimbs(true, "RightUpLeg");//, "RightLeg", "RightToeBase");
        }
        else
        {
            ActivateLimbs(false, "RightUpLeg");//, "RightLeg", "RightToeBase");
        }

        //foreach ((string name, bool activated) in activatedLimbs)
        //{
        //    if (activated) Debug.Log(name);
        //}
    }

    void ActivateLimbs(bool activate, params string[] limbNames)
    {
        foreach (string limbName in limbNames)
        {
            activatedLimbs["mixamorig1:"+limbName] = activate;
            //GameObject obj = GameObject.Find("mixamorig1:"+limbName);
            //ActivationHelper active = (ActivationHelper)obj.GetComponent("ActivationHelper");
            //if (active is null) Debug.Log("COULD NOT FIND " + limbName);
            //if (active is null) continue;
            //active.activated = activate;

            //Debug.Log(limbName + " is" + (active.activated ? "" : " not") + " activated");
        }
    }
}