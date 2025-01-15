using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProjectile : MonoBehaviour
{
    private Rigidbody bulletRigidbody;
    // Start is called before the first frame update
    void Awake()
    {
        bulletRigidbody = GetComponent<Rigidbody>();

    }


    private void Update()
    {
        float speed = 10f;
        bulletRigidbody.velocity = transform.forward * speed;

    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
