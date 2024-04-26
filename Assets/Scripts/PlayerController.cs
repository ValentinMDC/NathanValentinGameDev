using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float horizontal;
    private float speed;
    private Vector3 startingPos;
    private float yRotationStart;

    private Rigidbody rb;
    private Animator animator;
    private Transform tf;
    private GettingPushed pushedScript;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        animator = GetComponent<Animator>();
        tf = GetComponent<Transform>();
        tf.position = startingPos;
        yRotationStart = tf.localEulerAngles.y;

        pushedScript = GetComponent<GettingPushed>();
    }

    // Update is called once per frame
    void Update()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        if (stateInfo.IsName("Bouncing Fight Idle") || stateInfo.IsName("Running") || stateInfo.IsName("Walking Backwards"))
        {
            if (gameObject.name != "Player 2") horizontal = Input.GetAxisRaw("Horizontal");
            else horizontal = 0;

            if (horizontal > 0) horizontal = 1;
            if (horizontal < 0) horizontal = -1;
            if (horizontal < 0) speed = 2.5f;
            else speed = 5f;
        }
        else
        {
            horizontal = 0;
        }

        rb.velocity = new Vector3(pushedScript.colliding ? pushedScript.intendedSpeed : horizontal * speed, rb.velocity.y, rb.velocity.z);

        if (horizontal != 0)
        {
            tf.GetChild(0).rotation = Quaternion.Euler(0, yRotationStart + 30, 0);
        }
        else
        {
            tf.GetChild(0).rotation = Quaternion.Euler(0, yRotationStart, 0);
        }

        animator.SetInteger("HorizontalMovement", (int)horizontal);

    }
}
