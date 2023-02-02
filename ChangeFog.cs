using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ChangeFog : MonoBehaviour
{
    public float time;
    public void ChangeFogMode()
    {
        RenderSettings.fogMode = FogMode.Linear;
        RenderSettings.fogStartDistance = -150;
        RenderSettings.fogEndDistance = 500;
        Debug.Log("fofofofofowfeaslfewhafhiqehsuvihqeo");
    }
    public void ChangeFogBlack()
    {
        RenderSettings.fogColor = new Color(0, 0, 0, 1);
    }
    public void ChangeFogGrey()
    {
        StartCoroutine(changeFog());
    }
    public void ChangeFogBlackWithTime()
    {
        StartCoroutine(changeFogWithTime(3f));
    }
    IEnumerator changeFogWithTime(float time)
    {
        float timeElapsed = 0, timeToPass = time;
        Color color1 = new Color(0.06603771f, 0.06603771f, 0.06603771f, 1);
        Color color2 = new Color(0, 0, 0, 1);
        while (timeElapsed < timeToPass)
        {
            RenderSettings.fogColor = Color.Lerp(color1, color2, timeElapsed);
            timeElapsed += Time.fixedDeltaTime;
            yield return null;
        }
        RenderSettings.fogColor = color1;
        yield return null;
    }
    IEnumerator changeFog()
    {
        float timeElapsed = 0, timeToPass = 3f;
        Color color1 = new Color(0f, 0f, 0f, 1);
        Color color2 = new Color(0.06603771f, 0.06603771f, 0.06603771f, 1);
        while (timeElapsed < timeToPass)
        {
            RenderSettings.fogColor = Color.Lerp(color1, color2, timeElapsed);
            timeElapsed += Time.fixedDeltaTime;
            yield return null;
        }
        RenderSettings.fogColor = color2;
        yield return null;
    }
}
