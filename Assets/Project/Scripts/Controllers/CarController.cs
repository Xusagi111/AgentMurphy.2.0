using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField] float speed = 3;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.gravityScale = 0;
       
    }
    void FixedUpdate()
    { 
        transform.Translate(Vector3.right * Time.deltaTime * speed, Camera.main.transform);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("ToDo: add the sound of a passing car ");
        }
        if (collision.gameObject.CompareTag("Edgemap"))
        {
            Destroy(gameObject);
        }
    }
}
