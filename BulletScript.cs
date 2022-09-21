using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float Speed;
    private Rigidbody2D Rigidbody2D;
    private Vector2 Direction;
    
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Rigidbody2D.velocity = Direction * Speed;
    }

    public void SetDirection(Vector2 direction)
    {
        Direction = direction;
    }

    public void DestroyBullet()
    {
        Destroy(gameObject);
    } 

    private void OnTriggerEnter2D(Collider2D collision){

        CatMovement cat = collision.GetComponent<CatMovement>();
        Ovni ovni = collision.GetComponent<Ovni>();
        Ovni1 ovni1 = collision.GetComponent<Ovni1>();

        if (cat != null)
        {
            cat.Hit();
        }
        
        if (ovni != null)
        {
            ovni.Hit();
        }

        if (ovni1 != null)
        {
            ovni1.Hit();
        }
        
        DestroyBullet();
    }
}
