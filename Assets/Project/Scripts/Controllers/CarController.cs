using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private AudioSource SoundOfPassigByCar;
    private Rigidbody2D _rb;
    [SerializeField] float speed = 3;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.gravityScale = 0;
        SoundOfPassigByCar = GetComponent<AudioSource>();
    }
    void FixedUpdate()
    { 
        transform.Translate(Vector3.right * Time.deltaTime * speed, Camera.main.transform);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            Debug.Log(player.name); 
            SoundOfPassigByCar.Play();
        }
        if (collision.gameObject.CompareTag("Edgemap"))
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            SoundOfPassigByCar.Stop();
        }
    }
}
