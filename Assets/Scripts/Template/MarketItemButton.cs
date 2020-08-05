using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MarketItemButton : MonoBehaviour
{
    [SerializeField]
    private Image marketImage,frameImage;
    [SerializeField]
    private GameObject lockImage;
    public MarketItemBase Details;
    

    public void Init(MarketItemBase Setup)
    {
        Details = Setup;

        SetFrameColor();

        Details.ItemButton = this;
      // DataManager.Instance.OnSkinChange += SetFrameColor;
      // DataManager.Instance.OnHoverChange += SetFrameColor;

        marketImage.sprite = Details.Image;
        if(Details.IsUnlock || Details.IsDefault)
        {
            lockImage.SetActive(false);
           
          
        }
        else
        {
            lockImage.SetActive(true);
           
        }
    }
    private void OnDestroy()
    {
       // DataManager.Instance.OnSkinChange -= SetFrameColor;
       // DataManager.Instance.OnHoverChange -= SetFrameColor;
    }

    private void SetFrameColor()
    {
      
        switch (Details.Type)
        {
          //  case MarketItemType.Skin:
          //      if(Details.Id == DataManager.Instance.SkinId)
          //      {
          //          frameImage.color = Color.yellow;
          //      }else
          //          frameImage.color = Color.white;
          //      break;
          //
          //  case MarketItemType.Hover:
          //      if (Details.Id == DataManager.Instance.HoverId)
          //      {
          //          frameImage.color = Color.yellow;
          //      }
          //      else
          //          frameImage.color = Color.white;
          //
          //      break;
          
        }
    }

    public void OpenItemRandom()
    {
      // Details.IsUnlock = true;
      // lockImage.SetActive(false);
      //
      // switch (Details.Type)
      // {
      //     case MarketItemType.Skin:
      //         DataManager.Instance.SkinId = Details.Id;
      //         break;
      //
      //     case MarketItemType.Hover:
      //        DataManager.Instance.HoverId =Details.Id;
      //         break;
      //    
      // }

    }

    public void UseItem()
    {
        if(Details.IsUnlock || Details.IsDefault)
        {
          //  switch (Details.Type)
          //  {
          //      case MarketItemType.Skin:
          //           DataManager.Instance.SkinId = Details.Id;
          //         
          //          break;
          //
          //      case MarketItemType.Hover:
          //          DataManager.Instance.HoverId = Details.Id;
          //          break;
          //     
          //  }
        }
        
    }


}
