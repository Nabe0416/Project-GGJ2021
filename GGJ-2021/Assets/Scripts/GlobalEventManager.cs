using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GlobalEventTypes
{
    getp_enemy,
    getp_discover,
    getp_invest,
    getp_cub
}


public class GlobalEventManager : MonoBehaviour
{
    string EventText;
    [SerializeField]
    GameObject blockLock;

    public static GlobalEventManager gem;

    private void Start()
    {
        gem = this;
    }

    public void GlobalEvent(List<Card> requiredCards, BlockEvent be)
    {
        GetEventText();
        ShowEventText();
        BlockLockSetTo(true);
        

    }

    private void BlockLockSetTo(bool b)
    {
        blockLock.SetActive(b);
    }

    private void ShowEventText()
    {

    }

    void GetEventText()
    {
        //待实现
    }
}
