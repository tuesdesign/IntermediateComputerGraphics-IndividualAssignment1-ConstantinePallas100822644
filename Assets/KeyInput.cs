using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInput : MonoBehaviour
{
    public List<GameObject> objectsToMaterialToggle = new List<GameObject>();
    public ScreenCameraShader cam;

    /* Materials */
    public Material AmbientDiffuse;
    public Material Specular;
    public Material ToonRamp;
    /* Other Materials */
    public Material RimLight;
    public Material NormalMap;

    /* LUTs */
    public Material CoolLUT;
    public Material WarmLUT;
    public Material CustomLUT;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int matToUse = 0;
        int lutToUse = 0;

        if (Input.GetButtonDown("1"))
        {
            matToUse = 1;
        }
        if (Input.GetButtonDown("2"))
        {
            matToUse = 2;
        }
        if (Input.GetButtonDown("3"))
        {
            matToUse = 3;
        }
        if (Input.GetButtonDown("4"))
        {
            matToUse = 4;
        }
        if (Input.GetButtonDown("5"))
        {
            matToUse = 5;
        }

        if (Input.GetButtonDown("6"))
        {
            lutToUse = 1;
        }
        if (Input.GetButtonDown("7"))
        {
            lutToUse = 2;
        }
        if (Input.GetButtonDown("8"))
        {
            lutToUse = 3;
        }

        switch (matToUse)
        {
            case 1:
                foreach (GameObject obj in objectsToMaterialToggle)
                {
                    obj.GetComponent<Renderer>().material = AmbientDiffuse;
                }
                break;
            case 2:
                foreach (GameObject obj in objectsToMaterialToggle)
                {
                    obj.GetComponent<Renderer>().material = Specular;
                }
                break;
            case 3:
                foreach (GameObject obj in objectsToMaterialToggle)
                {
                    obj.GetComponent<Renderer>().material = ToonRamp;
                }
                break;
            case 4:
                foreach (GameObject obj in objectsToMaterialToggle)
                {
                    obj.GetComponent<Renderer>().material = RimLight;
                }
                break;
            case 5:
                foreach (GameObject obj in objectsToMaterialToggle)
                {
                    obj.GetComponent<Renderer>().material = NormalMap;
                }
                break;

            default:
                break;
        }

        switch (lutToUse)
        {
            case 1:
                cam.m_renderMaterial = CoolLUT;
                break;
            case 2:
                cam.m_renderMaterial = WarmLUT;
                break;
            case 3:
                cam.m_renderMaterial = CustomLUT;
                break;
            default:
                break;
        }
    }
}
