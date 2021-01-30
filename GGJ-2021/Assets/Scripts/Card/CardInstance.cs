using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardInstance : MonoBehaviour
{
    public Card card;
    //此脚本所附着的Unity中的Image组件
    public Image img;

    public CardInstance ()
    {
        img.sprite = card.c_img;
    }
}
