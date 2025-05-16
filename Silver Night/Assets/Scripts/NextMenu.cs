using UnityEngine.SceneManagement;
using UnityEngine;

public class NextMenu : MonoBehaviour
{
    public void LoadLevel(int index)
    {
        SceneManager.LoadScene(index);
    }
}
