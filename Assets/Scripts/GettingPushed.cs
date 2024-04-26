using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GettingPushed : MonoBehaviour
{
    private BoxCollider playerCollider;
    private PlayerController control;
    private PlayerController otherControl;
    private Rigidbody rb;
    private Rigidbody rbOther;
    private Animator animator;
    private Animator otherAnimator;
    private Transform tf;
    private PlayerData facing;
    public float intendedSpeed;
    public bool colliding;

    const float moveForwardSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        playerCollider = GetComponent<BoxCollider>();
        control = GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody>();
        tf = GetComponent<Transform>();
        animator = GetComponent<Animator>();
        facing = GetComponent<PlayerData>();
        intendedSpeed = 0;
        colliding = false;
    }

    void OnTriggerStay(Collider other)
    {
        GameObject limbObj = other.gameObject;
        string limbName = limbObj.name;
        GameObject otherPlayer = limbObj.GetComponent<Transform>().root.gameObject;
        if (otherPlayer == limbObj && playerCollider.enabled)
        {
            AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
            otherAnimator = otherPlayer.GetComponent<Animator>();
            AnimatorStateInfo otherInfo = otherAnimator.GetCurrentAnimatorStateInfo(0);

            if (!stateInfo.IsName("Running") && !otherInfo.IsName("Running"))
                tf.position = new Vector3(tf.position.x - 0.05f * facing.direction, tf.position.y, tf.position.z);

            colliding = stateInfo.IsName("Running") || otherInfo.IsName("Running");
            otherControl = otherPlayer.GetComponent<PlayerController>();
            rbOther = otherPlayer.GetComponent<Rigidbody>();
            if (control.horizontal == 0)
            {
                intendedSpeed = moveForwardSpeed / 6;
                //rbOther.velocity = new Vector3(rbOther.velocity.x / 3, rbOther.velocity.y, rbOther.velocity.z);
                //rb.velocity = rbOther.velocity;
                //otherControl.horizontal = otherControl.horizontal / 3;
                //control.horizontal = otherControl.horizontal;
            }
            else
            {
                if (otherControl.horizontal != 0)
                    intendedSpeed = 0;
                else
                {
                    intendedSpeed = moveForwardSpeed / 6;
                }
                //control.horizontal = 0;
                //otherControl.horizontal = 0;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        colliding = false;
    }
}