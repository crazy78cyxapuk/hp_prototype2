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

    private bool isRecharge = false;

    [HideInInspector] public List<GameObject> allBullets = new List<GameObject>();
    private ManagerPool managerPool = new ManagerPool();

    private void Awake()
    {
        managerPool.AddPool(PoolType.Bullet);
    }

    private void Start()
    {
        StartCoroutine(CreateBullet(0.1f));
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))// && isRecharge)
        {
            Shot();
        }
    }

    private void Shot()
    {
        isRecharge = false;

        Transform target = targetManager.lastTarget;
        targetManager.NextTarget();

        Bullet thisBullet = allBullets[allBullets.Count - 1].GetComponent<Bullet>();

        thisBullet.Initialization(target);
        //thisBullet.target = target;
        //thisBullet.isInit = true;

        StartCoroutine(CreateBullet(0.5f));
    }

    IEnumerator CreateBullet(float timer)
    {
        yield return new WaitForSeconds(timer);
        allBullets.Add(managerPool.Spawn(PoolType.Bullet, bullet, startPositionBullet.position, Quaternion.identity));
        isRecharge = true;
    }
}
