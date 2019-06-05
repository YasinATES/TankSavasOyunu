using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
public class EnemyAI : MonoBehaviour
{

    Transform player;
    NavMeshAgent agent;
    public Transform[] wayPoints;
    public Transform rayOrigin;
    int currentWayPointIndex = 0;
    Animator fsm; 
    Vector3[] wayPointsPos = new Vector3[3];
    float shootFreq = 5f;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < wayPoints.Length; i++)
        {
            wayPointsPos[i] = wayPoints[i].position;
        }
            

        fsm = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(wayPointsPos[currentWayPointIndex]);

        StartCoroutine("CheckPlayer");
    }


    IEnumerator CheckPlayer()
    {
        CheckVisibility();
        CheckDistance();
        CheckDistanceFromCurrentWaypoint();
        yield return new WaitForSeconds(0.1f);
        yield return CheckPlayer();
    }

    private void CheckDistanceFromCurrentWaypoint()
    {
        float distance = Vector3.Distance(wayPointsPos[currentWayPointIndex], rayOrigin.position);
        //(player.position - transform.position).magnitude;

        fsm.SetFloat("distanceFromCurrentWaypoint", distance);
    }

    private void CheckDistance()
    {
        float distance = Vector3.Distance(player.position, rayOrigin.position);
        //(player.position - transform.position).magnitude;

        fsm.SetFloat("distance", distance);
    }

    private void CheckVisibility()
    {
        float maxDistance = 20;
        Vector3 direction = (player.position - rayOrigin.position).normalized;
        Debug.DrawRay(rayOrigin.position, direction * maxDistance, Color.red);
        //Vector3 direction2 = (player.position - transform.position) / (player.position - transform.position).magnitude;

        if (Physics.Raycast(rayOrigin.position, direction, out RaycastHit info, maxDistance))
        {
            if (info.transform.tag == "Player")
                fsm.SetBool("isVisible", true);

            else
                fsm.SetBool("isVisible", false);
        }
        else
            fsm.SetBool("isVisible", false);
    }
    public void SetLoookRotation()
    {
        Vector3 dir = (player.position - transform.position).normalized;
        //düşmanın yönünü değiştirmek için birim vektör kullancaz.

        Quaternion rotation = Quaternion.LookRotation(dir);
        //dönüş ile uğraşılıyorsa Quaternion şart.
        //kısaca döndermek için kullanılacak.

        transform.rotation = Quaternion.Lerp(transform.rotation, rotation,0.2f);
        //Quaternion.Lerp kısmı aniden dönmemesi için.
        //aksi halde anında dönüyor.
        //tankın dönderilmesi işlemi.

    }

    public void Shoot()
    {

        GetComponent<ShootBehavior>().Shoot(shootFreq);
        //Ateş etme özelliği çalıştırıldı.
    }

    public void Patrol()
    {
        Debug.Log("patrolling...");
    }

    public void Chase()
    {
        agent.SetDestination(player.position);
        //chese konumunda oyuncuyu takip etmek için
    }

    public void SetNewWayPoint()
    {
        switch (currentWayPointIndex)
        {
            case 0:
                currentWayPointIndex = 1;
                break;
            case 1:
                currentWayPointIndex = 2;
                break;
            case 2:
                currentWayPointIndex = 0;
                break;
        }
        agent.SetDestination(wayPointsPos[currentWayPointIndex]);
    }
}
