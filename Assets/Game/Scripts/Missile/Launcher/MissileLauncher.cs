using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MissileLauncher : MonoBehaviour
{
    [SerializeField]
    private int homingCount, forwardCount;

    private HomingProjecter.HomingProjecterFactroy homingProjecter;
    private ForwardProjecter.ForwardProjecterFactory forwardProjecter;

    [Inject]
    public void Construct(
            HomingProjecter.HomingProjecterFactroy homingProjecter,
            ForwardProjecter.ForwardProjecterFactory forwardProjecter)
    {
        this.forwardProjecter = forwardProjecter;
        this.homingProjecter = homingProjecter;
    }

    private void Awake()
    {       
        SetPool();
    }

    private void SetPool()
    {
        //Homing
        List<HomingProjecter> homingList = new List<HomingProjecter>();
        for (int i = 0; i < homingCount; i++)      
            homingList.Add(homingProjecter.Create(null));
            
        for (int i = 0; i < homingCount; i++)
            homingList[i].Dispose();

        //Forward
        List<ForwardProjecter> forwardList = new List<ForwardProjecter>();
        for (int i = 0; i < forwardCount; i++)
            forwardList.Add(forwardProjecter.Create(null));

        for (int i = 0; i < forwardCount; i++)
            forwardList[i].Dispose();
    }
}

