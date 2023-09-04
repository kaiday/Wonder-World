using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveMap : MonoBehaviour
{
    // Start is called before the first frame update

    public MapActive[] mapActiveList;
    public void setMapActive()
    {
        foreach(MapActive map in mapActiveList)
        {
            map.map.active = map.setMapActive;
        }
    }

    void Awake()
    {
        setMapActive();
    }

    // Update is called once per frame
    public void updateMapActive(GameObject exit, GameObject enter)
    {
        foreach (MapActive map in mapActiveList)
        {
            if (GameObject.ReferenceEquals(map.map, exit))
                map.setMapActive = false;
                map.map.active = map.setMapActive;

            if (GameObject.ReferenceEquals(map.map, enter))
                map.setMapActive = true;
                map.map.active = map.setMapActive;
        }
    }

}
