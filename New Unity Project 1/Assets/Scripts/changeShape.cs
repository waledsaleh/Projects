using UnityEngine;
using System.Collections;

public class changeShape : MonoBehaviour {

    public GameObject cam;
    public  GameObject currShape;
   public int nextShape = 0;
    public  GameObject[] renderShapes;
    private static changeShape instance=null;
    SaveAndLoad sve;
    void Start()
    {
        sve = GetComponent<SaveAndLoad>();
      
        currShape = renderShapes[0];

    }
   //singleton pattern
    public static changeShape getInstance(){
    
        if (instance == null)
            instance = new changeShape();

        return instance;
    }
    
	// Update is called once per frame
	void Update () {

        if (Touched()){
         
            GameObject tempic = GameObject.FindGameObjectWithTag("shape");
        //    --c;
         //   Debug.Log(c);
            //We can use Factory pattern to represent shapes,but i failed :(
            if (renderShapes[nextShape].name == "Cube")
            {
              
                renderShapes[nextShape++].SetActive(false);
                renderShapes[nextShape].SetActive(true);
              
            }
            else if (renderShapes[nextShape].name == "Sphere" )
            {
                renderShapes[nextShape++].SetActive(false);
                renderShapes[nextShape].SetActive(true);
               
            }
            else if (renderShapes[nextShape].name == "Cone" )
            {
                renderShapes[nextShape].SetActive(false);
                nextShape = 0;
                renderShapes[nextShape].SetActive(true);
               
            }

          
        }
        currShape = renderShapes[nextShape];
	}

    public bool Touched(){

        bool check = false;
        Collider2D collider2D = gameObject.GetComponent<Collider2D>();
        //handling android touching
        if (Input.touchCount == 1)
        {
            Vector3 windowPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            Vector2 touchPos = new Vector2(windowPos.x, windowPos.y);
            if (collider2D == Physics2D.OverlapPoint(touchPos))
            {
                Debug.Log("Hit touch");
                check = true;

            }
        }

        //handling mouse click
        if (Input.GetMouseButtonUp(0))
        {
          //  Debug.Log("Clicked");
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
       
            Vector2 mousePos = new Vector2(pos.x, pos.y);

            if (collider2D == Physics2D.OverlapPoint(mousePos))
            {
                Debug.Log("Hit Mouse");
                check = true;
               
            }
        }
        return check;

    }

    public  GameObject currentActiveShape()
    {
        if (currShape == null) return null;

        return currShape;
    }


}

