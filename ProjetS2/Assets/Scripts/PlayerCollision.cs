using System;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public int lifePoints = 100;

    void OnCollisionEnter(Collision collision) //Cette fonction se lance que si il y a une collision
    {
        if (collision.gameObject.tag == "Trap")
        {
            lifePoints = 0;
            print("Dead");
        }
        else
        {
            print("Loop");
        }
    }
}
