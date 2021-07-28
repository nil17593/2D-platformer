using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorouTines : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private int timer;

    IEnumerator HideObject()
    {
        yield return new WaitForSeconds(timer);
        player.SetActive(false);
    }
}
