using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum CardTypes
{
    ct_food,
    ct_equi,
    ct_misc,
    ct_clue
}

public enum FoodTypes
{
    ft_fruit,
    ft_fish,
    ft_meat
}

[System.Serializable]
public class Card
{
    public Sprite c_img;
    public CardTypes c_type;
    public string c_desc;
}

public class FoodCard : Card
{
    public FoodTypes fc_types;
    public FoodCard()
    {
        c_type = CardTypes.ct_food;
        c_desc = "一人一天份的食物。";
    }
}

public class EquipmentCard : Card
{
    public int ec_atk;
    public int ec_durability;
    public EquipmentCard()
    {
        c_type = CardTypes.ct_equi;
    }
}

public class MiscCard : Card
{
    public int mc_atk;
    public MiscCard()
    {
        c_type = CardTypes.ct_misc;
    }
}

public class ClueCard : Card
{
    public ClueCard()
    {
        c_type = CardTypes.ct_clue;
    }
}
