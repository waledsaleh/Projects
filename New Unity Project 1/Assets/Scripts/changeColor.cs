using UnityEngine;
using System.Collections;

public class changeColor : MonoBehaviour {

    public GameObject[] shape;
    Color someColor = Color.white;
    changeShape instance;

	// Use this for initialization
	void Start () {
       

	}

    void OnGUI()
    {
        someColor = ColorPicker(new Rect(0, 0, 120, 120), someColor);
    }

	// Update is called once per frame
	void Update () {
     
        if (Touched())
        {
            GameObject tempic = GameObject.FindGameObjectWithTag("shape");
            if(shape[0].gameObject.active == true)
                    shape[0].gameObject.GetComponent<Renderer>().material.color = someColor;
            
            else if (shape[1].gameObject.active == true) 
                    shape[1].gameObject.GetComponent<Renderer>().material.color = someColor;
                
            else if (shape[2].gameObject.active == true) 
                    shape[2].gameObject.GetComponent<Renderer>().material.color = someColor;

            else if (tempic !=null && tempic.tag == "shape" && tempic.active)
            {
               tempic.gameObject.GetComponent<Renderer>().material.color = someColor;
            }

            tempic = GameObject.FindGameObjectWithTag("shape1");
            if (tempic !=null && tempic.tag == "shape1" && tempic.active)
            {
               tempic.gameObject.GetComponent<Renderer>().material.color = someColor;
            }


        }

        }
    
    
    public bool Touched()
    {

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
    public static Color ColorPicker(Rect rect, Color color)
    {
        //Create a blank texture.
        Texture2D tex = new Texture2D(40, 40);


        GUILayout.BeginArea(rect, "", "Box");

        #region Slider block
        GUILayout.BeginHorizontal();
        GUILayout.BeginVertical("Box");
        //Sliders for rgb variables betwen 0.0 and 1.0
        GUILayout.BeginHorizontal();
        GUILayout.Label("R", GUILayout.Width(10));
        color.r = GUILayout.HorizontalSlider(color.r, 0f, 1f);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("G", GUILayout.Width(10));
        color.g = GUILayout.HorizontalSlider(color.g, 0f, 1f);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("B", GUILayout.Width(10));
        color.b = GUILayout.HorizontalSlider(color.b, 0f, 1f);
        GUILayout.EndHorizontal();
        GUILayout.EndVertical();
        #endregion

        //Color Preview
        GUILayout.BeginVertical("Box", new GUILayoutOption[] { GUILayout.Width(44), GUILayout.Height(44) });
        //Apply color to following label
        GUI.color = color;
        GUILayout.Label(tex);
        //Revert color to white to avoid messing up any following controls.
        GUI.color = Color.white;

        GUILayout.EndVertical();
        GUILayout.EndHorizontal();

        //Give color as RGB values.
        GUILayout.Label("Current Colour = " + (int)(color.r * 255) + "|" + (int)(color.g * 255) + "|" + (int)(color.b * 255));

        GUILayout.EndArea();
        //Finally return the modified value.
        return color;
    }
}
