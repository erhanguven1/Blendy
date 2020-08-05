using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Tools.Extentions;

public class NewSkinPopup : MonoBehaviour
{
    private MarketItemButton Item;

    public Image ItemImage;

    public void Setup(MarketItemButton Setup)
    {
        Item = Setup;

        ItemImage.sprite = Item.Details.Image;
    }

    public void OnUseButtonTap()
    {
        Item.OpenItemRandom();
        gameObject.SetActive(false);
    }
}
