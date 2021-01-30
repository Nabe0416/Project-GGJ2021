using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BlockEventTypes
{
    bet_food,
    bet_misc,
    bet_enemy,
    bet_other
}

public class BlockEvent 
{
    public BlockEventTypes be_type;
}

public class BlockEvent_Food : BlockEvent
{
    public int bef_amount;
    public BlockEvent_Food(BlockTerrains bt)
    {
        be_type = BlockEventTypes.bet_food;
        int rand;
        switch (bt)
        {
            case BlockTerrains.bt_forest:
                rand = Random.Range(0, 7);
                if (rand >= 6)
                {
                    bef_amount = 1;
                }
                else if(rand >= 2)
                {
                    bef_amount = 2;
                }
                else
                {
                    bef_amount = 3;
                }
                break;
            case BlockTerrains.bt_river:
                rand = Random.Range(0, 5);
                if (rand >= 3)
                {
                    bef_amount = 1;
                }
                else if (rand >= 1)
                {
                    bef_amount = 2;
                }
                else
                {
                    bef_amount = 3;
                }
                break;
            case BlockTerrains.bt_stone:
                rand = Random.Range(0, 1);
                if (rand >= 1)
                {
                    bef_amount = 2;
                }
                else
                {
                    bef_amount = 1;
                }
                break;
        }
    }
}

public class BlockEvent_Misc : BlockEvent
{
    public BlockEvent_Misc()
    {
        be_type = BlockEventTypes.bet_misc;
    }
}

public enum BE_EnemyTypes
{
    beet_small_carnivores,
    beet_large_carnivores,
    beet_small_herbivores,
    beet_large_herbivores
}
public class BlockEvent_Enemy : BlockEvent
{
    public BE_EnemyTypes bee_enemy;
    public int bee_enemyAtk;
    public BlockEvent_Enemy()
    {
        int rand = Random.Range(0, 1);
        if(rand >= 1)
        {
            bee_enemy = BE_EnemyTypes.beet_small_herbivores;
            bee_enemyAtk = 1;
        }
        else
        {
            bee_enemy = BE_EnemyTypes.beet_small_carnivores;
            bee_enemyAtk = 2;
        }
    }
}

public enum BE_OtherEvents
{
    beoe_discover_food,
    beoe_discover_misc,
    beoe_invest,
    beoe_cub
}
public class BlockEvent_Other : BlockEvent
{
    public BE_OtherEvents beo_event;
    public BlockEvent_Other()
    {
        int rand = Random.Range(0, 3);
        if(rand >= 2)
        {
            int rand2 = Random.Range(0, 1);
            if(rand2 >= 1)
            {
                beo_event = BE_OtherEvents.beoe_discover_food;
            }
            else
            {
                beo_event = BE_OtherEvents.beoe_discover_misc;
            }
        }else if(rand >= 1)
        {
            beo_event = BE_OtherEvents.beoe_discover_misc;
        }
        else
        {
            beo_event = BE_OtherEvents.beoe_cub;
        }
    }
}
