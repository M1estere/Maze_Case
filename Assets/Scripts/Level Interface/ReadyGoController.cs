using System.Collections;
using UnityEngine;

public class ReadyGoController : MonoBehaviour
{
    [SerializeField] private GameObject _goLine;
    [Space(5)]

    [SerializeField] private float _midDelay = 2.5f;

    private void Awake()
    {
        _goLine.SetActive(false);
    }

    private IEnumerator Start()
    {
        yield return new WaitForSecondsRealtime(_midDelay);
        _goLine.SetActive(true);
    }
}
