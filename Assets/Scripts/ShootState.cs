using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootState : StateMachineBehaviour
{
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<EnemyAI>().SetLoookRotation();
        //State içindeyken sürekli güncellememiz gerek.
        //Nereye dönersek dönelim sürekli güncellenecek.

        animator.gameObject.GetComponent<EnemyAI>().Shoot();
    }

}
