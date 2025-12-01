using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private float interval = 0.5f;
    [SerializeField] private Clicker _clicker;

    private float _count = 0;

    private Coroutine _coroutine;

    public event Action<float> Changed;

    private void OnEnable()
    {
        _clicker.Clicked += CounterStart;
    }

    private void OnDisable()
    {
        _clicker.Clicked -= CounterStart;
    }

    public void CounterStart()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
        else
        {
            _coroutine = StartCoroutine(Counting());
        }
    }

    private IEnumerator Counting()
    {
        while (enabled)
        {
            yield return new WaitForSeconds(interval);
            _count++;
            Changed?.Invoke(_count);
        }
    }
}
