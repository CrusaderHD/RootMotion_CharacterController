using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public GameObject levelCompleteUI;
    #region Singleton

    public static GameManager instance;
    void Awake()
    {
        instance = this;
    }

    #endregion

    public void CompleteLevel()
    {
        Debug.Log("Level Complete.");
        levelCompleteUI.SetActive(true);
    }


}
