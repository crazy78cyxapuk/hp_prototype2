using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
    private List<Transform> allTargets = new List<Transform>();
    [HideInInspector] public Transform lastTarget;
    private int countTargets;

    [Header("Цвета для мишеней")]
    [SerializeField] private Material material_Red, material_Green;

    private void Start()
    {
        GetAlltargets();
    }

    private void GetAlltargets()
    {
        foreach(Transform target in transform)
        {
            allTargets.Add(target);
        }

        countTargets = allTargets.Count;

        NextTarget();
    }

    public void NextTarget()
    {
        if (countTargets > 0)
        {
            if (lastTarget != null)
            {
                lastTarget.GetComponent<MeshRenderer>().material = material_Red;
            }

            int random = Random.Range(0, allTargets.Count);

            allTargets[random].GetComponent<MeshRenderer>().material = material_Green;
            lastTarget = allTargets[random];

            allTargets.Remove(allTargets[random]);
            countTargets--;
        }
        else
        {
            lastTarget.GetComponent<MeshRenderer>().material = material_Red;
            Debug.Log("Прошли через все мишени!!!");
        }
    }
}
