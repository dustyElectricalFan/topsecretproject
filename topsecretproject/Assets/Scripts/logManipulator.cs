using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class logManipulator : MonoBehaviour
{
    private static logManipulator instance;
    private Text dialouge;

    private void Awake(){
        instance = this;
        dialouge = transform.Find("logDisplayBackground/logDisplayText").GetComponent<Text>();
        dialouge.text = "";
        
    }

   public static void displayLogStatic (string displayText)
   {
       instance.displayLog(displayText);
   }

   public static void pullUpDisplayStatic ()
   {
       instance.gameObject.SetActive(true);
   }

   private void displayLog (string displayText)
   {
      dialouge.text = displayText;
   }

   public void endDisplay()
   {
       instance.gameObject.SetActive(false);
   }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
