using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testerScript : MonoBehaviour
{
    public GameObject prefab;
    public Canvas canvas;
    // Start is called before the first frame update
    void Start()
    {
       prefab = Instantiate(prefab, canvas.transform);
       textManipulator.startTypingStatic("testingtestingtesting testingtestingtestingt estingtestin gtesti ngtestingtestingtestingtestingtestingtes tingtesti ngte stingtest ingtestingtes tingtesting tes tingtestingtestingtestingtestingtesti ngte stin gtestingtestingstingtesti ngtestingtestingtestingtest ingtestingtestingtestingtestingtes tingtestingtesti ngttestingtestingt esting testingtestingtestingtes tingt");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
