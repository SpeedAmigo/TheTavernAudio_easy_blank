using FMODUnity;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class healthTriggerScript : MonoBehaviour
{
    public FMOD.Studio.EventInstance health;
    public EventReference healthSnapshot;
    public Animator animator;

    private bool snapshotActivated;

    private void Start()
    {
        snapshotActivated = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            snapshotActivated = !snapshotActivated;
            ToggleSnapshot(snapshotActivated);
        }
    }

    private void ToggleSnapshot(bool value)
    {
        if (snapshotActivated == true)
        {
            animator.SetTrigger("FadeIn");

            health = FMODUnity.RuntimeManager.CreateInstance(healthSnapshot);
            health.start();
        }
        else if (snapshotActivated == false)
        {
            if (!health.isValid())
            {
                Debug.Log("Snapshot is not valid");
            }

            animator.SetTrigger("FadeOut");

            health.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            health.release();
        }
    }
}
