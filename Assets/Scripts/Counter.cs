using UnityEngine;
using UnityEngine.InputSystem;

public class Counter : MonoBehaviour
{
    private float interval = 0.5f;
    private float timer = 0f;
    private int counter = 0;
    private bool isCounting = false;

    void Update()
    {
        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            isCounting = !isCounting;
        }

        if (isCounting)
        {
            timer += Time.deltaTime;

            if (timer >= interval)
            {
                counter++;
                timer -= interval;

                Debug.Log("—четчик: " + counter);
            }
        }
    }
}

