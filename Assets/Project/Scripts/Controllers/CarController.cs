using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] float speed = 3;
    void Start()
    {
        
    }
    void FixedUpdate()
    {
        
            transform.Translate(Vector3.right * Time.deltaTime * speed, Camera.main.transform);
            Debug.Log("AAAA");
        
    }
}
