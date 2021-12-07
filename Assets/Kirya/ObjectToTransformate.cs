using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectToTransformate : MonoBehaviour, ITransformable
{
    private GameObject currentTransformableObjeckt;
    public void HandleTransforming(GameObject gameObjectR)
    {
        if(currentTransformableObjeckt !=null)
        {
            Destroy(currentTransformableObjeckt);
        }
            
        currentTransformableObjeckt = Instantiate(gameObjectR, gameObjectR.transform.position, Quaternion.identity).gameObject;
        currentTransformableObjeckt.transform.position = transform.position; 
    }
}
