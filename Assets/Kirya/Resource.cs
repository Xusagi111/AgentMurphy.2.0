using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{
    public enum Resources
    {
        Tape
    };

    [SerializeField] Resources resourceType;

}
