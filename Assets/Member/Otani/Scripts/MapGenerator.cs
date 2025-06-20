using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] GameObject[] _maps;
    [SerializeField] Transform _parentTransform;
    [SerializeField] float _mapHeight = 20f;
    [SerializeField] float _nextSpawnPos = 40f;

    private Rigidbody2D _rb;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        Debug.Log(_maps.Length);
    //        Instantiate(_maps[Random.Range(0, _maps.Length)], new Vector3(transform.position.x, transform.position.y + 40), Quaternion.identity, _parentTransform);
    //    }
    //}

    public void MapGenerat()
    {
        Debug.Log("ê∂ê¨ÇµÇ‹ÇµÇΩ");
        Instantiate(_maps[Random.Range(0, _maps.Length)], new Vector3(0, _nextSpawnPos), Quaternion.identity, _parentTransform);
        _nextSpawnPos += _mapHeight;
    }
}
