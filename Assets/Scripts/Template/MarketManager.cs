using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Tools.Extentions;
using System.Linq;



public class MarketManager : MonoBehaviour
{

    public List<MarketItemBase> SkinTypes;
    public List<MarketItemBase> HoverTypes;
    public MarketItemButton MarketItemButtonPrefab;

    public RectTransform skinParent, hoverParent,trialParent;
    public RectTransform skinGrid, hoverGrid, trailGrid;
    public Button skinRandom, hoverRandom, trialRandom ,leftSkin,rightSkin,leftHover,rightHover,leftTrial,rightTrial;

    public GameObject skinClose, hoverClose, trailClose;

    private List<MarketItemButton> skinButtons = new List<MarketItemButton>();
    private List<MarketItemButton> hoverButtons = new List<MarketItemButton>();

    public int randomUnlockCurreny = 800;

    private int positionIndex;

    public NewSkinPopup NewSkinPopup;

   
    private void Start()
    {
        
        foreach (var skin in SkinTypes.OrderByDescending(o=>o.IsUnlock).ToList())
        {
          
            var button = Instantiate(MarketItemButtonPrefab);
            button.transform.SetParent(skinGrid, false);
            button.Init(skin);
            skinButtons.Add(button);
            
        }

        foreach (var hover in HoverTypes.OrderByDescending(o => o.IsUnlock).ToList())
        {
           
            var button = Instantiate(MarketItemButtonPrefab);
            button.transform.SetParent(hoverGrid, false);
            button.Init(hover);
            hoverButtons.Add(button);
        }

       

        OnSkinTap();
      //  DataManager.Instance.OnSkinChange += ReloadItems;
      //  DataManager.Instance.OnHoverChange += ReloadItems;

        

    }
    private void OnDestroy()
    {
       // DataManager.Instance.OnSkinChange -= ReloadItems;
       // DataManager.Instance.OnHoverChange -= ReloadItems;
    }

    private void ReloadItems()
    {

        var currency = DataManager.Currency;
        if (currency >= randomUnlockCurreny)
        {
            skinRandom.interactable = true;
            hoverRandom.interactable = true;
            trialRandom.interactable = true; 
        }
        else
        {
            skinRandom.interactable = false;
            hoverRandom.interactable = false;
            trialRandom.interactable = false;
        }


        if (CheckListComplete(SkinTypes))
            skinRandom.interactable = false;

        if (CheckListComplete(HoverTypes))
            hoverRandom.interactable = false;

      

        foreach (var skin in SkinTypes.OrderByDescending(o => o.IsUnlock).ToList())
        {
           

            skin.ItemButton.transform.parent = null;
            skin.ItemButton.transform.SetParent(skinGrid, false);
            skin.ItemButton.gameObject.transform.localScale = Vector3.one;
           

        }

        foreach (var hover in HoverTypes.OrderByDescending(o => o.IsUnlock).ToList())
        {
           hover.ItemButton.transform.parent = null;
            hover.ItemButton.transform.SetParent(hoverGrid, false);
            hover.ItemButton.gameObject.transform.localScale = Vector3.one;

        }

       
    }

  

    public void OnSkinTap()
    {
        positionIndex = 0;
       
        skinParent.gameObject.SetActive(true);
        hoverParent.gameObject.SetActive(false);
        trialParent.gameObject.SetActive(false);

        skinRandom.gameObject.SetActive(true);
        hoverRandom.gameObject.SetActive(false);
        trialRandom.gameObject.SetActive(false);

        leftSkin.gameObject.SetActive(true);
        rightSkin.gameObject.SetActive(true);
        leftHover.gameObject.SetActive(false);
        rightHover.gameObject.SetActive(false);
        leftTrial.gameObject.SetActive(false);
        rightTrial.gameObject.SetActive(false);

        skinClose.SetActive(false);
        hoverClose.SetActive(true);
        trailClose.SetActive(true);


        var currency = DataManager.Currency;
        if (currency >= randomUnlockCurreny)
            skinRandom.interactable = true;
        else
            skinRandom.interactable = false;

        if(CheckListComplete(SkinTypes))
            skinRandom.interactable = false;
    }

   

    public void OnHoverTap()
    {
        positionIndex = 0;

        skinParent.gameObject.SetActive(false);
        hoverParent.gameObject.SetActive(true);
        trialParent.gameObject.SetActive(false);

        skinRandom.gameObject.SetActive(false);
        hoverRandom.gameObject.SetActive(true);
        trialRandom.gameObject.SetActive(false);

        leftSkin.gameObject.SetActive(false);
        rightSkin.gameObject.SetActive(false);
        leftHover.gameObject.SetActive(true);
        rightHover.gameObject.SetActive(true);
        leftTrial.gameObject.SetActive(false);
        rightTrial.gameObject.SetActive(false);

        skinClose.SetActive(true);
        hoverClose.SetActive(false);
        trailClose.SetActive(true);

        var currency = DataManager.Currency;
        if (currency >= randomUnlockCurreny)
            hoverRandom.interactable = true;
        else
            hoverRandom.interactable = false;

        if(CheckListComplete(HoverTypes))
            hoverRandom.interactable = false;


    }

   
   
    public void OnRandomButtonTap(string randomButtonType)
    {
        DataManager.Currency -= randomUnlockCurreny;
       
        switch (randomButtonType)
        {
            case "Skin":
               
                var unlockSkins = skinButtons.FindAll(o => !o.Details.IsUnlock); 
               
                if(unlockSkins.Count !=0)
                {
                    var selectedButton = unlockSkins.RandomItem();
                    // selectedButton.OpenItemRandom();
                    NewSkinPopup.Setup(selectedButton);
                    NewSkinPopup.gameObject.SetActive(true);
                }
             
                break;
       
            case "Hover":
               
                var unlockHovers = hoverButtons.FindAll(o => !o.Details.IsUnlock);
               
                if (unlockHovers.Count != 0)
                {
                    var selectedButton = unlockHovers.RandomItem();
                   // selectedButton.OpenItemRandom();
                    NewSkinPopup.Setup(selectedButton);
                    NewSkinPopup.gameObject.SetActive(true);
                }

                break;
       
           
           
        }
    }

    public void OnLeftArrowTap(string type)
    {
        positionIndex--;
        if (positionIndex < 0)
            positionIndex = 0;
        switch (type)
        {
            case "Skin":


                var newPosSkin = new Vector2(positionIndex * -164f, skinGrid.localPosition.y);
                skinGrid.localPosition = newPosSkin;


                break;

            case "Hover":

                var newPosHover = new Vector2(positionIndex * -164f, hoverGrid.localPosition.y);
                hoverGrid.localPosition = newPosHover;

                break;

          

        }
    }

    public void OnRightArrowTap(string type)
    {
        positionIndex++;
        
        switch (type)
        {
            case "Skin":

                if (positionIndex > skinButtons.Count - 4)
                    positionIndex = skinButtons.Count - 4;

               

                var newPosSkin = new Vector2(positionIndex * -164f, skinGrid.localPosition.y);
                skinGrid.localPosition = newPosSkin;


                break;

            case "Hover":

                if (positionIndex > hoverButtons.Count - 4)
                    positionIndex = hoverButtons.Count - 4;

                var newPosHover = new Vector2(positionIndex * -164f, hoverGrid.localPosition.y);
                hoverGrid.localPosition = newPosHover;

                break;

          
        }
    }

    private bool CheckListComplete(List<MarketItemBase> list)
    {
        foreach (var item in list)
        {
            if (!item.IsUnlock)
                return false;
        }

        return true;
    }

}
