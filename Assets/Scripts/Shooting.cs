using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [Header("Префаб пули")]
    [SerializeField] private GameObject bullet;

    [Header("Скрипт со всеми мишенями")]
    [SerializeField] private TargetManager targetManager;

    [Header("Начальные координаты пули")]
    [SerializeField] private Transform startPositionBullet;

    private GameObject lastBullet;
    private bool isRecharge;

    private void Start()
    {
        StartCoroutine(CreateBullet(0.1f));
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && isRecharge)
        {
            Shot();
        }
    }

    private void Shot()
    {
        isRecharge = false;

        Transform target = targetManager.lastTarget;
        targetManager.NextTarget();

        //GameObject newBullet = Instantiate(bullet, startPositionBullet.position, Quaternion.identity);
        Bullet thisBullet = lastBullet.AddComponent<Bullet>();

        thisBullet.target = target;

        StartCoroutine(CreateBullet(0.5f));
    }

    IEnumerator CreateBullet(float timer)
    {
        yield return new WaitForSeconds(timer);
        lastBullet = Instantiate(bullet, startPositionBullet.position, Quaternion.identity);
        isRecharge = true;
    }
}
