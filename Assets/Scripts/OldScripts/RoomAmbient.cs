using FMOD.Studio;
using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomAmbient : MonoBehaviour
{
    public EventInstance roomInstance;
    public EventReference reference;

    public bool insideRoom;

    public void DoorClosedSnapshot(bool value)
    {
        if (insideRoom == true && value == false)
        {
            roomInstance = RuntimeManager.CreateInstance(reference);
            roomInstance.start();
        }
        else if (insideRoom == true && value == true)
        {
            roomInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            roomInstance.release();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent<Rigidbody>(out var player)) return;
        insideRoom = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.TryGetComponent<Rigidbody>(out var player)) return;
        insideRoom = false;

        if (!roomInstance.isValid()) return; 

        roomInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        roomInstance.release();
    }
}
