using FMODUnity;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using FMOD.Studio;

public class forestAmbScript : MonoBehaviour
{
    [SerializeField] private EventReference snapshotRef;

    private EventInstance snapshotInstance;

    private void OnTriggerEnter(Collider other)
    {
        if (snapshotRef.IsNull) return;

        snapshotInstance = FMODUnity.RuntimeManager.CreateInstance(snapshotRef);
        snapshotInstance.start();

    }

    private void OnTriggerExit(Collider other)
    {
        if (snapshotRef.IsNull) return;

        snapshotInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        snapshotInstance.release();
    }
}
