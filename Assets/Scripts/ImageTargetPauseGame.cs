using UnityEngine;
using System.Collections;
using Vuforia;

public class ImageTargetPauseGame : MonoBehaviour, ITrackableEventHandler
{
    private TrackableBehaviour mTrackableBehaviour;
    public Player player;

    void Start()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
    }

    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus,TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            // Do something when target is found
            if (player.gameHasStarted)
            {
                player.stopPause();
            }
            else
            {
                player.isReadyToStart = true;
            }
        }
        else
        {
            // Do something when target is lost
            if (player.gameHasStarted)
            {
                player.startPause();
            }
            else if (!player.gameHasStarted)
            {
                player.isReadyToStart = false;
            }
        }
    }
}