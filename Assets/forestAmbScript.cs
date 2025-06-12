using FMODUnity;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using FMOD.Studio;

public class forestAmbScript : MonoBehaviour
{
    [SerializeField] private EventReference snapshotRef;

    private EventInstance snapshotInstance;
    private bool snapshotActive;

    private void OnTriggerEnter(Collider other)
    {
        if (snapshotActive) return;

        snapshotInstance = FMODUnity.RuntimeManager.CreateInstance(snapshotRef);
        snapshotInstance.start();
        snapshotActive = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (!snapshotActive) return;
       
        snapshotInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        snapshotInstance.release();
        snapshotActive = false;
    }
}
