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

   public static void displayLogStatic (List<List<string>> displayText)
   {
       instance.displayLog(displayText);
   }

   public static void pullUpDisplayStatic ()
   {
       instance.gameObject.SetActive(true);
   }

   private void displayLog (List<List<string>> displayText)
   {
       dialouge.text = "";
      
      foreach(List<string> bext in displayText)
      {
          dialouge.text += bext[0];
          dialouge.text += '\n';
          dialouge.text += bext[1];
          dialouge.text += '\n';
          dialouge.text += '\n';
      }
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
