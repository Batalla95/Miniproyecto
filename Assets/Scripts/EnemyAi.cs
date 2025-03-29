using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public PlayerHealth health;

    public Entity enemyHealth;
    

    public LayerMask whatIsGround;
    public LayerMask whatIsPlayer;

    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public float damage;

    public float sightRange;
    public float attackRange;

    public bool playerIsInSightRange;
    public bool playerIsInAttackRange;
    public bool attack;

    public EnemyController enemyController;

    private void Awake()
    {
        
        agent = GetComponent<NavMeshAgent>();
        enemyController = GetComponent<EnemyController>();
        enemyHealth = GetComponent<Entity>();
    }


    private void Update()
    {
        playerIsInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerIsInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerIsInSightRange && !playerIsInAttackRange && enemyHealth.health>0)
        {
            Patroling();
            enemyController.UpdateAttack(playerIsInAttackRange);
        }
        if (playerIsInSightRange && !playerIsInAttackRange && enemyHealth.health > 0)
        {
            ChasePlayer();
            enemyController.UpdateAttack(playerIsInAttackRange);
        }
        if (playerIsInSightRange && playerIsInAttackRange && enemyHealth.health>0)
        {
            AttackPlayer();
            
        }

       

    }


    private void Patroling()
    {
        if (!walkPointSet)
        {
            SearchWalkPoint();
        }

        if (walkPointSet)
        {
            
            agent.SetDestination(walkPoint);
        }

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if (distanceToWalkPoint.magnitude < 1f)
        {
            walkPointSet = false;
        }
    }

    private void SearchWalkPoint()
    {
        float ramdomZ = Random.Range(-walkPointRange, walkPointRange);
        float ramdomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + ramdomX, transform.position.y, transform.position.z + ramdomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
        {
            walkPointSet = true;
        }
    }

    private void ChasePlayer()
    {
        
        agent.SetDestination(player.position);
       
    }

    private void AttackPlayer()
    {
        agent.SetDestination(transform.position);
        transform.LookAt(player);
        enemyController.UpdateAttack(playerIsInAttackRange);

        if (!alreadyAttacked)
        {
            health.Health -= damage;
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
            
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    public void EliminateEnemy()
    {
        Destroy(gameObject);
    }

    












}
