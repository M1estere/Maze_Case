using UnityEngine;

public class PauseMenuController : MonoBehaviour
{
    [SerializeField] private Animator _pauseMenuAnimator;
    [SerializeField] private GameObject _pauseMenuScreen;
    [SerializeField] private KeyCode _pauseToggleKey;

    private void Update()
    {
        if (LevelController.Instance.LevelStarted == false) return;

        if (Input.GetKeyDown(_pauseToggleKey))
        {
            bool state = _pauseMenuScreen.activeSelf;

            if (state) PlayGame();
            else PauseGame();
        }
    }

    private void PauseGame()
    {
        LevelController.Instance.StopTime();
        _pauseMenuScreen.SetActive(true);
    }

    public void PlayGame() => _pauseMenuAnimator.SetTrigger("Close");

    public void RestartLevel()
    {
        SaveController.Instance.DeleteAllKeys();
        LevelController.Instance.RestartLevel();
    }

    public void MainMenu()
    {
        SaveController.Instance.Save();
        LevelController.Instance.OpenScene(0);
    }

    public void QuitGame()
    {
        SaveController.Instance.Save();
        Application.Quit();
    }
}
