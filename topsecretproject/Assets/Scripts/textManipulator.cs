using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textManipulator : MonoBehaviour
{

    private Text dialouge;
    private bool isRunning;
    private static textManipulator instance;
    public GameObject prefab;
    public GameObject canvasPrefab;
    private Canvas canvas;
    private GameObject logPrefab;
    

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

   /*
    private GameObject theLogPrefab
    {
      get{
       if(logPrefab == null)
       {
           logPrefab = FindObjectOfType<logDisplay>();
           if(logPrefab == null)
           {
               logPrefab = Instantiate(prefab, theCanvas.transform).GetComponent<logDisplay>();
           }
       }
      return logPrefab;
      }
   }
   */
    
    private void Awake(){
        instance = this;
        dialouge = transform.Find("dialougeText").GetComponent<Text>();
        dialouge.text = "";
    }

    void Start()
    {
    }

    public static void startTypingStatic(string enterText)
    {
        instance.startTyping(enterText);
    }

    private void startTyping(string enterText)
    {
       StartCoroutine("TypeText",enterText);
    
    }
    /*
    private bool IsOverFlowingVertical()
    {
        float bestHeight = dialouge.gameObject.GetComponent<RectTransform>().rect.height;
        return LayoutUtility.GetPreferredHeight(dialouge.rectTransform) > bestHeight;
    }

    private bool IsOverFlowingHorizontal()
    {
        float bestWidth = dialouge.gameObject.GetComponent<RectTransform>().rect.width;
        return LayoutUtility.GetPreferredWidth(dialouge.rectTransform) > bestWidth;
    }
    */
    IEnumerator TypeText(string toType)
    {
        isRunning = true;
        foreach (char c in toType)
        {
            dialouge.text += c;
            yield return new WaitForSeconds(0.033f);

        }
        isRunning = false;
    }

    public void advanceText()
    {
        if(isRunning)
        {
            StopCoroutine("TypeText");
        }
        StartCoroutine("TypeText","aodaodjaofaereitwbtbejsbgkbrk");
    }

    public void seeLog()
    {
     //prefab = Instantiate(prefab, theCanvas.transform);
     if(logPrefab == null)
       {
         logPrefab = Instantiate(prefab, theCanvas.transform);
         logManipulator.displayLogStatic("oooooooouuuuuuhhhh");
       }
       else
       {
           logManipulator.pullUpDisplayStatic();
           logManipulator.displayLogStatic("oooooooouuuuuuhhhh");
       }
     
    }

    

    void Update()
    {
    
    }
}
