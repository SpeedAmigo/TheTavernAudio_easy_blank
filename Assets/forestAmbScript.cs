using FMODUnity;
using UnityEngine;
using FMOD.Studio;
using System.Collections.Generic;

public class forestAmbScript : MonoBehaviour
{
    [SerializeField] private GameObject m_gameObject;

    private void OnTriggerEnter(Collider other)
    {
        m_gameObject.SetActive(false);
    }

    private void OnTriggerExit(Collider other)
    {
        m_gameObject.SetActive(!false);
    }
}
