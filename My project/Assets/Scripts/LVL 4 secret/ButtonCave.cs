using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ButtonCave : MonoBehaviour
{
    [SerializeField] private GameObject promptGO;
    [SerializeField] private SpriteRenderer color;
    [SerializeField] private Light2D light;

    private SpriteRenderer prompt;

    public Door door;
    // Start is called before the first frame update
    void Start()
    {
        prompt = promptGO.GetComponent<SpriteRenderer>();
        prompt.enabled = false;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && promptGO.activeSelf)
        {
            prompt.enabled = true;
            
            if (Input.GetKey(KeyCode.E))
            {
                prompt.enabled = false;
                promptGO.SetActive(false);
                color.color = Color.green;
                light.color = Color.green;
                door.buttonCount++;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        prompt.enabled = false;
    }
}