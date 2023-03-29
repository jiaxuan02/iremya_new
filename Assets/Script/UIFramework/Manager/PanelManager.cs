using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : Singleton<PanelManager>
{
    //Hold all of the instances
    private List<PanelInstanceModel> _listInstances = new List<PanelInstanceModel>();

    //Pool of panels
    private ObjectPool _objectPool;

    private void Start()
    {
        
        //Cache the object pool
        _objectPool = ObjectPool.Instance;
        ShowPanel("Login");
        ShowPanel("MainMenu");
    }

    public void ShowPanel(string panelID, PanelShowBehaviour behaviour = PanelShowBehaviour.KEEP_PREVIOUS)
    {
        GameObject panelInstance = _objectPool.GetObjectFromPool(panelID);

        if (panelInstance != null)
        {
            if (behaviour == PanelShowBehaviour.HIDE_PREVIOUS && GetAmountPanelsInQueue() > 0)
            {
                var lastPanel = GetLastPanel();
                if (lastPanel != null)
                {
                    lastPanel.PanelInstance.SetActive(false);
                }
            }
            //Add this new panel to the queue
            _listInstances.Add(new PanelInstanceModel
            {
                PanelID = panelID,
                PanelInstance = panelInstance
            });
        }
        else
        {
            Debug.LogWarning($"Trying to use panelID = {panelID} but it is not found in PanelModel");
        }    
    }

    public void HideLastPanel()
    {
        //Make sure have panel showing
        if (AnyPanelShowing())
        {
            // Get the last panel showing
            var lastPanel = _listInstances[_listInstances.Count - 1];

            _listInstances.Remove(lastPanel);

            // Destroy instance
            _objectPool.PoolObject(lastPanel.PanelInstance);

            if(GetAmountPanelsInQueue() > 0)
            {
                lastPanel = GetLastPanel();
                if (lastPanel != null && !lastPanel.PanelInstance.activeInHierarchy)
                {
                    lastPanel.PanelInstance.SetActive(true);
                }
            }
        }
    }

    PanelInstanceModel GetLastPanel()
    {
        return _listInstances[_listInstances.Count - 1];
    }

    // Returns true if any panel is showing
    public bool AnyPanelShowing()
    {
        return GetAmountPanelsInQueue() > 0;
    }
    //Returns how many panels have in queue
    public int GetAmountPanelsInQueue()
    {
        return _listInstances.Count;
    }
}
