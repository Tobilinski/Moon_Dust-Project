using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CameraScript : MonoBehaviour
{
    private float zoom = 4f;

     //private Camera cam;
    [SerializeField] private CinemachineVirtualCamera vcam;

    // Update is called once per frame
    public void Update()
    {
        if (vcam.m_Lens.Orthographic)
        {
            vcam.m_Lens.OrthographicSize -= Input.GetAxis("Mouse ScrollWheel") * zoom;
        }
        else
        {
            vcam.m_Lens.OrthographicSize -= Input.GetAxis("Mouse ScrollWheel") * zoom;
        }
       
         
    }
}
