using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPanelButton : MonoBehaviour
{
    //The id of the panel that want to show
    public string PanelID;

    public PanelShowBehaviour Behaviour;

    //Cached panels manager
    private PanelManager _panelManager;

    private void Start()
    {
        _panelManager = PanelManager.Instance;
    }

    public void DoShowPanel()
    {
        _panelManager.ShowPanel(PanelID, Behaviour);
    }

}
