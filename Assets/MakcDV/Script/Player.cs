using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private int _speedMovement;
    [SerializeField] private Controller _controller;
    [SerializeField] private JumpAnimation _jumpAnimation;
    [SerializeField] private Stats _playerStats;

    private IJump _playerJump;
    private PhysicMovement _movement;

    public delegate void PlayerEvent();
    public PlayerEvent PlayerEventAction;

    private void Awake()
    {
        _playerJump = _jumpAnimation;
        _movement = new PhysicMovement(_speedMovement, GetComponent<Rigidbody2D>());
    }
    private void OnEnable()
    {
        _controller.JumpEvent += _playerJump.Jump;
    }
    private void OnDisable()
    {
        _controller.JumpEvent -= _playerJump.Jump;
    }
    private void FixedUpdate()
    {
        _movement.Move(_controller.Direction);
    }
    public void InvokeDeadEvent()
    {
        if (PlayerEventAction != null)
            PlayerEventAction();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Resource>() !=null )
        {
            _playerStats.PlusOneBullet();
            Destroy(collision.gameObject);
        }
    }
}
