using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBehaviour : MonoBehaviour
{
    public Text healthText;
    public Image healthBar;
    float health = 100;

    public void TakeDamage(float amount)
    {
        health -= amount;
        healthText.text = string.Format("%{0}", health);
        //başında % görünsün {0} parametre

        healthBar.fillAmount = health / 100f;
        //sağlık değerini barda düşürmek için
  
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}

