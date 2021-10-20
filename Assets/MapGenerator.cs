using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    // 랜덤하게 큐브 배치
    public Transform cubeParent;
    public Cube baseItem;
    public int makeCount = 20;
    void Awake()
    {
        GenerateCubes();
    }

    Cube prevCube;
    Cube currentCube;
    bool isGotoZeroPos = false;
    [ContextMenu("큐브 생성")]
    void GenerateCubes()
    {
        baseItem.gameObject.SetActive(true);
        prevCube = baseItem;
        for (int i = 0; i < makeCount; i++)
        {
            currentCube = Instantiate(prevCube, cubeParent);
            if (isGotoZeroPos)
            {
                if (currentCube.transform.position.x < 0)
                {
                    GenerateRight();
                    if (currentCube.transform.position.x > 0)
                        isGotoZeroPos = false;
                }
                else if (currentCube.transform.position.x > 0)
                {
                    GenerateLeft();
                    if (currentCube.transform.position.x < 0)
                        isGotoZeroPos = false;
                }
            }
            else
            {
                if (Random.Range(0, 1f) < 0.5f)
                    GenerateLeft();
                else
                    GenerateRight();

                if (Mathf.Abs(currentCube.transform.position.x) > 3)
                    isGotoZeroPos = true;
            }

            prevCube = currentCube;
        }
        baseItem.gameObject.SetActive(false);
    }

    private void GenerateLeft()
    {
        currentCube.transform.Translate(Vector3.forward, Space.Self);
    }
    private void GenerateRight()
    {
        currentCube.transform.Translate(Vector3.right, Space.Self);
    }
}
