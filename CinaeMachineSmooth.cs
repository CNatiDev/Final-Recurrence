using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CinaeMachineSmooth : MonoBehaviour
{
    public CinemachineBrain Brain;
    public void SetBrain()
    {
        Brain.m_DefaultBlend.m_Style = CinemachineBlendDefinition.Style.Cut;
    }
    public void SetDefaultBrain()
    {
        Brain.m_DefaultBlend.m_Style = CinemachineBlendDefinition.Style.EaseInOut;
    }

}
