using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public int direction;
    public int health;


    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.name == "Player 1") direction = 1;
        else direction = -1;

        health = 100;
    }
}
