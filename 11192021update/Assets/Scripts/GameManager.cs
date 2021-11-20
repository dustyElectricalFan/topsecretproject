using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager manager; 
    public GameObject canvasPrefab;
    public GameObject prefab;
    private Canvas canvas;
    private GameObject menuPrefab;
    //private GameObject pauseMenuPrefab;

    void Awake()
    {
        if (manager == null)
        {
            manager = this;
            DontDestroyOnLoad(this);
        }
        else if (manager == this)
        {
            Destroy(gameObject);
        }
        
    }

    private Canvas theCanvas
    {
      get{
          if(canvas == null)
          {
              canvas = FindObjectOfType<Canvas>();
          if(canvas == null)
          {
              canvas = Instantiate(canvasPrefab).GetComponent<Canvas>();
          }
          }
          return canvas;
      }
    }


    void Update()
    {
       if(Input.GetKeyDown(KeyCode.Escape))
       {
        Debug.Log("esc pressed");
        if(menuPrefab == null)
       {
         menuPrefab = Instantiate(prefab, theCanvas.transform);
       }
    }
    }
}
