using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    [SerializeField] float Force;
    Rigidbody bulletRigidBody;
    public float DestroyTime = 3f;
    // Start is called before the first frame update
    void Start()
    {
        bulletRigidBody = GetComponent<Rigidbody>();

        bulletRigidBody.AddForce(transform.up * Force);

        bulletRigidBody.AddForce(transform.forward * Force);

        Destroy(gameObject, DestroyTime);
    }
}
