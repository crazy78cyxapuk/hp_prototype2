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

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shot();
        }
    }

    private void Shot()
    {
        Transform target = targetManager.lastTarget;
        targetManager.NextTarget();

        GameObject newBullet = Instantiate(bullet, startPositionBullet.position, Quaternion.identity);
        Bullet thisBullet = newBullet.AddComponent<Bullet>();

        thisBullet.target = target;
        //thisBullet.TurnTowardsTarget();
    }
}
