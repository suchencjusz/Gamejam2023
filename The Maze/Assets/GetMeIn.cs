using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetMeIn : MonoBehaviour
{
    public bool debug;
    private RandomInLabirynthInitiator randomInLabirynthInitiator;

    void Start()
    {
        StartCoroutine(TeleportAfter5Seconds());
    }

    IEnumerator TeleportAfter5Seconds()
    {
        yield return new WaitForSeconds(5);

        RandomInLabirynthInitiator randomInLabirynthInitiator = new RandomInLabirynthInitiator();

        Vector2 position = randomInLabirynthInitiator.InitInLabirynth(4f);

        transform.position = new Vector3(position.x, 0, position.y);
    }

}
