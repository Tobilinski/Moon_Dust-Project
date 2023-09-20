using System;
using UnityEngine;
using Cinemachine;
public class CameraScript : MonoBehaviour
{
    [Header("Camera shake Time")]
    [Space(10)]
    [SerializeField]
    private float ShakeTime;
    public static CameraScript Instance { get; private set;}
     //private Camera cam;
     private CinemachineVirtualCamera vcam;

    private void Awake()
    {
        Instance = this;
        vcam = GetComponent<CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    public void Update()
    {
        //Camera shake
       ShakeTime -= Time.deltaTime;
       StopShake();
    }

    public void ShakeCamera(float intensity, float time)
    {
        CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =
            vcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intensity;
        ShakeTime = time;
    }

    void StopShake()
    {
        if (ShakeTime <= 0f)
        {
            CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =
                vcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
            cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 0f;
        }
    }
}
