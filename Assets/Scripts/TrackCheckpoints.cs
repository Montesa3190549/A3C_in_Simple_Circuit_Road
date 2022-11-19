using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackCheckpoints : MonoBehaviour
{
    public event EventHandler<CarCheckpointEventArgs> OnCarCorrectCheckpoint;
    public event EventHandler<CarCheckpointEventArgs> OnCarWrongCheckpoint;
    private List<CheckpointSingle> checkpointSingleList;
    private int nextCheckpointIndex;

    public class CarCheckpointEventArgs : EventArgs
    {
        public Transform carTransform;
    }

    private void Awake()
    {
        Transform checkpointsTransform = transform.Find("Checkpoints");
        checkpointSingleList = new List<CheckpointSingle>();
        foreach (Transform checkpointSingleTransform in checkpointsTransform)
        {
            CheckpointSingle checkpointSingle = checkpointSingleTransform.GetComponent<CheckpointSingle>();
            checkpointSingle.SetTrackCheckpoints(this);
            checkpointSingleList.Add(checkpointSingle);
        }
        nextCheckpointIndex = 0;
    }

    public void CarThroughCheckpoint(CheckpointSingle checkpointSingle, Transform playerTransform)
    {
        if(checkpointSingleList.IndexOf(checkpointSingle) == nextCheckpointIndex)
        {
            nextCheckpointIndex = (nextCheckpointIndex + 1) % checkpointSingleList.Count;
            OnCarCorrectCheckpoint?.Invoke(this, new CarCheckpointEventArgs { carTransform = playerTransform });
        } else
        {
            OnCarWrongCheckpoint?.Invoke(this, new CarCheckpointEventArgs { carTransform = playerTransform });
        }
    }

    public void ResetCheckpoints()
    {
        nextCheckpointIndex = 0;
    }

    public CheckpointSingle GetNextCheckpoint(Transform transform)
    {
        return checkpointSingleList[nextCheckpointIndex];
    }
}
