using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Weapon : MonoBehaviour
{
    [SerializeField] private Stats _stats;
    [SerializeField] private AudioClip _fire;
    [SerializeField] private Transform weaponAnchor;
    [SerializeField] private Controller _controller;
    [SerializeField] private GameObject _projectileObject;
    [SerializeField] private PlayerAnimator _playerAnimator;

    private Projectile _projectile;
    private AudioSource _source;

    private void Awake()
    {
        _source = GetComponent<AudioSource>();
 
    }
    private void OnEnable()
    {
        _controller.ShootEvent += ShootProjectile;
    }
    private void OnDisable()
    {
        _controller.ShootEvent -= ShootProjectile;
    }

    private void ShootProjectile()
    {
        if (_stats.GetBulletsCount() > 0)
        {
            var projectileObject = Instantiate(_projectileObject, weaponAnchor.position, Quaternion.identity);
            var projectile = projectileObject.GetComponent<Projectile>();
            _stats.IncreaseOneBullet();
            if (projectile != null)
            {
                projectile.StarMoving(_playerAnimator.Direction);
                _source.PlayOneShot(_fire);
            }
            else
            {
                throw new System.NullReferenceException();
            }
        }
    }
}
