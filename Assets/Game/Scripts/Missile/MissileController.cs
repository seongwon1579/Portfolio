using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Missile;
using System;
using Cysharp.Threading.Tasks;

[System.Serializable]
public class MissilePool
{
    public IProjectable projectable;

    private Transform subParent;
    private Queue<GameObject> missilesQueue;

    public MissilePool(IProjectable projectable, Action<Transform> SetParent)
    {
        this.projectable = projectable;

        missilesQueue = new Queue<GameObject>();

        subParent = new GameObject(projectable.projectablePrefab.name + "_pool").transform;
        SetParent(subParent);

        PoolMissile(projectable.numberOfPrefabs);
    }

    private void PoolMissile(int numberOfPrefabs)
    {
        for (int i = 0; i < numberOfPrefabs; i++)
        {
            GameObject missile = UnityEngine.Object.Instantiate(projectable.projectablePrefab, subParent);
            Enqueue(missile);
        }
    }
    public void Enqueue(GameObject missile)
    {
        missile.SetActive(false);
        missilesQueue.Enqueue(missile);
        missile.transform.SetParent(subParent);
    }

    public void Dequeue(Vector3 pos, Quaternion rot)
    {
        if (missilesQueue.Count <= 0)
        {
            int number = (int)(projectable.numberOfPrefabs * 0.3f);
            PoolMissile(number > 0 ? number : 1);
        }
        GameObject missile = missilesQueue.Dequeue();
        missile.transform.position = pos;
        missile.transform.rotation = rot;
        missile.SetActive(true);
        Debug.Log(missile.gameObject.name + " Dequeue");
    }
}


public class MissileController : MonoBehaviour
{
    public static Dictionary<string, MissilePool> missilePoolDic;

    public static Action LaunchMissileAction;

    private Transform parent;

    private void Start()
    {
        SetMissile();
    }

    private void SetMissile()
    {
        IProjectable[] projectables = Resources.LoadAll<Projectable>("Missile");

        if (projectables.Length <= 0)
            return;

        parent = new GameObject("MisslePool").transform;

        missilePoolDic = new Dictionary<string, MissilePool>();

        foreach (IProjectable projectable in projectables)
        {
            MissilePool misslePool = new MissilePool(projectable, (Transform subParent) => { subParent.SetParent(parent); });
            missilePoolDic.Add(misslePool.projectable.projectablePrefab.name, misslePool);
        }
    }


    public void Launch()
    {
        LaunchMissileAction?.Invoke();
    }
}