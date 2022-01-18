using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody2D),typeof(AudioSource))]
public class Projectile : MonoBehaviour
{
    [Header("Game setting")]
    [SerializeField] private float _timeDestroy;
    [SerializeField] private float _speed;
    [Header("Scene setting")]
    [SerializeField] private TransfomrObject[] _transfomrObjects;
    [SerializeField] private Animation animationSmoke;
    [SerializeField] private GameObject _transformableSound;

    private Rigidbody2D _rigidBody;
    private AudioSource _sourse;

    private void Awake()
    {
        // var a = animationSmoke = GetComponent<Animation>();
        _sourse = GetComponent<AudioSource>();
        Destroy(gameObject, _timeDestroy);
        _rigidBody = GetComponent<Rigidbody2D>();    
    }
    public void StarMoving(float direction)
    {
        _rigidBody.velocity = transform.right * _speed * direction;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        var hitObject = collision.GetComponent<ITransformable>();
        if (hitObject != null)
        {
            Instantiate(_transformableSound, transform.position, Quaternion.identity);
            var b = animationSmoke.playAutomatically;
            var objects = DefineList(_transfomrObjects, hitObject.Type);
            objects = Filtre(hitObject.TypeTransformable,objects);
            hitObject.HandleTransforming(Randomtransforn(objects));  
            Destroy(gameObject);
            Debug.Log( "  " + b );
        }
    }
    private List<TransfomrObject> DefineList(TransfomrObject[] arrayObject, TypeObject hitObject)
    {
        List<TransfomrObject> chooseObject = new List<TransfomrObject>();
        for (int i = 0; i < arrayObject.Length; i++)
        {
            if (arrayObject[i].Type != hitObject)
            {
                chooseObject.Add(arrayObject[i]);
            }
        }
        return chooseObject;
    }
    private List<TransfomrObject> Filtre(TypeTransformable type,List<TransfomrObject> objects)
    {
        List<TransfomrObject> chooseObject = new List<TransfomrObject>();
        for (int i = 0; i < objects.Count; i++)
        {
            if (objects[i].TypeTransformable == type)
            {
                chooseObject.Add(objects[i]);
            }
        }
        return chooseObject;
    }
    private TransfomrObject Randomtransforn(List<TransfomrObject> list)
    {
        if (list.Count == 0)
            return null;
        int index = Random.Range(0, list.Count);
        return list[index];
    } 
}