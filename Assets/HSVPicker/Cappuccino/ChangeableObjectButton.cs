using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeableObjectButton : MonoBehaviour
{
    private ColorPickerPanel ColorPickerPanel;
    public ColorPicker picker;
    private string objName;
    public Color Color = Color.red;

    bool isOpen;

    public void Init(ColorPickerPanel _ColorPickerPanel,string _objName)
    {
        ColorPickerPanel = _ColorPickerPanel;
        objName = _objName;

        picker.onValueChanged.AddListener(color =>
        {
            // renderer.material.color = color;
            // Color = color;
          

            if (ColorPickerPanel.ObjectNameAndColor.ContainsKey(objName))
                ColorPickerPanel.ObjectNameAndColor[objName] = color;
            else
                ColorPickerPanel.ObjectNameAndColor.Add(objName, color);
        });

    }

    public void OnButtonTap()
    {
        if(!isOpen)
            picker.gameObject.SetActive(true);
        else
            picker.gameObject.SetActive(false);

        isOpen = !isOpen;


    }

  
}
