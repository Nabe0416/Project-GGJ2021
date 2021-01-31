using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

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

    private BlockEvent be;

    [SerializeField]
    private Image secondImg;

    private void Start()
    {
        GetTerrain();
        secondImg.gameObject.SetActive(false);
    }
    private void GetTerrain()
    {
        terrain = bc.GetTerrainOfBlock();
        switch(bc.GetTerrainType())
        {
            case 0:
                switch (terrain)
                {
                    case BlockTerrains.bt_stone:
                        if (bc.GetBlockSprite(4))
                            this.gameObject.GetComponent<Image>().sprite = bc.GetBlockSprite(4);
                        else
                            this.gameObject.GetComponent<Image>().color = Color.yellow;
                        break;
                    case BlockTerrains.bt_forest:
                        if (bc.GetBlockSprite(1))
                            this.gameObject.GetComponent<Image>().sprite = bc.GetBlockSprite(1);
                        else
                            this.gameObject.GetComponent<Image>().color = Color.green;
                        break;
                    case BlockTerrains.bt_river:
                        if(bc.GetBlockSprite(2))
                            this.gameObject.GetComponent<Image>().sprite = bc.GetBlockSprite(2);
                        else
                            this.gameObject.GetComponent<Image>().color = Color.cyan;
                        break;
                }
                break;
            default:
                switch (terrain)
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
                be = BlockEvenetManager.bem.DoBlockEvent(this.terrain);
                bc.AdddbcTo(1);
                bc.AdddbttlTo(1);
                bc.DisableButton(btn);
                CardManager.cm.RenderHandCards();
                //Debug.Log("count =" + bc.Getdbc());
                //Debug.Log("ttl = " + bc.Getdbttl());
            }

            ShowEventAfterClick();

            if(CardManager.cm.GetHandList().Count <= 0)
            {
                print("你 死 了");
                SceneManager.LoadScene(0);
            }

            foreach (Card ca in CardManager.cm.GetHandList())
            {
                if(ca.c_type == CardTypes.ct_food)
                {
                    CardManager.cm.RemoveFromHandList(CardManager.cm.GetHandList().IndexOf(ca));
                    break;
                }
                if(CardManager.cm.GetHandList()[CardManager.cm.GetHandList().Count-1] == ca)
                {
                    print("你 死 了");
                    SceneManager.LoadScene(0);
                    break;
                }
            }

            //临时方法
            if (bc.Getdbc() == bc.Getdl())
            {
                GlobalVarController.gvc.PushDaysBy();
                bc.RefreshBlockLimitPerDay();
            }
        }

        CardManager.cm.RenderHandCards();
    }

    private void ShowEventAfterClick()
    {
        secondImg.gameObject.SetActive(true);

        print("目标格是" + terrain + "，触发的事件是" + be.be_type);
        switch (be.be_type)
        {
            case BlockEventTypes.bet_food:
                if(terrain != BlockTerrains.bt_forest)
                {
                    secondImg.sprite = bc.GetBlockEventSprite(2);
                }
                else
                {
                    secondImg.sprite = bc.GetBlockEventSprite(3);
                }
                break;
            case BlockEventTypes.bet_misc:
                if(CardManager.cm.GetHandList()[CardManager.cm.GetHandList().Count-1].c_name == "Sharp Stone")
                {
                    secondImg.sprite = bc.GetBlockEventSprite(1);
                }
                else
                {
                    secondImg.sprite = bc.GetBlockEventSprite(0);
                }
                break;
            case BlockEventTypes.bet_enemy:
                secondImg.sprite = bc.GetBlockEventSprite(6);
                break;
            case BlockEventTypes.bet_other:
                //暂时固定显示望远镜
                secondImg.sprite = bc.GetBlockEventSprite(5);
                break;
        }
    }
}
