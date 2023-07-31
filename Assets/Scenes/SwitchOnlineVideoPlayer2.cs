using UnityEngine;
using UnityEngine.Video;

public class SwitchOnlineVideoPlayer2 : MonoBehaviour
{
    public GameObject OnlineVideoPlayerObject1; // Assign this in the Inspector
    public GameObject canvas1; // Assign this in the Inspector
    public GameObject bg; // Assign this in the Inspector

    private void Start()
    {
        
    }

    public void OnButtonClick2()
    {
        // Hide the first video player
        OnlineVideoPlayerObject1.SetActive(false);
        canvas1.SetActive(false);
        bg.SetActive(false);
    }
}
