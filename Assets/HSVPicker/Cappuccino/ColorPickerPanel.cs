using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorPickerPanel : MonoBehaviour
{
    public GameObject Picker;
    [SerializeField]
    private Transform panelTransform;
    [SerializeField]
    private ChangeableObjectButton buttonPrefab;
    public Dictionary<string, Color> ObjectNameAndColor;
    public GameObject GameMenu;


    // Start is called before the first frame update
    public void Init(List<string> objectNames)
    {
        ObjectNameAndColor = new Dictionary<string, Color>();

        foreach (var objName in objectNames)
        {
            var button = Instantiate(buttonPrefab, panelTransform);
            button.GetComponentInChildren<Text>().text = objName;
            button.Init(this, objName);
        }

      
    }

    public void OnSaveButtonTap()
    {
       
        foreach (var item in ObjectNameAndColor)
        {
            Debug.Log(item.Key + "  " + item.Value);
        }

        //GameManager.Instance.SelectedObjectColors = ObjectNameAndColor;
      

        GameMenu.SetActive(true);
        gameObject.SetActive(false);
    }

   

}
