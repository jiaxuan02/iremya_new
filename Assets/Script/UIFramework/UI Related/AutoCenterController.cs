using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoCenterController : MonoBehaviour
{
    public List<AutoCenterItem> _autoCenterItems = new List<AutoCenterItem>();

    public AutoCenterView _autoCenterView;

    public void Start()
    {
        InitController();
    }

    public void InitController()
    {
        _autoCenterView = GetComponent<AutoCenterView>();

        Transform _container = _autoCenterView._container;
        for (int i = 0; i < _container.childCount; i++)
        {
            AutoCenterItem temp = _container.GetChild(i).GetComponent<AutoCenterItem>();
            _autoCenterItems.Add(temp);
            temp.InitAutoCenterItem();
            temp._ItemBtn.onClick.AddListener(() =>
            {
                OnItemClick(temp._ItemIndex);
            }
            );
        }
    }
    public void OnItemClick(int _index)
    {
        _autoCenterView.SetCenterChild(_index);
    }
}
