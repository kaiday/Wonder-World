using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class showSecret : MonoBehaviour
{
    public int cherryAmount;
    public int collectedCherry;
    [SerializeField] private Tilemap tilemap;
    [SerializeField] private TilemapCollider2D collider;
    [SerializeField] private TilemapRenderer renderer;
    
    [SerializeField] private Tilemap Winnertilemap;
    [SerializeField] private TilemapCollider2D Winnercollider;
    [SerializeField] private TilemapRenderer Winnerrenderer;

    private void Start()
    {
        tilemap.enabled = true;
        collider.enabled = true;
        renderer.enabled = true;
        
        Winnertilemap.enabled = true;
        Winnercollider.enabled = true;
        Winnerrenderer.enabled = true;
    }
    
}