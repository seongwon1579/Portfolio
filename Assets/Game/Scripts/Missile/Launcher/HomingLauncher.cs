using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class HomingLauncher : MonoBehaviour
{
    private HomingProjecter.HomingProjecterFactroy homingProjecter;

    [Inject]
    private void Consturct(HomingProjecter.HomingProjecterFactroy homingProjecter)
    {
        this.homingProjecter = homingProjecter;
    }

}
