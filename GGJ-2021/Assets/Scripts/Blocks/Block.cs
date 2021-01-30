using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BlockTerrains
{
    bt_forest,
    bt_river,
    bt_stone
}

public class Block : MonoBehaviour
{
    private BlocksController bc = BlocksController.bc;
    private BlockTerrains terrain;

    private void Start()
    {
        GetTerrain();
    }
    private void GetTerrain()
    {
        terrain = bc.GetTerrainOfBlock();
        switch(terrain)
        {
            case BlockTerrains.bt_stone:
                this.gameObject.GetComponent<Image>().color = Color.yellow;
                break;
            case BlockTerrains.bt_forest:
                this.gameObject.GetComponent<Image>().color = Color.green;
                break;
            case BlockTerrains.bt_river:
                this.gameObject.GetComponent<Image>().color = Color.cyan;
                break;
        }

    }
    public void ClickOnABlock(Button btn)
    {
        if (btn.enabled == true)
        {
            if (bc.Getdbc() < bc.Getdl())
            {
                //Debug.Log("按钮" + btn.name + "被按下，已禁用按钮");
                BlockEvenetManager.bem.DoBlockEvent(this.terrain);
                bc.AdddbcTo(1);
                bc.AdddbttlTo(1);
                bc.DisableButton(btn);
                //Debug.Log("count =" + bc.Getdbc());
                //Debug.Log("ttl = " + bc.Getdbttl());
                print("——————");
            }

            //临时方法
            if (bc.Getdbc() == bc.Getdl())
            {
                GlobalVarController.gvc.PushDaysBy();
                bc.RefreshBlockLimitPerDay();
            }
        }
    }
}
