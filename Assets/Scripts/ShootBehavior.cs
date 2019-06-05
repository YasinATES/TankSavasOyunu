using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBehavior : MonoBehaviour
{
    //Instantiate ile prefab kopyalayacağız.
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    float forceAmaount = 1200f;
    float timeFromLastShoot;

    //Riidbody'sini alcaz addforce ile iteceğiz.
    public void Shoot(float shootFreq)
    {
        //saniyede ateş etme sayısı için kontrol
        if ((timeFromLastShoot += Time.deltaTime) >= 1f/ shootFreq)
        {
            InstantiateBullet();
            timeFromLastShoot = 0;
        }
    }

    public void Shoot()
    {
        InstantiateBullet();
        //Player ateş edeceği zaman çalışacak.
    }


    private void InstantiateBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.identity);
        //Quaternion = rotasyon. identity-> birim rotasyonunu verir.
        //boş bırakamadığımız için fonksiyonu böyle kullandık.

        bullet.GetComponent<Rigidbody>().AddForce(forceAmaount * transform.forward);
        //kurşun tankın ileri yönüne doğru gömnderiliyor.
    }

}
