using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dmmymove : MonoBehaviour
{
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(-5f, rb.velocity.y, rb.velocity.z);
    }
}
