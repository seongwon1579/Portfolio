using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempController : MonoBehaviour
{
    public static TempController tempController;

    public GameObject curPlayer;

    [SerializeField]
    private MissileController missileController;

    [SerializeField]
    private Transform spawnPoint;

    private void Awake()
    {
        tempController = this;
    }

    private void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        Character player = new Character();
        player.MaxHp = 1;
        player.Hp = player.MaxHp;
        player.MoveSpeed = 2;
        player.Dmg = 3;

        curPlayer = Instantiate(curPlayer, spawnPoint.position, curPlayer.transform.rotation);
        curPlayer.GetComponent<PlayerController>().Set(player);

        missileController.Launch();
        
    }
}
