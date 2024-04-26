using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GettingHit2 : MonoBehaviour
{
    private Animator animator;
    private BoxCollider playerCollider;
    private BoxCollider otherCollider;
    private PlayerController control;
    private PlayerController otherControl;

    void Start()
    {
        animator = GetComponent<Animator>();
        playerCollider = GetComponent<BoxCollider>();
        control = GetComponent<PlayerController>();
    }

    void FixedUpdate()
    {
        animator.SetBool("GotHit", false);
    }

    void OnTriggerEnter(Collider other)
    {
        GameObject limbObj = other.gameObject;
        otherCollider = limbObj.GetComponent<BoxCollider>();
        string limbName = limbObj.name;

        if (limbName == "mixamorig1:LeftHand") Debug.Log(otherCollider.enabled);

        GameObject otherPlayer = limbObj.GetComponent<Transform>().root.gameObject;
        if (!otherCollider.enabled || (otherPlayer == limbObj && playerCollider.enabled))
        {
            //Debug.Log("good thing happening " + limbName);
            return;
        }

        //Debug.Log(limbName);

        limbObj.GetComponent<BoxCollider>().enabled = false;

        animator.Play("FlinchAnimation");
        animator.SetBool("GotHit", true);

        //LimbActivation otherLimbScript = otherPlayer.GetComponent<LimbActivation>();
        //Dictionary<string, bool> otherLimbs = otherLimbScript.activatedLimbs;

        //bool activated;
        //if (otherLimbs.TryGetValue(limbName, out activated) && activated)
        //{
        //    animator.Play("FlinchAnimation");
        //    animator.SetBool("GotHit", true);
        //    otherLimbs[limbName] = false;
        //}
    }

    void OnTriggerExit(Collider other)
    {
        GameObject limbObj = other.gameObject;
        string limbName = limbObj.name;
        GameObject otherPlayer = limbObj.GetComponent<Transform>().root.gameObject;
        if (otherPlayer == limbObj && playerCollider.enabled)
        {
            return;
        }

        Debug.Log("exited");

        limbObj.GetComponent<BoxCollider>().enabled = true;
    }
}
