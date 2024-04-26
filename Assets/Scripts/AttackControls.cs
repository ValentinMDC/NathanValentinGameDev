using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackControls : MonoBehaviour
{

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("LeftPunch", false);
        animator.SetBool("RightPunch", false);
        animator.SetBool("LeftKick", false);
        animator.SetBool("RightKick", false);


        if (Input.GetKeyDown("u"))
        {
            animator.SetBool("LeftPunch", true);
        }

        if (Input.GetKeyDown("i"))
        {
            animator.SetBool("RightPunch", true);
        }

        if (Input.GetKeyDown("j"))
        {
            animator.SetBool("LeftKick", true);
        }

        if (Input.GetKeyDown("k"))
        {
            animator.SetBool("RightKick", true);
        }
    }
}
