using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class hideSecret : MonoBehaviour
{
    [SerializeField] private ItemCollector collector;
    [SerializeField] private Tilemap tilemap;
    [SerializeField] private TilemapCollider2D collider;
    [SerializeField] private TilemapRenderer renderer;

    private void Start()
    {
        tilemap.enabled = false;
        collider.enabled = false;
        renderer.enabled = false;
    }

    private void Update()
    {
        if (collector.secretCollected)
        {
            tilemap.enabled = true;
            collider.enabled = true;
            renderer.enabled = true;
        }
    }
}
