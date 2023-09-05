using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeMapOnScene : MonoBehaviour
{
    public static changeMapOnScene instance;

    public GameObject exit;
    public GameObject enter;

    public GameObject mapController;

    private MapActive[] mapActiveList;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

        }
    }
            private void OnTriggerEnter2D(Collider2D gameObject)
    {
        if (gameObject.gameObject.CompareTag("Player"))
        {
            updateMapActive();
            Destroy(this.gameObject);
        }
    }

    public void updateMapActive()
    {
        mapController.GetComponent<ActiveMap>().updateMapActive(exit, enter);
    }
}
    