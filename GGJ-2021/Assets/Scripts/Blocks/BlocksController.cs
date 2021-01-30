using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlocksController : MonoBehaviour
{
    static public BlocksController bc;

    //已探索的格子数量
    private int DiscoveredBlocksCount = 0;
    //每周可探索的格子上限
    [SerializeField]
    private int DiscoverLimit = 1;
    //总探索格子计数
    private int DiscoveredBlocksTtl = 0;

    //总格子一边个数
    [SerializeField]
    private int amountOfOneSide = 3;
    [SerializeField]
    private GameObject block;
    [SerializeField]
    private GameObject blockParent;

    public List<GameObject> blocks = new List<GameObject>();

    [SerializeField]
    private int ratioOfCurrentSpot = 0;

    private void Start()
    {
        bc = this;
        InitializeBlocks();
        InitializeRatios();
        RefreshBlockLimitPerDay();
        RefreshBlockCountTtl();
        //Debug.Log(DiscoveredBlocksCount);
        //Debug.Log(DiscoveredBlocksTtl);
    }

    public void InitializeBlocks()
    {
        int side = 700 / amountOfOneSide;
        Debug.Log("每个格子长" + side);
        for (int i = 0; i < amountOfOneSide; i++)
        {
            for (int j = 0; j < amountOfOneSide; j++)
            {
                GameObject go = Instantiate(block, blockParent.transform);
                go.GetComponent<RectTransform>().sizeDelta = new Vector2(side, side);
                go.GetComponent<RectTransform>().anchoredPosition = new Vector2(-800 + (side * i), 300 - (side * j));
                blocks.Add(go);
            }
        }
    }

    //森林：河流：石头
    private List<Vector3> ratioOfDiffTerrains = new List<Vector3>();

    private void InitializeRatios()
    {
        ratioOfDiffTerrains.Add(new Vector3(6f, 3f, 1f));//森>河>石
        ratioOfDiffTerrains.Add(new Vector3(6f, 1f, 4f));//森>石>河
        ratioOfDiffTerrains.Add(new Vector3(4f, 4f, 2f));//森&河>石
        ratioOfDiffTerrains.Add(new Vector3(2f, 4f, 4f));//石&河>森
        ratioOfDiffTerrains.Add(new Vector3(3f, 1f, 6f));//石>森>河
        ratioOfDiffTerrains.Add(new Vector3(1f, 3f, 6f));//石>河>森
    }

    public BlockTerrains GetTerrainOfBlock()
    {
        float i = Random.Range(1, 11);
        Vector3 ratio = ratioOfDiffTerrains[ratioOfCurrentSpot];
        if(i >= ratio.x+ratio.y)
        {
            return BlockTerrains.bt_stone;
        }else if(i >= ratio.x)
        {
            return BlockTerrains.bt_river;
        }
        else
        {
            return BlockTerrains.bt_forest;
        }

    }


    private void GenerateEvent()
    {

    }

    public void DisableButton(Button btn)
    {
        btn.interactable = false;
    }

    public void RefreshBlockLimitPerDay()
    {
        DiscoveredBlocksCount = 0;
    }

    public void RefreshBlockCountTtl()
    {
        DiscoveredBlocksTtl = 0;
    }

    public int Getdbc()
    {
        return DiscoveredBlocksCount;
    }

    public void AdddbcTo(int i)
    {
        DiscoveredBlocksCount += i;
    }

    public int Getdl()
    {
        return DiscoverLimit;
    }

    public void AdddlTo(int i)
    {
        DiscoverLimit += i;
    }

    public int Getdbttl()
    {
        return DiscoveredBlocksTtl;
    }

    public void AdddbttlTo(int i)
    {
        DiscoveredBlocksTtl += i;
    }
}
