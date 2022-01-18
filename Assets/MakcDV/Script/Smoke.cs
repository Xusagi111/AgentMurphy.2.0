using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smoke : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spite;

    private void Awake()
    {
        _spite.enabled = false;
    }

    private void OnEnableSprite()
    {
        _spite.enabled = true;
    }

    private void DestroySmoke()
    {
        Destroy(gameObject);
    }
}
