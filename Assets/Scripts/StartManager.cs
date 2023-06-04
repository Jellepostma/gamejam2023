using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour
{
    public InputAction startAction;

    private void Awake()
    {
        startAction.performed += ctx =>
        { 
            SceneManager.LoadScene("MainScene");
        };
    }
    
    public void OnEnable()
    {
        startAction.Enable();
    }

    public void OnDisable()
    {
        startAction.Disable();
    }
}
