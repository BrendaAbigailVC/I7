using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ovni1 : MonoBehaviour
{
    public Transform Gatito;
    public GameObject BulletPrefab;
    public GameObject Reiniciar;
    public Image GameOver;
    
    private int Health = 3;
    private float Last;

    public void Update(){
        GameOver.enabled = false;
        Reiniciar.gameObject.SetActive(false);

        if (Gatito == null) return;

        Vector3 direction = Gatito.position - transform.position;

        if (direction.x >= 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        else transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);

        float distance = Mathf.Abs(Gatito.position.x - transform.position.x);

        if (distance < 1.0f && Time.time > Last + 0.25f)
        {
            Shoot();
            Last = Time.time;
        }
    }

    private void Shoot(){
        Vector3 direction = new Vector3(transform.localScale.x, 0.0f, 0.0f);
        GameObject bullet = Instantiate(BulletPrefab, transform.position + direction * 0.40f, Quaternion.identity);
        bullet.GetComponent<BulletScript>().SetDirection(direction);
    }
    
    public void Hit()
    {
        Health = Health - 1;
        if (Health == 0) Destroy(gameObject);
        Win();
    }

    public void Win(){
        Reiniciar.gameObject.SetActive(true);
        GameOver.enabled = true;
    }

   
}
