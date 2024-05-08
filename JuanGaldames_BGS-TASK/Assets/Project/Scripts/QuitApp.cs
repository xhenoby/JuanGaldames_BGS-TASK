using UnityEngine;
using UnityEngine.InputSystem;

public class QuitApp : MonoBehaviour
{
    public void OnQuit(InputValue inputValue)
    {
        Application.Quit();
    }
}
