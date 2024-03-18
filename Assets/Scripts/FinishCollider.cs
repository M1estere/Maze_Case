using System.Collections;
using UnityEngine;

public class FinishCollider : MonoBehaviour
{
    private FinishLevelController _finishLevelController;

    private void Awake() => _finishLevelController = FindObjectOfType<FinishLevelController>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            StartCoroutine(DelayedFinish());
        }
    }

    private IEnumerator DelayedFinish()
    {
        yield return new WaitForSecondsRealtime(.3f);
        _finishLevelController.DisplayFinish();
    }
}
