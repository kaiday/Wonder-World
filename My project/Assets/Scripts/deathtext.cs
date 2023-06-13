using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathtext : MonoBehaviour
{
    [SerializeField] private float timer = 2f;
    void Start()
    {
        StartCoroutine(SelfDestruct());
    }
    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(timer);
        Destroy(gameObject);
    }
}
