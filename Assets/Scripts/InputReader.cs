using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    public event Action MouseClicked;

    private void OnMouseUpAsButton()
    {
        MouseClicked?.Invoke();
    }
}