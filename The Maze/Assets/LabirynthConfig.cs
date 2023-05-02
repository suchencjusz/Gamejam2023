using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabirynthConfig : MonoBehaviour
{
    private LevelsManager _levelsManager;

    public RoomTemplates roomTemplates;

    void Start()
    {
        _levelsManager = GetComponent<LevelsManager>();

        roomTemplates = GetComponent<RoomTemplates>();
    }

    public void test(){
        Debug.Log("test");
    }
}
