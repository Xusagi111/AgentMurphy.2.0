using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Controller _controller;
    [SerializeField] private SpriteRenderer _playerSprite;

    private Animator _animator;

    public int Direction => _playerSprite.flipX ? -1 : 1;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    private void Update()
    {
        SetAnimation(_controller.Direction);
    }
    private void SetAnimation(float direction)
    {
        var value = RoundDirection(direction);
        _animator.SetInteger("direction", value);
        _playerSprite.flipX = FlipSprite(direction);
    }
    private bool FlipSprite(float direction)
    {
        switch (direction)
        {
            case 1:
                return false;
            case -1:
                return true;
            default:
              return _playerSprite.flipX;
        }
    }
    private void CurretSide()
    {
        
    }
    private int RoundDirection(float direction)
    {
        if (direction > 0)
            return 1;
        else if (direction < 0)
            return -1;
        return 0;
    }


    public void AnimateShoot()
    {
        _animator.SetTrigger("Shooted");
    }
}
