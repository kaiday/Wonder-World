using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatform : MonoBehaviour
{

    public GameObject platformController;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(getObjectCurrentMap(platformController).transform);
        }
    }

    private GameObject getObjectCurrentMap(GameObject gameObject)
    {
        return gameObject.GetComponent<platformMapControl>().map;
    }
}
