using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinSword : MonoBehaviour
{
    [SerializeField]
    private Animator goblinAnim;

    private int damage = 15;

    private void OnTriggerEnter(Collider o)
    {
        if(goblinAnim.GetCurrentAnimatorStateInfo(0).IsName("Standing Melee Attack Downward"))
        {
            PlayerStats hit = o.gameObject.GetComponent<PlayerStats>();
            if (hit != null)
                hit.hitPlayer(damage);
        }
    }
}
