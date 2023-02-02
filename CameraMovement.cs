using UnityEngine;
using Cinemachine;
using System.Collections;


public class CameraMovement : MonoBehaviour
{
    public CinemachineVirtualCamera frame1_cam;
    public CinemachineVirtualCamera frame2_cam;
    public CinemachineVirtualCamera frame3_cam;
    public CinemachineVirtualCamera frame4_cam;

    public CanvasGroup canvasGroupMainMenu;
    public CanvasGroup canvasGroupSettings;

    public GameObject SettingsUI;
    public GameObject MainMenuUI;

    private void Start()
    {
        //Changing the priority will make the camera x gradually move to camera y over time or instantly
        frame1_cam.Priority = 1;
        frame2_cam.Priority = 0;
    }

    public void Play()
    {
        frame1_cam.Priority = 0;
        frame2_cam.Priority = 1;
    }
    public void Back()
    {
        frame1_cam.Priority = 1;
        frame2_cam.Priority = 0;
        frame3_cam.Priority = 0;
        frame4_cam.Priority = 0;
    }

    public void LoadMenu()
    {
        frame1_cam.Priority = 0;
        frame4_cam.Priority = 1;
    }
    public void Settings()
    {
        frame1_cam.Priority = 0;
        frame3_cam.Priority = 1;
    }

}