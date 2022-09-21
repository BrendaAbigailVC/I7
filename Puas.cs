using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puas : MonoBehaviour
{
    public GameObject Reiniciar;
    public Image GameOver;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Enemy")
        {
            Reiniciar.gameObject.SetActive(true);
            GameOver.enabled = true;
            Destroy(gameObject);
        }  
    }  

}
