using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using System;

public class ProjectablePooler : MonoBehaviour, IPoolable<ProjectableSetting,IMemoryPool>, IDisposable
{
    protected IMemoryPool pool;
    protected ProjectableSetting setting;

    private Transform parent; 

    public void Dispose()
    {
        pool.Despawn(this);
    }

    public void OnDespawned()
    {
        pool = null;

        transform.parent = parent;            
        gameObject.SetActive(false);
    }

    public void OnSpawned(ProjectableSetting setting, IMemoryPool pool)
    {
        this.pool = pool;
        this.setting = setting;

        parent = transform.root;
        transform.SetParent(null);

        gameObject.SetActive(true);
    }
}

[Serializable]
public class ProjectableSetting
{
    public PlayerController PlayerController { get; set; }
    public Vector3 StartPoint { get; set; }
    public float Speed { get; set; }
    public float RoateSpeed { get; set; }


}

