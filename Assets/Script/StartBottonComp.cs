using UnityEngine;
using UnityEngine.SceneManagement; 

public class StartBottonComp : MonoBehaviour
{
    public void OnPressStartButton()
    {
        SceneManager.LoadScene("Gameplay");
    }
}
