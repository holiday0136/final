using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn2 : MonoBehaviour
{
    [SerializeField] float Force;
    Rigidbody bulletRigidBody;
    public float DestroyTime = 0.2f;


    // Start is called before the first frame update
    void Start()
    {
        bulletRigidBody = GetComponent<Rigidbody>();

        bulletRigidBody.AddForce(transform.up * Force);

        Destroy(gameObject, DestroyTime);
    }

    
}
