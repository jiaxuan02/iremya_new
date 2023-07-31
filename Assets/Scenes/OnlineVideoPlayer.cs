using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class OnlineVideoPlayer : MonoBehaviour
{
    public string videoURL = "https://waterruler2.github.io/videos/Airlock_Video_Edited_8.0.mp4";
    public RawImage videoDisplay; // Reference to the RawImage component

    private VideoPlayer videoPlayer;
    private AudioSource audioSource;
    private bool isVideoLoaded = false;

    void Start()
    {
        videoPlayer = gameObject.AddComponent<VideoPlayer>();
        audioSource = gameObject.AddComponent<AudioSource>();

        StartCoroutine(PrepareVideo());
    }

    IEnumerator PrepareVideo()
    {
        videoPlayer.source = VideoSource.Url;
        videoPlayer.url = videoURL;

        // Wait until the video is prepared
        videoPlayer.Prepare();

        while (!videoPlayer.isPrepared)
        {
            yield return null;
        }

        // Video is prepared, set it as the target texture of the RawImage component
        if (videoDisplay != null)
        {
            videoDisplay.texture = videoPlayer.texture;
        }
        else
        {
            Debug.LogError("RawImage component is not assigned to the OnlineVideoPlayer script.");
        }

        // Enable audio output from the video
        videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
        videoPlayer.EnableAudioTrack(0, true);
        videoPlayer.SetTargetAudioSource(0, audioSource);

        // Set the video to play on awake
        videoPlayer.playOnAwake = false;

        isVideoLoaded = true;
    }

    public void PlayVideo()
    {
        if (isVideoLoaded)
        {
            // Play the video
            videoPlayer.Play();
        }
    }

    public void StopVideo()
    {
        if (isVideoLoaded)
        {
            // Stop the video
            videoPlayer.Stop();
        }
    }
}