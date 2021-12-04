using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyController : PlayerController
{ 
    [SerializeField] bool couldshoot =true;
    [SerializeField] float visionRadious;
    [SerializeField] float shootRadious;
    [SerializeField] float closeRadious;
    [SerializeField] float closeAttackTime; //��������� �������� ��� ��������;
    [SerializeField] LayerMask playerLayerMask;
    [SerializeField] float idleTime = 1f;
    [SerializeField] [Range(0, 1)] float idleStateChance = 0.2f;
 
    private AIState currentState;
    private Transform target;
    bool isCloseAtackInProgres=false;
    public bool CouldShoot { get { return couldshoot; }}
    public float IdleStateChance { get { return idleStateChance; } }

    public bagAttack bagAttack;

    private Animator enemyAnimator;

    private void Start()
    {
        SetState(new AIStateIdle(this));
        enemyAnimator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        currentState.StateUpdate();        
    }

    public void SetState(AIState state)
    {
        currentState = state;
    }

    public void HandleTurnPointEnter()
    {
        currentState.HandleTurnPointEnter();
    }

    public bool IfPlayerVisible()
    {
       if (ObjectsInRange(visionRadious, playerLayerMask) == null)
       {
            Debug.Log("Null ObjectsInRange");
            Debug.Log(ObjectsInRange(visionRadious, playerLayerMask) == null);
            return false;
        }
            

       foreach (GameObject obj in ObjectsInRange(visionRadious, playerLayerMask))
       {
            if (IsLookingAtTargetDirection(obj.transform))
            {
                target = obj.transform;
                
                return true;
            }
                
       }

       //Debug.Log("EnemyController: PlayerVisible");
       return false;
    }

    public void CloseAttack()
    {
        isCloseAtackInProgres = true;
        StartCoroutine(Attack(closeAttackTime));
    }
    IEnumerator Attack(float time)
    {
        //TODO statr animation

        enemyAnimator.SetTrigger("Punch");
        yield return new WaitForSeconds(time);
        //TODO ������� ��������� ������� �� ���������� closeRadious (���������� �� �������� ����� ��� �� ������ ����)
        // ���� � ���� ��������� ����� �����, �� ������� Damage (����� ���������� �� projectile)

        isCloseAtackInProgres = false;
        currentState.OnStateExit(new AIStatePersuit(this));
    }
    public bool IfTargetInCloseRange()
    {
        if (target == null)
            return false;

        if ((transform.position - target.position).magnitude < closeRadious)
        {
            Debug.Log("EnemyController: TargetInShootRange");
            Debug.DrawLine(transform.position, target.position, Color.red);
            return true;
        }
        else
        {
            Debug.DrawLine(transform.position, target.position, Color.yellow);
            return false;
        }

    }

    bool IsLookingAtTargetDirection(Transform obj2)
    {        
        if (IsLookingRight() && transform.position.x<obj2.transform.position.x)
            return false;
        else if(IsLookingRight()==false && transform.position.x > obj2.transform.position.x)
            return false;
        else
        {
           // Debug.Log("EnemyController: AreLookingAtTarget");
            return true;
        }
    }

    public bool IfTargetInShootRange()
    {
        if (target == null)
            return false;

        if((transform.position - target.position).magnitude < shootRadious)
        {
            Debug.Log("EnemyController: TargetInShootRange");
            Debug.DrawLine(transform.position, target.position, Color.red);
            return true;
        }
        else
        {
            Debug.DrawLine(transform.position, target.position, Color.yellow);
            return false;
        }
        
    }

    public bool IfPlayerInShootRange()
    {
        if (ObjectsInRange(shootRadious, playerLayerMask) != null)
        {
            Debug.Log("EnemyController: IfPlayerInShootRange");
            return true;
        }
        else
        {
            
            return false;
        }
       
            
    }

    override protected GameObject ShootProjectile()
    {
        GameObject projectile = base.ShootProjectile();
        //rotate projectile to move in target direction
        return projectile;

    }

    //TODO move to AIController
    //�������, �� �������� �������� ������ � MonoBehaviour
    public void StartWaiting()
    {
        StartCoroutine(Wait(idleTime));
    }

    IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);
        currentState.OnStateExit(new AIStatePatrol(this));
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, visionRadious);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, shootRadious);
    }
}
