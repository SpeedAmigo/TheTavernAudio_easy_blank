using UnityEngine;
using UnityEngine.Events;

public class PauseMenuScript : MonoBehaviour
{
    [SerializeField] private UnityEvent pauseToggle;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseToggle?.Invoke();
        }
    }

    public void PauseToggle(GameObject menu)
    {
        menu.SetActive(!menu.activeInHierarchy);

        if (menu.activeInHierarchy == true)
        {
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
        else
        {
            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
