using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EditorCreateLevel : MonoBehaviour
{
    public BlockLevel bl;
    BlockElement sel;
    bool mouseDown = false;
    bool mouseDownStart = false;
    public Dictionary<BlockElement, LineRenderer> Lines = new Dictionary<BlockElement, LineRenderer>();
    public LineRenderer preb;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (sel != null && mouseDown)
        {
            var playerPlane = new Plane(Vector3.up, Vector3.zero);

            // Generate a ray from the cursor position
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            //if (Physics.SphereCast(ray, 2, out hit, 200, HitMask))
            if (Physics.Raycast(ray, out hit))
            {
                if(!mouseDownStart)
                {
                    mouseDownStart = true;
                    sel.From = hit.point;
                    sel.From.y = 0;
                    Lines[sel].SetPosition(0, sel.From);
                }
                else
                {
                    sel.To = hit.point;
                    sel.To.y = 0;
                    Lines[sel].SetPosition(1, sel.To);
                }
            }
        }
    }

    void OnGUI()
    {
        foreach (var b in Resources.LoadAll<BlockLevel>("BlockLevels"))
            if (GUILayout.Button(b.name))
            {
                bl = b;
                foreach(var l in Lines.Keys)
                    Destroy(Lines[l].gameObject);
                Lines.Clear();

                foreach(var be in bl.BlockElements)
                {
                    var l = Instantiate(preb);
                    l.SetPosition(0, be.From);
                    l.SetPosition(1, be.To);
                    l.SetWidth(be.Width, be.Width);
                    Lines.Add(be,l);
                }
            }

        if (bl != null)
        {
            if (GUILayout.Button("Add element"))
            {
                if(sel != null)
                    Lines[sel].SetColors(Color.white, Color.white);
                sel = new BlockElement();
                bl.BlockElements.Add(sel);
                var l = Instantiate(preb);
                l.SetPosition(0, sel.From);
                l.SetPosition(1, sel.To);
                l.SetWidth(sel.Width, sel.Width);
                Lines.Add(sel,l);
                Lines[sel].SetColors(Color.yellow, Color.yellow);
            }

            if (GUILayout.Button("Save"))
            {
                UnityEditor.EditorUtility.SetDirty(bl);
                UnityEditor.AssetDatabase.SaveAssets();
            }

            foreach (var be in bl.BlockElements)
                if (GUILayout.Button("sel"))
                {
                    foreach (var l in Lines.Keys)
                        Lines[l].SetColors(Color.white, Color.white);
                    sel = be;
                    Lines[sel].SetColors(Color.yellow, Color.yellow);
                }

            if (sel != null)
            {
                GUILayout.TextArea("Height : " + sel.Height);
                sel.Height = (int)GUILayout.HorizontalSlider(sel.Height, 1, 8);
                GUILayout.TextArea("Width: " + sel.Width);
                sel.Width = (int)GUILayout.HorizontalSlider(sel.Width, 1, 8);
                Lines[sel].SetWidth(sel.Width, sel.Width);
            }
        }

    }

    public void OnMouseDown()
    {
        mouseDown = true;
        mouseDownStart = false;
    }

    public void OnMouseUp()
    {
        mouseDown = false;
        mouseDownStart = false;
    }
}
