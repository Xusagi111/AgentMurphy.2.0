using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{
    [Header("Set in Inspector")]
    [SerializeField] private float _timeDestroy;
    [SerializeField] float speed;
    [SerializeField] float worldBorder;
    Rigidbody2D rigid2D;
    public GameObject[] transformableObjects;
    [SerializeField] int objectType;
    System.Random random = new System.Random(System.DateTime.Now.Millisecond);
    

    private void Awake()
    {
        Destroy(gameObject, _timeDestroy);
        rigid2D = GetComponent<Rigidbody2D>();
    }
    public void StarMoving(float direction)
    {
        rigid2D.velocity = transform.right * speed * direction;
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
        int x = random.Next( transformableObjects.Length);
        while (x == objectType)
        {
            x = random.Next(0, 3);
        }
        return transformableObjects[x];
    } 
}