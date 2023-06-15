using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathtext : MonoBehaviour
{
    [SerializeField] private float timer = 2f;
    void Update()
    {
        StartCoroutine(SelfDestruct());
    }
    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(timer);
        Destroy(gameObject);
    }
}
