using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//
// can be initialized in labirynth or not (outside)
// ~suchencjusz
//

//
// kod lgeneratraora labiryntu zapisuje w liscie prefaby z ktorych sa stworzone sciny itp
// z nich mozna losowac zamiast z tego frankenstaina ktory czasami dziala a czasami nie
// 
// POZA TYM GENERATOR LABIRYNTU TRZEBA WRZUCIC DO OSOBNEGO SKRYPTU BY MIEC MOZLIWOSC
// JEGO TWORZZENIA PO JEGO PRZEJSCIU (IDK 3-5 LEVELI LABIRYNTOW)
// I BEDZIE GIT, NARAZIE JEST TWORZONY ODRAZU W VOID START ALE TO JEST
// HOP SIUP
//

public class RandomInLabirynthInitiator : MonoBehaviour
{
    public Vector2 InitInLabirynth(float minDistanceFromSpawn)
    {
        List<Vector2> possiblePositionsList = new List<Vector2>();

        for (int x = -50; x < 50; x++) // no chyba wiekszych labiryntow nie bedzie
        {
            for (int y = -50; y < 50; y++)
            {
                if (isInLabirynth(new Vector2(x, y)))
                {
                    possiblePositionsList.Add(new Vector2(x, y));
                }
            }
        }

        if (minDistanceFromSpawn > 1f)
        {
            List<Vector2> possiblePositionsList2 = new List<Vector2>();

            foreach (Vector2 possiblePosition in possiblePositionsList)
            {
                if (Vector2.Distance(possiblePosition, new Vector2(0, 0)) > minDistanceFromSpawn)
                {
                    possiblePositionsList2.Add(possiblePosition);
                }
            }

            return possiblePositionsList2[Random.Range(0, possiblePositionsList2.Count)];
        }

        return possiblePositionsList[Random.Range(0, possiblePositionsList.Count)];
    }

    private bool isInLabirynth(Vector2 toTest)
    {
        bool[] imIn = new bool[8];

        // 0 45 90 135 180 225 270 315 co 45 stopni cn?????
        //
        //      -
        //   oo   oo
        // o         o
        // o         o
        //  oo     oo
        //      -
        //


        for (int i = 0; i < 8; i++)
        {
            imIn[i] = false;
        }

        for (int i = 0; i < 360; i = i + 45)
        {
            RaycastHit2D hit = Physics2D.Raycast(
                new Vector2(toTest.x, toTest.y),
                new Vector2(Mathf.Cos(i), Mathf.Sin(i)),
                1000.0f
            );

            // Collider2D collider = new Collider2D(); kurwa nie wiem jak sprawedzic czy jest collider na podayn,m wektorze czesto sie respi w scianie xd
            // if (collider.IsTouching(hit.collider)) // idk czy dziala
            // {
            //     return false;
            // }

            if (hit.collider != null)
            {
                imIn[i / 45] = true;
            }
        }

        return imIn[0] && imIn[1] && imIn[2] && imIn[3] && imIn[4] && imIn[5] && imIn[6] && imIn[7];
    }
}
