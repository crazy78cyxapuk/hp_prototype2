using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 100;

    [HideInInspector] public Transform target;
    [HideInInspector] public bool isInit = false;

    private Vector3 pointFlew1, pointFlew2, pointFlewCenter;
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
                //t += 1f/(Time.deltaTime * speed);
                t += 0.03f;
                //Debug.Log(t);
            }
            //transform.rotation = Quaternion.LookRotation(Bezier.GetFirstDerivative(P0.position, P1.position, P2.position, P3.position, t));

            transform.up = Vector3.Lerp(transform.up, target.position - transform.position, 0.5f);

            if(Vector3.Distance(transform.position, target.position) < 0.1f)
            {
                Zeroing();
                Camera.main.GetComponent<CameraShake>().Shake();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Human"))
        {
            Debug.Log("HUMAN");
        }
    }

    public void Initialization(Transform target)
    {
        this.target = target;

        pointFlewCenter = new Vector3((transform.position.x + target.position.x) / 2f,
            //Mathf.Max(transform.position.y, target.position.y) - Mathf.Min(transform.position.y, target.position.y) + transform.position.y,
            (transform.position.y + target.position.y) / 1.2f,
            (transform.position.z + target.position.z) / 2f);

        pointFlew1 = new Vector3((transform.position.x + pointFlewCenter.x) / 2f, pointFlewCenter.y + transform.position.y, (transform.position.z + pointFlewCenter.z) / 2f);
        pointFlew2 = new Vector3((target.position.x + pointFlewCenter.x) / 2f,  target.position.y - pointFlewCenter.y, (target.position.z + pointFlewCenter.z) / 2f);
        
        //Instantiate(this.gameObject, pointFlew1, Quaternion.identity);
        //Instantiate(this.gameObject, pointFlew2, Quaternion.identity);
        //Debug.LogError("Create pointFlew");

        isInit = true;
    }

    private void Zeroing()
    {
        isInit = false;
        t = 0;
    }
}