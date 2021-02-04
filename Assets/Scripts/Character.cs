using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public Mesh collisioner;
    public SkinnedMeshRenderer skinMesh;
    public MeshCollider colisiom;

    private void Start()
    {
        skinMesh = GetComponent<SkinnedMeshRenderer>();
        collisioner = new Mesh();
        colisiom = GetComponent<MeshCollider>();
    }

    private void Update()
    {
        skinMesh.BakeMesh(collisioner);
        colisiom.sharedMesh = collisioner;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Bullet")
        {
            //Debug.LogError("Bullet");
        }
    }
}
