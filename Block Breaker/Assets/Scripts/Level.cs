using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int breakableBloocks;
    SceneLoader sceneLoader;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();  
    }
    public void CountBlocks()
    {
        breakableBloocks++;
    }

    public void DecreaseBrealableBlocks()
    {
        breakableBloocks--;
        if (breakableBloocks <= 0)
        {
            sceneLoader.LoadNextScene();
        }
    }

  
}
 