using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontBase : MonoBehaviour
{
    [SerializeField] private Rigidbody baseBody;
    // Start is called before the first frame update
    void Start()
    {
        baseBody = GetComponent<Rigidbody>();
        baseBody.useGravity = true;
    }
}
