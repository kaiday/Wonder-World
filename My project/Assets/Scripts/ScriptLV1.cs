using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptLV1 : MonoBehaviour
{
    public static bool portal = true;
    float xPos = 34.09f;
    float yPos = -2.08f;
    [SerializeField] private GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Portal1").SetActive(portal);

        if (portal == false)
        {
            Player.transform.position = new Vector3(xPos, yPos, 0);
        }

    }
}



