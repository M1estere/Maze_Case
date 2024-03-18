using UnityEngine;

public class PauseAnimationState : MonoBehaviour
{
    public void DisablePauseScreen()
    {
        LevelController.Instance.UnStopTime();
        gameObject.SetActive(false);
    }
}
