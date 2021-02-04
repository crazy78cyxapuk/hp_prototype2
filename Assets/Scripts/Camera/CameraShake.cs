using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private Vector3 startPosition;
    private float speedShake = 100f;
    private float strengthShake = 2f;

    private void Start()
    {
        startPosition = transform.position;
    }

    public void Shake()
    {
        float targetPosition = transform.position.x - strengthShake;

        while (transform.position.x > targetPosition)
        {
            transform.position -= new Vector3(1, 0, 0) * speedShake * Time.deltaTime;
        }

        StartCoroutine(ShakeReverse());
    }

    IEnumerator ShakeReverse()
    {
        yield return new WaitForSeconds(0.05f);
        while (startPosition.x > transform.position.x)
        {
            transform.position += new Vector3(1, 0, 0) * speedShake * Time.deltaTime;
        }
    }
}
