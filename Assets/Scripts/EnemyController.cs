using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float lookRadius = 6f;

    Transform target;
    NavMeshAgent agent;
    private Animator animator;
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        target = PlayerManager.instance.Player.transform;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        
        if(distance <= lookRadius)
        {
            animator.SetBool("isPlayerDetected", true);
            agent.SetDestination(target.position);

            if (distance <= agent.stoppingDistance)
            {
                animator.SetBool("nearPlayer", true);
                animator.SetBool("isPlayerDetected", false);
                FaceTarget();
                
            }
            else
            {
                animator.SetBool("nearPlayer", false);
            }
        }
        else 
        {
            animator.SetBool("isPlayerDetected", false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        this.Invoke("Attack", 1f);
    }

    private void Attack()
    {
        player.DamageToPlayer(10);
    }
    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 4f);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
