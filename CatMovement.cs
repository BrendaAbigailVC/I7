using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatMovement : MonoBehaviour
{
    public float Speed;
    public float JumpForce;
    public GameObject BulletPrefab;
    public GameObject Reiniciar;
    public Image GameOver;

    private Rigidbody2D Rigidbody2D;
    private Animator Animator;
    private float Horizontal;
    private bool Grounded;
    private float LastShoot;
    
    [SerializeField] int Health;
    [SerializeField] Slider sliderHealth;

    private void Start()
    {
        sliderHealth.maxValue = Health;
        sliderHealth.value = sliderHealth.maxValue;

        GameOver.enabled = false;
        Reiniciar.gameObject.SetActive(false);

        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
    }

    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");
        Animator.SetBool("running", Horizontal != 0.0f);
        
        if (Horizontal < 0.0f) transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if (Horizontal > 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        //Detectar suelo
        //Debug.DrawRay(transform.position, Vector3.down * 0.45f, Color.red);
        
        if (Physics2D.Raycast(transform.position, Vector3.down, 0.50f))
        {
            Grounded = true;
        }
        else Grounded = false;

        //Salto

        if (Input.GetKeyDown(KeyCode.W) && Grounded)
        {
            Jump();
        }
        //Disparo
        if (Input.GetKey(KeyCode.Space)&& Time.time > LastShoot + 0.25f)
        {
            Shoot();
            LastShoot = Time.time;
        }
    }

    private void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(Horizontal, Rigidbody2D.velocity.y);
    }
    
    private void Jump()
    {
        Rigidbody2D.AddForce(Vector2.up * JumpForce);
    }

    private void Shoot()
    {
        Vector3 direction;
        if (transform.localScale.x == 1.0f) direction = Vector3.right;
        else direction = Vector3.left;

        GameObject bullet = Instantiate(BulletPrefab, transform.position + direction * 0.45f, Quaternion.identity);
        bullet.GetComponent<BulletScript>().SetDirection(direction);
    }

    public void Hit()
    {
        Health = Health - 1;
        sliderHealth.value = Health;
        if (Health == 0){
            Destroy(gameObject);
            GameOv();
        }  
    }

    public void GameOv(){
        Reiniciar.gameObject.SetActive(true);
        GameOver.enabled = true;
    }
}