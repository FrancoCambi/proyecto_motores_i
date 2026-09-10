using UnityEngine;
using UnityEngine.AI;

public class EnemyCC : MonoBehaviour
{
    public Transform player;
    public float attackDistance = 2f;
    public int damage = 15;
    public float attackRate = 1.5f;

    private NavMeshAgent agent;
    private float nextAttackTime;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if (player == null) player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance > attackDistance)
        {
            agent.isStopped = false;
            agent.SetDestination(player.position);
        }
        else
        {
            agent.isStopped = true;

            // Lógica de ataque con temporizador
            if (Time.time >= nextAttackTime)
            {
                AttackPlayer();
                nextAttackTime = Time.time + attackRate;
            }
        }
    }

    void AttackPlayer()
    {
        Health playerHealth = player.GetComponent<Health>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage);
        }
    }
}