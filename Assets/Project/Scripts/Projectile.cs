using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{
    [SerializeField] private float _timeDestroy;
    [SerializeField] private float _speed;
    [SerializeField] private TransfomrObject[] _transfomrObjects;

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
        var hitObject = collision.GetComponent<ITransformable>();
        if (hitObject != null)
        {
            var objects = DefineList(_transfomrObjects, hitObject.Type);
            objects = Filtre(hitObject.TypeTransformable,objects);
            hitObject.HandleTransforming(Randomtransforn(objects));
            Destroy(gameObject);
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