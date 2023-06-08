using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class passageBlock : MonoBehaviour
{
    [SerializeField] private BoxCollider2D trigger;
    [SerializeField] private Tilemap tilemap;
    [SerializeField] private TilemapCollider2D collider;
    [SerializeField] private TilemapRenderer renderer;

    private void Start()
    {
        tilemap.enabled = false;
        collider.enabled = false;
        renderer.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")){
            tilemap.enabled = true;
            collider.enabled = true;
            renderer.enabled = true;
        }
    }
}

