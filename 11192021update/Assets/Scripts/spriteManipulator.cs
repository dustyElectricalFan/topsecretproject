using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spriteManipulator : MonoBehaviour
{
    private static spriteManipulator instance;
    private GameObject sprite1;
    private GameObject sprite2;
    private List<GameObject> spriteList;

    private void Awake()
    {
        instance = this;
        sprite1 = transform.Find("sprite1").gameObject;
        sprite2 = transform.Find("sprite2").gameObject;
        spriteList = new List<GameObject>();
        spriteList.Add(sprite1);
        spriteList.Add(sprite2);

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void enableSprite(string spritenum)
    {
     instance.spriteList[int.Parse(spritenum) - 1].gameObject.SetActive(true);
    }

    public static void changeSprite(string spritenum, string theSprite)
    {
        var theImage = instance.spriteList[int.Parse(spritenum) - 1].GetComponent<Image>();
        theImage.sprite = Resources.Load<Sprite>("testassets/" + theSprite);
    }
}
