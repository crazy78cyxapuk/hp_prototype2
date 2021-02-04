using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 100;

    [HideInInspector] public Transform target;
    [HideInInspector] public bool isInit = false;

    private void Update()
    {
        if (isInit)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            transform.up = Vector3.Lerp(transform.up, target.position - transform.position, 0.5f);

            if(Vector3.Distance(transform.position, target.position) < 0.1f)
            {
                Zeroing();
                Camera.main.GetComponent<CameraShake>().Shake();
            }
        }
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Target"))
    //    {
    //        isFlew = true;
    //        Camera.main.GetComponent<CameraShake>().Shake();
    //        Debug.Log(2);
    //    }

    //    if (collision.gameObject.CompareTag("Human"))
    //    {
    //        Debug.Log("HUMAN");
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Human"))
        {
            Debug.Log("HUMAN");
        }
    }

    private void Zeroing()
    {
        isInit = false;
    }
}