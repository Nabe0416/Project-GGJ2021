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

    IEnumerator GlobalEvent(List<Card> requiredCards, GlobalEventTypes getp)
    {
        GetEventText();
        ShowEventText();
        BlockLockSetTo(true);

        if(CardManager.cm.GetCardCache() != null)
        {
            if(requiredCards.Contains(CardManager.cm.GetCardCache()))
            {
                //CardApproved();
            }
            else
            {
                //CardNotApproved();
            }
        }
        else
        {
            //NoCardCacheProvided();
        }
        yield return null;
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
