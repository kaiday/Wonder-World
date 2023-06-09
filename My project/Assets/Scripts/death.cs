using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class death : MonoBehaviour
{
    [SerializeField] private GameObject Obj;
    [SerializeField] private GameObject DeathText;
    void Awake()
    {
        DeathText.active = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
       if (other.gameObject.tag == "Player")
        {
            DeathText.active = true;
            Destroy(Obj);
        };
    }
}
