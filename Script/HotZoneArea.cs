using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotZoneArea : MonoBehaviour
{
    private EnemyController enemyParent;
    private bool inRange;
    private Animator anim;

    private void Awake()
    {
        enemyParent = GetComponentInParent<EnemyController>();
        anim = GetComponentInParent<Animator>();
    }

    private void Update()
    {
        if (inRange && !anim.GetCurrentAnimatorStateInfo(0).IsName("GhostAttack"))
        {
            enemyParent.Flip();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            inRange = false;
            gameObject.SetActive(false);
            enemyParent.triggerArea.SetActive(true);
            enemyParent.inRange = false;
            enemyParent.Patrol();
        }
    }
}
