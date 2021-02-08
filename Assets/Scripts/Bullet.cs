using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 100;

    [HideInInspector] public Transform target;
    [HideInInspector] public bool isInit = false;

    private Vector3 pointFlewCenter;
    private float t = 0;

    private void Update()
    {
        if (isInit)
        {
            //transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

            //Bezier!!!
            if (t <= 1f)
            {
                transform.position = Spline.GetPointQuadro(transform.position, pointFlewCenter, target.position, t);
                t += 0.03f;
            }

            transform.up = Vector3.Lerp(transform.up, target.position - transform.position, 0.5f);

            if(Vector3.Distance(transform.position, target.position) < 0.1f)
            {
                Zeroing();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Human"))
        {
            Debug.Log("HUMAN");
        }

        if (other.gameObject.CompareTag("Target"))
        {
            Camera.main.GetComponent<CameraShake>().Shake();
        }
    }

    public void Initialization(Transform target)
    {
        this.target = target;

        pointFlewCenter = new Vector3((transform.position.x + target.position.x) / 2f, (transform.position.y + target.position.y) / 1.2f, (transform.position.z + target.position.z) / 2f);

        isInit = true;
    }

    private void Zeroing()
    {
        isInit = false;
        t = 0;
    }
}