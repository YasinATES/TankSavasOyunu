using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 5f);
        //bomba biyere çarpmıyorsa 5sn sonra yoket
    }

    private void OnCollisionEnter(Collision collision)
    {
        HealthBehaviour healthBehaviour = collision.gameObject.GetComponent<HealthBehaviour>();
        //çarpılan objenin sağlığı var mı yok mu?   
        if (healthBehaviour != null)
        {
            healthBehaviour.TakeDamage(20);
        }
        Destroy(gameObject, 1);
    }
}
