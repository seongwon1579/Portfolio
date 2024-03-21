using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : Singleton<MonsterManager>
{
    [SerializeField]
    private SpawnWolfController spawnWolfController;
    public Transform targetTransform;
    public int spawnTime = 10;

    private void Start()
    {
        StartCoroutine(SpawnWolfCo());
    }

    // 새로이 인스턴스된 몬스터가 플레이어의 위치를 파악하게 할 수 있도록 한다 
    public void SearchTargetPos(Transform transform)
    {
        targetTransform = transform;
    }

    // 몬스터를 일정한 간격을 두고 소환한다 
    IEnumerator SpawnWolfCo()
    {
        while (targetTransform != null)
        {
            yield return new WaitForSeconds(20f);
            spawnWolfController.SpawnWolf();
        }
    }
}
