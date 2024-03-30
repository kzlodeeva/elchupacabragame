using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class AidKitSpawner : MonoBehaviour
{
    public aidKit aidKitPrefab;
    public float delayMin = 3;
    public float delayMax = 9;

    public List<Transform> spawnerPoints;

    private aidKit _aidkit;
    
    private void Start()
    {
        spawnerPoints = new List<Transform>(transform.GetComponentsInChildren<Transform>());
    }
    private void Update()
    {
        if (_aidkit != null) return;
        if (IsInvoking()) return;

        Invoke("CreateAidKit", Random.Range(delayMin, delayMax));
    }
    private void CreateAidKit()
    {
        _aidkit = Instantiate(aidKitPrefab);
        _aidkit.transform.position = spawnerPoints[Random.Range(0, spawnerPoints.Count)].position;
    }
}
