using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private void Start()
    {
        cm = this;
        InitializeCardList();
        RenderHandCards();
    }

    private void RenderHandCards()
    {
        foreach(Card cd in handList)
        {

        }
    }

    public void AddToHandlist(Card c)
    {
        handList.Add(c);
    }

    private void InitializeCardList()
    {
        //添加食物卡
        cardsList.Add(GetFoodCard(FoodTypes.ft_fish));                                                                         //鱼，ID=0
        cardsList.Add(GetFoodCard(FoodTypes.ft_fruit));                                                                        //水果，ID=1
        cardsList.Add(GetFoodCard(FoodTypes.ft_meat));                                                                      //木板，ID=2
        //添加装备卡：需要添加sprite，攻击力，耐久
        cardsList.Add(GetEquiCard(0, 1, 5, "随处可见的木棒，简单而无力的防身手段。"));                       //木棍，ID=3
        cardsList.Add(GetEquiCard(1, 1, 5, "随处可见的石片，简单而无力的防身手段。"));                       //石片，ID=4
        //添加杂物卡：需要添加sprite
        cardsList.Add(GetMiscCard(10, "某种坚韧的植物。"));                                                                 //坚韧的植物，ID=5
        cardsList.Add(GetMiscCard(11, "剥取自某种动物的生皮革。"));                                                    //皮革，ID=6
        cardsList.Add(GetMiscCard(12, "不知是谁处理好的木板。"));                                                       //木板，ID=7
        //添加线索卡

    }

    public Card GetCardFromList(int i)
    {
        return cardsList[i];
    }

    public FoodCard GetFoodCard(FoodTypes ft)
    {
        FoodCard fcd = new FoodCard();
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

    public EquipmentCard GetEquiCard(int sprite_id, int atk, int dur, string desc)
    {
        EquipmentCard ecd = new EquipmentCard();
        ecd.c_img = cardSprites[sprite_id];
        ecd.c_desc = desc;
        ecd.ec_atk = atk;
        ecd.ec_durability = dur;
        return ecd;
    }

    public MiscCard GetMiscCard(int sprite_id, string desc)
    {
        MiscCard mc = new MiscCard();
        mc.c_img = cardSprites[sprite_id];
        mc.c_desc = desc;
        return mc;
    }
}
