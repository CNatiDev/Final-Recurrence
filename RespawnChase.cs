using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.AI;
public class RespawnChase : MonoBehaviour
{   //Variables
    #region Transforms
    public Transform Player;
    public Transform RespawnPoint;
    public Transform Enemy;
    public Transform EnemyRespawnPoint;
    #endregion
    public Image AttackImg;
    public Image CloseChaseImg;
    public AudioSource Audio;
    public AudioSource Audio1;
    public UnityEvent Event;
    public Transform CameraPlayer;
    //We use the function to calculate the position and rotation of the player and the enemy for respawn
    public void RespawanPlayer()
    {
        Event.Invoke();
        Player.position = new Vector3(RespawnPoint.position.x, RespawnPoint.position.y, RespawnPoint.position.z);
        Player.rotation = Quaternion.EulerAngles(RespawnPoint.rotation.x, RespawnPoint.rotation.y, RespawnPoint.rotation.z);
        Enemy.position = new Vector3(EnemyRespawnPoint.position.x, EnemyRespawnPoint.position.y, EnemyRespawnPoint.position.z);
        Enemy.localRotation = Quaternion.EulerAngles(EnemyRespawnPoint.localRotation.x, EnemyRespawnPoint.localRotation.y, EnemyRespawnPoint.localRotation.z);
        Enemy.gameObject.SetActive(false);
        AttackImg.gameObject.SetActive(false);
        //Player.gameObject.GetComponent<NavMeshAgent>().enabled = true;
    }
    public void StopAudio()
    {
        if(Audio != null)
        Audio.Stop();
        if(Audio1 != null)
        Audio1.enabled = false;
    }
    public void PlayAudio()
    {
        if (Audio1 != null)
            Audio1.Play();
    }
    public void IdleAnimation()
    {
        CloseChaseImg.gameObject.GetComponent<Animator>().Play("IdleState");
    }
    public void RespawanOPlayer()
    {

        Player.position = new Vector3(RespawnPoint.position.x, RespawnPoint.position.y, RespawnPoint.position.z);
        Player.rotation = Quaternion.EulerAngles(RespawnPoint.rotation.x, RespawnPoint.rotation.y, RespawnPoint.rotation.z);

    }
    public void RespawanOPlayerSiCamera()
    {

        Player.position = new Vector3(RespawnPoint.position.x, RespawnPoint.position.y, RespawnPoint.position.z);
        Player.rotation = Quaternion.EulerAngles(RespawnPoint.rotation.x, RespawnPoint.rotation.y, RespawnPoint.rotation.z);
        CameraPlayer.rotation = Quaternion.EulerAngles(CameraPlayer.rotation.x, RespawnPoint.rotation.y, CameraPlayer.rotation.z);
    }
}
