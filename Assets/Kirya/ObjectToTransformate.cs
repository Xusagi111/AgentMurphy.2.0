using UnityEngine;

public class ObjectToTransformate : MonoBehaviour, ITransformable
{
    [SerializeField] private TypeObject _type;
    [SerializeField] private TypeTransformable _typeTransformable;

    public TypeObject Type => _type;
    public TypeTransformable TypeTransformable => _typeTransformable;

    public bool HandleTransforming(TransfomrObject instateObject)
    {
        GameObject transformableObject = null;
        if(instateObject != null)
        {
            Vector3 instatePosition = new Vector3(transform.position.x, transform.position.y, 0) + instateObject.InstateOffset;
            transformableObject = Instantiate(instateObject.InstateObject, instatePosition, Quaternion.identity);
            OffTrasformate(transformableObject);
            Destroy(gameObject);
        }
        return transformableObject;
    }
    private bool OffTrasformate(GameObject objects)
    {
        if (_typeTransformable == TypeTransformable.BackGroundObject)
        {
            var transformate = objects.GetComponent<Collider2D>();
            if (transformate != null)
            {
                transformate.enabled = false;
                return true;
            }
        }
        return false;
    }
}
