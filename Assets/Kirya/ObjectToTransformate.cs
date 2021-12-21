using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectToTransformate : MonoBehaviour, ITransformable
{
    public void HandleTransforming(GameObject instateObject)
    {
        if(instateObject != null)
        {
            Debug.Log(instateObject.name);
            Instantiate(instateObject, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
