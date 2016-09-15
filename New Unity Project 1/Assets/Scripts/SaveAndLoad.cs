using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class SaveAndLoad : MonoBehaviour {

   public int count = 0;
   public List<GameObject> gameObjects = new List<GameObject>();
       
    public Rect objectsScreen;
    public Vector2 scrollPosition = Vector2.zero; //add variable for scroll
    
     void Start()
     {
         objectsScreen = new Rect(Screen.width * 0.68f, Screen.height * 0.10f, 180, 330);

     }
     void Update()
     {

     }
     void OnGUI()
     {
       objectsScreen = GUI.Window(1, objectsScreen, DrawRadarList, "GameObjects");

     }
     void DrawRadarList(int WindowID)
     {
         scrollPosition = GUI.BeginScrollView(new Rect(0, 0, objectsScreen.width, objectsScreen.height), scrollPosition, new Rect(0, 0, objectsScreen.width, 60 * gameObjects.Count));
        
          
         for (int i = 0; i < gameObjects.Count; ++i)
         {
            
             if (GUI.Button(new Rect(0, 60 * i, objectsScreen.width - 50, 60), gameObjects[i].name))
             {
               
               
                 if (!gameObjects[i].active)
                 {
                     GameObject  tempic = GameObject.FindGameObjectWithTag("shape");
                     if(tempic !=null)
                     tempic.SetActive(false);

                     gameObjects[i].SetActive(true);


                 }
                
                 else
                 {
                     GameObject  tempic = GameObject.FindGameObjectWithTag("shape");
                     tempic.SetActive(false);
                   
                     GameObject newObj = Instantiate(gameObjects[i], new Vector3(0,2,0), Quaternion.identity) as GameObject;
                     newObj.tag = "shape1";
                    

                     Debug.Log(gameObjects[i].name);
                 }

             }

         }
         
         GUI.EndScrollView();
         GUI.DragWindow(new Rect(0, 0, 180, 20));
     }
     
     public void saveObject()
     {
         GameObject tempic = GameObject.FindGameObjectWithTag("shape");
      
         if(tempic !=null)
         gameObjects.Add(tempic);

     }
     
     public int numShape()
     {
         return count;
     }

}
