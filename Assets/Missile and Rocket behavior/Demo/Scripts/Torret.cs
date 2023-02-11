using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Missiles
{
    public class Torret : MonoBehaviour
    {
        public float rotateSpeed = 60.0f;

        public GameObject[] missileType;
        public Transform[] launchPositionTorret;

        public Transform[] launchPositionSide;

        public Transform[] launchPositionUp;
        public Transform[] launchPositionSideNormal;

        public GameObject explotionLaunchPrefab;

        float horizontal;
        int i = 0;

        private void Update()
        {

            horizontal = Input.GetAxis("Horizontal");

        }
        public void ShootTorret(int slotM)
        {
            if (i >= launchPositionTorret.Length) { i = 0; }
            if (i < launchPositionTorret.Length)
            {
                Instantiate(missileType[slotM], launchPositionTorret[i].position, launchPositionTorret[i].rotation);
                if (explotionLaunchPrefab) { Instantiate(explotionLaunchPrefab, launchPositionTorret[i].position, launchPositionTorret[i].rotation, gameObject.transform); }
                i++;
            }
        }
        public void ShootSideTorretNormalBullet(int slotM)
        {
            if (i >= launchPositionSideNormal.Length) { i = 0; }
            if (i < launchPositionSideNormal.Length)
            {
                Instantiate(missileType[slotM], launchPositionSideNormal[i].position, launchPositionSideNormal[i].rotation);
                if (explotionLaunchPrefab) { Instantiate(explotionLaunchPrefab, launchPositionSideNormal[i].position, launchPositionSideNormal[i].rotation, gameObject.transform); }
                i++;
            }
        }
        public void ShootSideTorret(int slotM)
        {
            if (i >= launchPositionSide.Length) { i = 0; }
            if (i < launchPositionSide.Length)
            {
                Instantiate(missileType[slotM], launchPositionSide[i].position, launchPositionSide[i].rotation);
                if (explotionLaunchPrefab) { Instantiate(explotionLaunchPrefab, launchPositionSide[i].position, launchPositionSide[i].rotation, gameObject.transform); }
                i++;
            }
        }

        public void ShootUpTorret(int slotM)
        {
            if (i >= launchPositionUp.Length) { i = 0; }
            if (i < launchPositionUp.Length)
            {
                Instantiate(missileType[slotM], launchPositionUp[i].position, launchPositionUp[i].rotation);
                i++;
            }
        }

        private void FixedUpdate()
        {
            transform.Rotate(new Vector3(0, horizontal, 0) * Time.deltaTime * rotateSpeed);
            if (transform.rotation.y >= Quaternion.Euler(0, 45, 0).y)
            {
                transform.rotation = Quaternion.Euler(0, 44, 0);
            }
            if (transform.rotation.y <= Quaternion.Euler(0, -45, 0).y)
            {
                transform.rotation = Quaternion.Euler(0, -44, 0);
            }

        }
    }
}


