using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private SceneLoader _sceneLoader;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Shockwave"))
        {
            Destroy(this.gameObject);
        }
        if (collider.CompareTag("Player"))
        {
            _sceneLoader.LoadResultScene();
        }
    }

}
