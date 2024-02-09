using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{

    public int health;
    private Animator animator;

    public void Damage(int damage)
    {
        health -= damage;
        Debug.Log(health);
        if (health <= 0)
        {
            animator.SetTrigger("Exploses");
            Destroy(gameObject, 7f);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        this.animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
