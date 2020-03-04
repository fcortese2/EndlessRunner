using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour
{
    public bool bossMode = false;  // make private after debug !!!!

    [Space]
    [Header("Boss Setup")]
    public int TriggerScore;

    public bool BossMode { get { return bossMode; } set { bossMode = value; } }

    public void ActivateBossMode()
    {
        bossMode = true;
        //...
    }

    private void ExitBossMode()
    {
        bossMode = false;
    }
}
