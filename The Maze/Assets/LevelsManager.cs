using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsManager : MonoBehaviour
{
    public int DepthOfLevels = 3;

    public GameObject[,] LevelsMobs;
    public GameObject player;
    private Camera playerCamera;

    // public LabirynthConfig LabirynthConfig;
    public GameObject LabirynthGenrator;
    public GameObject LabirynthGenratorPrefab;

    public List<GameObject> rooms;

    void Start()
    {
        playerCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

        LabirynthGenrator = Instantiate(
            LabirynthGenratorPrefab,
            new Vector3(0, 0, 0),
            Quaternion.identity
        );

        rooms = LabirynthGenrator.GetComponentInChildren<RoomTemplates>().rooms;
        StartCoroutine(TeleportAfterSecond());

    }

    IEnumerator TeleportAfterSecond()
    {
        yield return new WaitForSeconds(0.15f); //after first gen

        playerCamera.transform.position = rooms[0].transform.position;  
        player.transform.position = rooms[0].transform.position;
    }
}
