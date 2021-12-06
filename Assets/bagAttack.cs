using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bagAttack : MonoBehaviour
{
    [SerializeField] Animator Animdead;
    private Player player;
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            player = null;
            Debug.Log("Exit");
        }
            
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "Player")
        {
            Debug.Log("Enter");
            Animdead.SetBool("Punch", true );
            player = collision.GetComponent<Player>();
            GetComponentInParent<EnemyController>().CloseAttack();
        }
    }
    public  void  deadPlayerp()
    { if(player != null)
        {
            player.InvokeDeadEvent();
            Debug.Log("Dead");
        }  
    }

}
