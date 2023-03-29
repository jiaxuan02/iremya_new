using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoCenterItem : MonoBehaviour
{
    public Button _ItemBtn;

    public Image _itemImage;

    public int _ItemIndex;


    public void InitAutoCenterItem()
    {
        _itemImage = GetComponent<Image>();
        _ItemBtn = GetComponent<Button>();
    }

}
