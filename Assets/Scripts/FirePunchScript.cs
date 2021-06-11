using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class FirePunch : MonoBehaviour
{
    [SerializeField] float Force;
    Rigidbody bulletRigidBody;
    // Start is called before the first frame update
    void Start()
    {
        bulletRigidBody = GetComponent<Rigidbody>();

        bulletRigidBody.AddForce(transform.forward * Force);
    }

    private void OnCollisionEnter(Collision collision)
    {
        destroy();
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator destroy()
    {
        yield return new WaitForSecondsRealtime(2f);
        Destroy(gameObject);
        yield return null;
    }
}