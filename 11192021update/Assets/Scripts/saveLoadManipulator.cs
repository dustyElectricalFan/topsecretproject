using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Xml;


public class saveLoadManipulator : MonoBehaviour
{

    private static saveLoadManipulator instance;
    private List<saveRecord> saveDataRecords =  new List<saveRecord>{null, null, null, null};

    private void Awake(){
        instance = this;
    }

    class saveRecord
    {
        public string sceneName {get; private set;}
        public string date {get; private set;}
        public string screenshot {get; private set;}

        public saveRecord(XmlNode theNode)
        {
            sceneName = theNode.Attributes["sceneName"].Value;
            date = theNode.Attributes["date"].Value;
            screenshot = theNode["screenshot"].InnerText;
     
        }
    }

    private void populateSaveTable(){
      saveDataRecords = new List<saveRecord>();
        TextAsset xmldoc = Resources.Load<TextAsset>("Story/saveRecords");
        XmlDocument storyXml = new XmlDocument();
        storyXml.LoadXml(xmldoc.text);
        int xmlCounter = 0;
        foreach (XmlNode node in storyXml.DocumentElement)
        {
          if(node.Name != "nullrecord")
          {
            saveRecord curLine = new saveRecord(node);
            Debug.Log(saveDataRecords.Count);
            //saveDataRecords[xmlCounter] = curLine;
          }
          xmlCounter += 1;
       }
       foreach (saveRecord rec in saveDataRecords)
       {
         Debug.Log(rec);
       }

    }

    public static void firstTimeOpen()
    {
      instance.populateSaveTable();
    }

    public static void saveGame()
    {
      Debug.Log("Save");
      instance.gameObject.SetActive(false);
    }

    public static void loadGame()
    {
      Debug.Log("Load");
      instance.gameObject.SetActive(false);
    }

    public static void startSaveLoad()
   {
       instance.gameObject.SetActive(true);
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
