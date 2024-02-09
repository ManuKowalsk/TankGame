using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BulletBehavior : MonoBehaviour
{
    public int BulletDamage;
    public float BulletSpeed;
    public Vector3 FirstBulletPosition;
    public GameObject BulletExplosionPrefab;


    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Wall"))
        {
            DestroyBullet();
        }

        if (collision.gameObject.CompareTag("Props"))
        {
            DestroyBullet();
            PropBehavior propBehavior = collision.gameObject.GetComponent<PropBehavior>();
            propBehavior.Damage(BulletDamage);
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            DestroyBullet();
            EnemyBehavior enemyBehavior = collision.gameObject.GetComponent<EnemyBehavior>();
            enemyBehavior.Damage(BulletDamage);
        }

        if (collision.gameObject.CompareTag("MyTank"))
        {
            DestroyBullet();
            TankBehavior enemyPlayerBehavior = collision.gameObject.GetComponent<TankBehavior>();
            enemyPlayerBehavior.Damage(BulletDamage);
        }

    }

    // Start is called before the first frame update
    void Start()
    {
       FirstBulletPosition = transform.position;
    }



    // Update is called once per frame
    void Update()
    {
        transform.position += BulletSpeed * Time.deltaTime * transform.right;
        if (Vector3.Distance(transform.position, FirstBulletPosition) > 10)
        {
            DestroyBullet();
        }
            
        
    }

    void DestroyBullet()
    {
        GameObject explosionInstance = Instantiate(BulletExplosionPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
        Animator explosionAnimator = explosionInstance.GetComponent<Animator>();
        float explosionDuration = explosionAnimator.GetCurrentAnimatorStateInfo(0).length;
        Destroy(explosionInstance, explosionDuration);
        
    }


}
