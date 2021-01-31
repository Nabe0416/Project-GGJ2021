using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class CardManager : MonoBehaviour
{
    static public CardManager cm;

    [SerializeField]
    private Sprite fc_fruit, fc_meat, fc_fish;
    [SerializeField]
    private List<Sprite> cardSprites = new List<Sprite>();
    [SerializeField]
    private List<Card> cardsList = new List<Card>();
    [SerializeField]
    private GameObject hand;//手牌父节点
    [SerializeField]
    private List<Card> handList = new List<Card>();//手牌列表
    [SerializeField]
    private List<GameObject> handInstanceList = new List<GameObject>();//手牌实例列表
    [SerializeField]
    private List<Card> unInstantiatedHand = new List<Card>();//待实例化手牌列表

    [SerializeField]
    private GameObject cardPrefab;

    [SerializeField]
    private CardInstance cardCache;

    private void Start()
    {
        cm = this;
        InitializeCardList();
        RenderHandCards();

        GiveFoodCardAtTheBeginning();
    }

    private void GiveFoodCardAtTheBeginning()
    {
        handList.Add(cardsList[1]);
        handList.Add(cardsList[1]);
        RenderHandCards();
    }

    public CardInstance GetCardCache()
    {
        return cardCache;
    }

    public void SetCardCache(CardInstance c)
    {
        if(cardCache != null)
        {
            DownCache(cardCache.gameObject);
        }
        cardCache = c;
        UpCache(c.gameObject);
    }

    private void UpCache(GameObject go)
    {
        go.transform.position += new Vector3(0, 30, 0);
    }

    private void DownCache(GameObject go)
    {
        go.transform.position -= new Vector3(0, 30, 0);
    }

    public void RenderHandCards()
    {
        /**
        foreach(Card cd in handList)
        {

            unInstantiatedHand.Add(cd);
            foreach(GameObject go in handInstanceList)
            {
                if(go.GetComponent<CardInstance>().card == cd)
                {
                    unInstantiatedHand.Remove(cd);
                    break;
                }
            }
        }
        int i = 0;
        foreach(Card cd in unInstantiatedHand)
        {
            var ci = Instantiate(cardPrefab, (Vector2)hand.transform.position + new Vector2(i*10, 0), Quaternion.identity, hand.transform);
            ci.GetComponent<CardInstance>().card = cd;
            i += 10;
        }

        unInstantiatedHand.Clear();**/
        int i = 0;
        for (int it = handInstanceList.Count - 1; it > -1; it--)
        {
            Destroy(handInstanceList[it]);
            handInstanceList.RemoveAt(it);
        }

        foreach(Card cd in handList)
        {
            var ci = Instantiate(cardPrefab, (Vector2)hand.transform.position + new Vector2(i * 10, 0), Quaternion.identity, hand.transform);
            handInstanceList.Add(ci);
            ci.GetComponent<CardInstance>().card = cd;
            i += 10;
        }
    }

    public void AddToHandlist(Card c)
    {
        handList.Add(c);
    }

    public List<Card> GetHandList()
    {
        return handList;
    }

    public void RemoveFromHandList(int i)
    {
        handList.RemoveAt(i);
    }

    private void InitializeCardList()
    {
        //添加食物卡
        cardsList.Add(GetFoodCard("Fish", FoodTypes.ft_fish));                                                                         //鱼，ID=0
        cardsList.Add(GetFoodCard("Fruit", FoodTypes.ft_fruit));                                                                        //水果，ID=1
        cardsList.Add(GetFoodCard("Meat", FoodTypes.ft_meat));                                                                      //木板，ID=2
        //添加装备卡：需要添加sprite，攻击力，耐久
        cardsList.Add(GetEquiCard("Stick", 0, 1, 1, "随处可见的木棒，简单而无力的防身手段。"));                       //木棍，ID=3
        cardsList.Add(GetEquiCard("Sharp Stone", 1, 1, 1, "随处可见的石片，简单而无力的防身手段。"));                       //石片，ID=4
        //添加杂物卡：需要添加sprite
        cardsList.Add(GetMiscCard("Tough Plant", 10, "某种坚韧的植物。"));                                                                 //坚韧的植物，ID=5
        cardsList.Add(GetMiscCard("Raw Hide", 11, "剥取自某种动物的生皮革。"));                                                    //皮革，ID=6
        cardsList.Add(GetMiscCard("Wooden Plank", 12, "不知是谁处理好的木板。"));                                                       //木板，ID=7
        //添加线索卡

    }

    public List<Card> GetCardByType(CardTypes ct)
    {
        List<Card> clist = new List<Card>();
        foreach(Card c in cardsList)
        {
            if(c.c_type == ct)
            {
                clist.Add(c);
            }
        }

        return clist;
    }

    public Card GetCardFromList(int i)
    {
        return cardsList[i];
    }

    public FoodCard GetFoodCard(string name, FoodTypes ft)
    {
        FoodCard fcd = new FoodCard();

        fcd.c_name = name;
        switch (ft)
        {
            case FoodTypes.ft_fruit:
                fcd.c_img = fc_fruit;
                break;
            case FoodTypes.ft_fish:
                fcd.c_img = fc_fish;
                break;
            case FoodTypes.ft_meat:
                fcd.c_img = fc_meat;
                break;
        }
        return fcd;
    }

    public EquipmentCard GetEquiCard(string name, int sprite_id, int atk, int dur, string desc)
    {
        EquipmentCard ecd = new EquipmentCard();
        ecd.c_name = name;
        ecd.c_img = cardSprites[sprite_id];
        ecd.c_desc = desc;
        ecd.ec_atk = atk;
        ecd.ec_durability = dur;
        return ecd;
    }

    public MiscCard GetMiscCard(string name, int sprite_id, string desc)
    {
        MiscCard mc = new MiscCard();
        mc.c_name = name;
        mc.c_img = cardSprites[sprite_id];
        mc.c_desc = desc;
        return mc;
    }
}
