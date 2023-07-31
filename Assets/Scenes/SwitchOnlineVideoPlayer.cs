using UnityEngine;
using UnityEngine.Video;

public class SwitchOnlineVideoPlayer : MonoBehaviour
{
    public GameObject OnlineVideoPlayerObject1; // Assign this in the Inspector
    public GameObject OnlineVideoPlayerObject2; // Assign this in the Inspector
    public GameObject canvas1; // Assign this in the Inspector
    public GameObject canvas2; // Assign this in the Inspector
    public GameObject bg; // Assign this in the Inspector

    private void Start()
    {
        OnlineVideoPlayerObject1.SetActive(true);
        canvas1.SetActive(true);
        OnlineVideoPlayerObject2.SetActive(false);
        canvas2.SetActive(false);
        bg.SetActive(true);
    }

    public void OnButtonClick1()
    {
        // Hide the first video player
        OnlineVideoPlayerObject1.SetActive(false);
        canvas1.SetActive(false);

        // Play the second video player
        OnlineVideoPlayerObject2.SetActive(true);
        canvas2.SetActive(true);
    }
}
