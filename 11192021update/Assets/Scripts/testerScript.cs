using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class testerScript : MonoBehaviour
{
    public GameObject prefab;
    private GameObject testImage;
    public Canvas canvas;
    // Start is called before the first frame update
    void Start()
    {
       prefab = Instantiate(prefab, canvas.transform);
       /*
       GameObject testImage = new GameObject("testing");
       var theComp = testImage.AddComponent<Image>();
       theComp.sprite = Resources.Load<Sprite>("testassets/image1");
       testImage = Instantiate(testImage, canvas.transform);
       theComp = testImage.GetComponent<Image>();
       theComp.sprite = Resources.Load<Sprite>("testassets/image2");
       */

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
