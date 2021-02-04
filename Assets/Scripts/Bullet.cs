using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 5000;

    [HideInInspector] public Transform target;

    private Rigidbody rb;

    private void OnEnable()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        rb.velocity = (target.position - transform.position).normalized * speed * Time.deltaTime;
        transform.up = rb.velocity;
    }

    public void LookInTarget()
    {
        var direction = (target.position - transform.position).normalized;
        transform.rotation = Quaternion.LookRotation(direction);
    }

}
