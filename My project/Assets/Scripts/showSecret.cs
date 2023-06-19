using DG.Tweening;
using UnityEngine;
using UnityEngine.Tilemaps;

public class showSecret : MonoBehaviour
{
    public int appleAmount;
    public int collectedApple;
    [SerializeField] private Tilemap tilemap;
    [SerializeField] private TilemapCollider2D collider;
    [SerializeField] private TilemapRenderer renderer;

    public GameObject winnerTile;

    public ItemCollector player;
    
    private void Start()
    {
        tilemap.enabled = true;
        collider.enabled = true;
        renderer.enabled = true;

        winnerTile.transform.DOMoveY(3, 1.5f, false);
    }

    private void Update()
    {
        collectedApple = player.apples;

        if (collectedApple == appleAmount)
        {
            tilemap.enabled = false;
            collider.enabled = false;
            renderer.enabled = false;

            winnerTile.transform.DOMoveY(0, 1.5f, false);
        }
    }
}

/*
        startpos = winnerTileStartPos.transform.position;
        endpos = winnerTileEndPos.transform.position;
        
        winnerTile.transform.position = endpos;

        winnerTile.transform.position = Vector2.Lerp(endpos, startpos, Time.deltaTime);
       
        public GameObject winnerTileEndPos;
        public GameObject winnerTileStartPos;
  
        private Vector2 endpos;
        private Vector2 startpos;
         
*/