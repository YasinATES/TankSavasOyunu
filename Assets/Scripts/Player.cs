using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Player hareketleri için.
    string moveAxisName="Vertical";
    string turnAxisName="Horizontal";
    float moveAxsis;
    float turnAxis;
    float moveSpeed=10f;
    float turnSpeed=240f;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

   
    void Update()
    {
        //İnput ile ilgili bütün işlerde update kullan.
        moveAxsis = Input.GetAxis(moveAxisName);
        turnAxis = Input.GetAxis(turnAxisName);
        //turn axsis ad tuşlarını 1 veya -1 atıyor
        //move axsis ws tuşlarına 1 ve -1 atıyor.

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GetComponent<ShootBehavior>().Shoot();
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(transform.position + transform.forward * moveAxsis * moveSpeed * Time.deltaTime );
        //öteleme için movePosition fonksiyonu kullanılır.

        Quaternion rotation = Quaternion.Euler(0, turnAxis * turnSpeed * Time.deltaTime, 0);
        //Quaternion'ı çok bilmenize gerek yok basitçe;
        //Euler açılarını kullanabilmemiz için yani dönmek için kullandık.

        rb.MoveRotation(transform.rotation * rotation);
        //dönme için MoveRotation fonksiyonu kullanılır.
    }
}

