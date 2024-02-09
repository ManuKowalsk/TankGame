using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropBehavior : MonoBehaviour
{
    public int health;

    public void Damage(int damage)
    {
        health -= damage;
        Debug.Log(health);
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
