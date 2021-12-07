using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private float _fakeShootProbility;
    [SerializeField] private Controller _controller;
    [SerializeField] private SpriteRenderer _playerSprite;

    private Animator _animator;

    public int Direction => _playerSprite.flipX ? -1 : 1;

    private void Awake()
    {
        _fakeShootProbility = Mathf.Clamp01(_fakeShootProbility);
        _animator = GetComponent<Animator>();

    }
    private void OnEnable()
    {
        _controller.ShootEvent += ShootAnimation;
    }
    private void OnDisable()
    {
        _controller.ShootEvent -= ShootAnimation;
    }
    private void Start()
    {

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
        _animator.SetBool("isRight",_playerSprite.flipX);
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
    private int RoundDirection(float direction)
    {
        if (direction > 0)
            return 1;
        else if (direction < 0)
            return -1;
        return 0;
    }

    private void ShootAnimation()
    {
        float probillity = Random.Range(0f, 1f);
        if (_fakeShootProbility >= probillity)
        {
            FakeShootState(true);
        }
        else
        {
            _animator.SetTrigger("shooted");
        }
    }
    private void OnStopFakeShoot()
    {
        FakeShootState(false);
    }
    private void FakeShootState(bool value)
    {
        _animator.SetBool("fakeShoot", value);
    }
    public void AnimateShoot()
    {
        _animator.SetTrigger("Shooted");
    }
}
