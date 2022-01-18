using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Sound : MonoBehaviour
{
    [SerializeField] private AudioClip _sound;

    private AudioSource _sourse;

    private void Awake()
    {
        _sourse = GetComponent<AudioSource>();
    }

    void Start()
    {
        StartCoroutine(Play());
    }
    private IEnumerator Play()
    {
        _sourse.PlayOneShot(_sound);
        yield return new WaitForSeconds(_sound.length);
        Destroy(gameObject);
    }
}
