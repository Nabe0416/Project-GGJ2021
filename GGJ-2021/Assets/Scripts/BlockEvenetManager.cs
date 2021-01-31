using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class BlockEvenetManager : MonoBehaviour
{
    private BlockEvent currentBE;

    static public BlockEvenetManager bem;
        
    private BlockEvent_Food cbe;

    private void Start()
    {
        bem = this;
    }
    public BlockEvent DoBlockEvent(BlockTerrains bt)
    {
        int rand = Random.Range(0, 100);
        print("当前地形是" + bt);
        switch (bt)
        {
            case BlockTerrains.bt_forest:
                if(rand >= 90)
                {
                    currentBE = new  BlockEvent_Other();
                }else if(rand >= 80)
                {
                    currentBE = new  BlockEvent_Enemy();
                }else if(rand >= 70)
                {
                    currentBE = new  BlockEvent_Misc();
                }
                else
                {
                    currentBE = new  BlockEvent_Food(bt);
                }
                break;
            case BlockTerrains.bt_river:
                if (rand >= 85)
                {
                    currentBE = new  BlockEvent_Other();
                }
                else if (rand >= 70)
                {
                    currentBE = new  BlockEvent_Enemy();
                }
                else if (rand >= 50)
                {
                    currentBE = new  BlockEvent_Misc();
                }
                else
                {
                    currentBE = new  BlockEvent_Food(bt);
                }
                break;
            case BlockTerrains.bt_stone:
                if (rand >= 80)
                {
                    currentBE = new  BlockEvent_Other();
                }
                else if (rand >= 60)
                {
                    currentBE = new  BlockEvent_Enemy();
                }
                else if (rand >= 30)
                {
                    currentBE = new  BlockEvent_Misc();
                }
                else
                {
                    currentBE = new  BlockEvent_Food(bt);
                }
                break;
            default:
                currentBE = new  BlockEvent_Misc();
                break;
        }

        print("当前事件是" + currentBE.be_type);

        if(currentBE.be_type == BlockEventTypes.bet_food)
        {
            cbe =  BlockEvent.ConvertToBEF(currentBE);
            print("获得" + cbe.bef_amount + "个食物");
            switch (bt)
            {
                case BlockTerrains.bt_forest:
                    for(int i = 0; i < cbe.bef_amount; i++)
                    {
                        CardManager.cm.AddToHandlist(CardManager.cm.GetCardFromList(1));
                    }
                    break;
                case BlockTerrains.bt_river:
                    for (int i = 0; i < cbe.bef_amount; i++)
                    {
                        CardManager.cm.AddToHandlist(CardManager.cm.GetCardFromList(0));
                    }
                    break;
                case BlockTerrains.bt_stone:
                    for (int i = 0; i < cbe.bef_amount; i++)
                    {
                        CardManager.cm.AddToHandlist(CardManager.cm.GetCardFromList(2));
                    }
                    break;
            }
        }else if(currentBE.be_type == BlockEventTypes.bet_misc)
        {
            int rand2 = Random.Range(0, 5);
            switch(rand2)
            {
                case 0:
                    CardManager.cm.AddToHandlist(CardManager.cm.GetCardFromList(3));
                    break;
                case 1:
                    CardManager.cm.AddToHandlist(CardManager.cm.GetCardFromList(4));
                    break;
                case 2:
                    CardManager.cm.AddToHandlist(CardManager.cm.GetCardFromList(5));
                    break;
                case 3:
                    CardManager.cm.AddToHandlist(CardManager.cm.GetCardFromList(6));
                    break;
                case 4:
                    CardManager.cm.AddToHandlist(CardManager.cm.GetCardFromList(7));
                    break;
            }
            print("获得了杂物");
        }else if(currentBE.be_type == BlockEventTypes.bet_enemy)
        {
            var clist = CardManager.cm.GetCardByType(CardTypes.ct_equi);
            //GlobalEventManager.gem.GlobalEvent(clist, currentBE);
            print("触发了战斗");
        }
        else
        {
            //没写完
            print("触发了其他事件");
        }
        return currentBE;
    }
}
