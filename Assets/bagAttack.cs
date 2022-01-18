using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BagAttack : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private AudioClip _hitSound;

    private Player _player;
    private AudioSource _sourse;

    private void Awake()
    {
        _sourse = GetComponent<AudioSource>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            _player = null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "Player")
        {
            _animator.SetBool("Punch", true );
            _player = collision.GetComponent<Player>();
            GetComponentInParent<EnemyController>().CloseAttack();
        }
    }
    public  void  deadPlayerp()
    {
        _sourse.PlayOneShot(_hitSound);
        if (_player != null)
        {
            _player.InvokeDeadEvent();
        }  
    }
}
