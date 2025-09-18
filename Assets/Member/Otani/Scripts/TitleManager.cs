using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleManager : MonoBehaviour
{
    [SerializeField] private List<Behaviour> _iconList = new List<Behaviour>();
    [SerializeField] private float _cycle = 1;

    private int _nowChooseIcon;
    private double _time;

    // Start is called before the first frame update
    void Start()
    {
        _nowChooseIcon = 1;
        _time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            ResetColor(_iconList[_nowChooseIcon - 1]);
            if (_nowChooseIcon < _iconList.Count)
            {
                _nowChooseIcon++;
            }
            else if(_nowChooseIcon ==  _iconList.Count)
            {
                _nowChooseIcon = 1;
            }
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            ResetColor(_iconList[_nowChooseIcon - 1]);
            if (_nowChooseIcon > 1)
            {
                _nowChooseIcon--;
            }
            else if (_nowChooseIcon == 1)
            {
                _nowChooseIcon = _iconList.Count;
            }
        }

        SetColor(_iconList[_nowChooseIcon - 1]);
    }

    /// <summary>
    /// UIの点滅表示
    /// </summary>
    /// <param name="_target">点滅させるアイコン</param>
    private void SetColor(Behaviour _target)
    {
        _time += Time.deltaTime;
        var repeatValue = Mathf.Repeat((float)_time, _cycle);
        _target.enabled = repeatValue >= _cycle * 0.5;
    }

    /// <summary>
    /// UIの表示状況をリセット
    /// </summary>
    /// <param name="_target">点滅させるアイコン</param>
    private void ResetColor(Behaviour _target)
    {
        _target.enabled = true;
    }
}
