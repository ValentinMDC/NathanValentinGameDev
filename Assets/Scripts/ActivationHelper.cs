using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivationHelper : MonoBehaviour
{
    [SerializeField] public bool activated;

    void Start()
    {
        activated = false;
        //Debug.Log(gameObject.name);
    }
}
