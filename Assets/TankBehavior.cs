using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class TankBehavior : MonoBehaviour
{
    private Rigidbody2D _Rb;
    private SpriteRenderer _Sp;
    public float Speed;
    public float RotationSpeed;
    public float fireCooldown;
    public int health;
    public Transform TourelleTransform;
    public Transform ShootPosition;
    public GameObject BulletPrefab;
    public Animator Anim;
    


    public KeyCode Haut;
    public KeyCode Bas;
    public KeyCode Gauche;
    public KeyCode Droite;
    public KeyCode TourelleDroite;
    public KeyCode TourelleGauche;
    public KeyCode Tirer;
    public bool Player1;


    private bool canFire = true;
    
    private float currentCooldown;


    // Start is called before the first frame update
    void Start()
    {
        _Rb = GetComponent<Rigidbody2D>();
        _Sp = GetComponent<SpriteRenderer>();
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(Haut)) //HAUT 
        {
           transform.Rotate(0,0, RotationSpeed);
            Anim.SetBool("isMoving", true);

        }

        if (Input.GetKey(Gauche)) // RECULER 
        {
            transform.position += Speed * Time.deltaTime * -transform.right;
            Anim.SetBool("isMoving", true);

        }

        else if (Input.GetKey(Droite)) // AVANCER 
        {
            transform.position += Speed * Time.deltaTime * transform.right;
            Anim.SetBool("isMoving", true);

        }
        else
        {
            Anim.SetBool("isMoving", false);
        }

        if (Input.GetKey(Bas)) //BAS 
        {
            transform.Rotate(0, 0, -RotationSpeed);

        }
        

        if (Input.GetKey(TourelleDroite)) //Rotation Tourelle 
        {
            TourelleTransform.Rotate( 0, 0,RotationSpeed);
        }

        if (Input.GetKey(TourelleGauche)) //Rotation Tourelle 
        {
            TourelleTransform.Rotate(0, 0, -RotationSpeed);
        }

        if (Input.GetKeyDown(Tirer) && !canFire) // Ne peux pas tirer : 
        {
            if (health > 0)
                if (Player1)
                {
                    GameManagerScript.Instance.reloadingMessage1.ShowMessage();
                }
                else
                {
                    GameManagerScript.Instance.reloadingMessage2.ShowMessage();
                }
                
        }

        if (Input.GetKeyDown(Tirer) && canFire) // Tire
        {
            FireBullet();
            if (Player1)
                GameManagerScript.Instance.reloadingMessage1.HideMessage();
            else
                GameManagerScript.Instance.reloadingMessage2.HideMessage();

            StartCoroutine(BulletCooldown());
        }
       
        
    }

    IEnumerator BulletCooldown()
    {
        if(health > 0)
        {
            if (Player1)
                GameManagerScript.Instance.progressBar1.ShowSlider();
            else
                GameManagerScript.Instance.progressBar2.ShowSlider();

            canFire = false;
            currentCooldown = fireCooldown;
            if (Player1)
            {
                GameManagerScript.Instance.progressBar1.SetMaxCooldown(fireCooldown);
            }
            else
            {
                GameManagerScript.Instance.progressBar2.SetMaxCooldown(fireCooldown);
            }
            
            while (currentCooldown > 0f)
            {
                if (Player1)
                {
                    GameManagerScript.Instance.progressBar1.SetCooldown(currentCooldown);
                }
                else
                {
                    GameManagerScript.Instance.progressBar2.SetCooldown(currentCooldown);

                }

                yield return new WaitForSeconds(0.1f); // Update the progress bar every 0.1 second
                currentCooldown -= 0.1f;
            }
            if (health > 0)
                canFire = true;
            if (Player1)
            {
                GameManagerScript.Instance.progressBar1.HideSlider();
                GameManagerScript.Instance.progressBar1.SetCooldown(0f);
                GameManagerScript.Instance.reloadingMessage1.HideMessage();
            }
            else
            {
                GameManagerScript.Instance.progressBar2.HideSlider();
                GameManagerScript.Instance.progressBar2.SetCooldown(0f);
                GameManagerScript.Instance.reloadingMessage2.HideMessage();
            }
            
        }
        
    }

    void FireBullet()
    {
        Instantiate(BulletPrefab, ShootPosition.position, ShootPosition.rotation);
    }

    public void Damage(int damage)
    {
        health -= damage;
        if (Player1)
        {
            GameManagerScript.Instance.lifebar1.RemoveHealthFromSlider(damage);
        }
        else
        {
            GameManagerScript.Instance.lifebar2.RemoveHealthFromSlider(damage);
        }
        if (health <= 0)
        {
            canFire = false;
            if (Player1)
                GameManagerScript.Instance.lifebar1.deleteFiller();
            else
                GameManagerScript.Instance.lifebar2.deleteFiller();
            Speed = 0.0f;
            RotationSpeed = 0.0f;
            Anim.SetBool("Exploses",true);
            GameManagerScript.Instance.callCoroutinePauseGame();
            Debug.Log("Calling PauseGame from tank...");
            
            if (Player1)
            {
                GameManagerScript.Instance.WinLooseText2.SetText("You Win !");
                GameManagerScript.Instance.WinLooseText1.SetText("You Loose !");
                GameManagerScript.Instance.AttributePoints(false);
            }
            else
            {
                GameManagerScript.Instance.WinLooseText2.SetText("You Loose !");
                GameManagerScript.Instance.WinLooseText1.SetText("You Win !");
                GameManagerScript.Instance.AttributePoints(true);
            }
            Destroy(gameObject, 7f);
        }
    }

    
}
