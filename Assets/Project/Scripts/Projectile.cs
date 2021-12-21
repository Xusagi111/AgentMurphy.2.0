using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{
    [SerializeField] private float _timeDestroy;
    [SerializeField] private float _speed;
    [SerializeField] private GameObject[] transformableObjects;

    private Rigidbody2D _rigidBody;

    private void Awake()
    {
        Destroy(gameObject, _timeDestroy);
        _rigidBody = GetComponent<Rigidbody2D>();
    }
    public void StarMoving(float direction)
    {
        _rigidBody.velocity = transform.right * _speed * direction;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<ITransformable>() != null)
        {
            collision.GetComponent<ITransformable>().HandleTransforming(Randomtransforn());
            Destroy(gameObject);
        }
    }
    private GameObject Randomtransforn()
    {
        int index = Random.Range(0, transformableObjects.Length);
        return transformableObjects[index];
    } 
}