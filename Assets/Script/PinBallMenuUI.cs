using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PinBallMenuUI : MonoBehaviour
{
    public Button mainMenuButton;

    // Start is called before the first frame update
    void Start()
    {
        mainMenuButton.onClick.AddListener(MainMenuButton);
    }

    private void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
