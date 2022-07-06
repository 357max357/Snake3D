using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeLock : MonoBehaviour
{
    [SerializeField] private GameObject _snake;

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Snake")
            Camera.main.GetComponent<UIManager>().Lose();
    }
}
