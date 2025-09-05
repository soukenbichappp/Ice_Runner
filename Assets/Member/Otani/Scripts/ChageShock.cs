using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChageShock : MonoBehaviour
{
    [SerializeField] private Renderer _target;
    [SerializeField] private float _cycle = 1;

    private double _time;

    // Update is called once per frame
    void Update()
    {

        _time += Time.deltaTime;
        var repeatValue = Mathf.Repeat((float)_time, _cycle);

        _target.enabled = repeatValue >= _cycle * 0.5;
    }
}
