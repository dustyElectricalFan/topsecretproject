using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Xml;

public class textManipulator : MonoBehaviour
{

    private Text dialouge;
    private Text speaker;
    private bool isRunning;
    private static textManipulator instance;
    public GameObject prefab;
    public GameObject canvasPrefab;
    public GameObject sprite1;
    public GameObject sprite2;
    private Canvas canvas;
    private GameObject logPrefab;
    private List<Line> chapter; 
    private List<List<string>> log;
    private int curText = 0;
    

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

    class Line
    {
        public string lineID {get; private set;}
        public string speaker {get; private set;}
        public string theLine {get; private set;}
        public string sprite {get; private set;}
        public string spritenum {get; private set;}

        public Line(XmlNode theNode)
        {
            lineID = theNode.Attributes["ID"].Value;
            speaker = theNode.Attributes["speaker"].Value;
            theLine = theNode["theLine"].InnerText;
            if(theNode["sprite"] != null)
            {
            sprite = theNode["sprite"].InnerText;
            }
            else
            {
                sprite = null;
            }
            if(theNode["spritenum"] != null)
            {
            spritenum = theNode["spritenum"].InnerText;
            }
            else
            {
                spritenum = null;
            }
            
        }
    }
    
    private void Awake(){
        instance = this;
        populateDialouge();
    }

    void Start()
    {
        instance.startTyping(chapter[0].theLine);
    }

    private void populateDialouge()
    {
        dialouge = transform.Find("dialougeText").GetComponent<Text>();
        speaker = transform.Find("speakerimg/speakername").GetComponent<Text>();
        dialouge.text = "";
        speaker.text = "";
        chapter = new List<Line>();
        log = new List<List<string>>();
        TextAsset xmldoc = Resources.Load<TextAsset>("Story/new 1");
        XmlDocument storyXml = new XmlDocument();
        storyXml.LoadXml(xmldoc.text);
        foreach (XmlNode node in storyXml.DocumentElement)
        {
            Line curLine = new Line(node);
            chapter.Add(curLine);
        }
    }

    private void startTyping(string enterText)
    {
       StartCoroutine("TypeText",enterText);
    }
    
    IEnumerator TypeText(string toType)
    {
        isRunning = true;
        speaker.text = chapter[curText].speaker;

        
        if(chapter[curText].sprite != null)
        {
            var theImage = transform.Find(chapter[curText].spritenum).GetComponent<Image>();
            theImage.sprite = Resources.Load<Sprite>("testassets/" + chapter[curText].sprite);
            transform.Find(chapter[curText].spritenum).gameObject.SetActive(true);
        }


        foreach (char c in toType)
        {
            dialouge.text += c;
            yield return new WaitForSeconds(0.020f);

        }
        isRunning = false;
    }

    public void advanceText()
    {
        if(isRunning)
        {
            StopCoroutine("TypeText");
            dialouge.text = chapter[curText].theLine;
            isRunning = false;
        }
        else{
            List<string> newEntry = new List<string>();
            newEntry.Add(chapter[curText].speaker);
            newEntry.Add(chapter[curText].theLine);
            log.Add(newEntry);
            dialouge.text = "";
            curText += 1;
            isRunning = true;
            StartCoroutine("TypeText",chapter[curText].theLine);
        }
       
    }

    public void seeLog()
    {
     
     if(logPrefab == null)
       {
         logPrefab = Instantiate(prefab, theCanvas.transform);
         logManipulator.displayLogStatic(log);
       }
       else
       {
           logManipulator.pullUpDisplayStatic();
       }
     
    }

    

    void Update()
    {
    
    }
}
