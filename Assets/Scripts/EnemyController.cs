using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Animator enemyAnimator;

    public string attackVariable = "Attack";
    public string deathVariable = "Death";
    public string walkVariable = "Patrol";

    

    public void Start()
    {
        enemyAnimator = GetComponent<Animator>();
    }


    public void Walk(bool Walk)
    {
        enemyAnimator.SetBool(walkVariable, Walk);
    }

    public void UpdateAttack(bool Attack)
    {
        enemyAnimator.SetBool(attackVariable,Attack);
    }

    public void Death(bool Death)
    {
        
        
          enemyAnimator.SetBool(deathVariable, Death);
        
    }
}
