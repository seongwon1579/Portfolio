using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    [SerializeField]
    Image barImage;

    public void ApplyRealtimeHp(float curHp, float maxHp)
    {
        barImage.fillAmount = Mathf.Lerp(0, 1, curHp / maxHp);
    }
}
