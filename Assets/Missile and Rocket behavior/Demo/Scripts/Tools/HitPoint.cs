using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

namespace Missiles
{
    public class HitPoint : MonoBehaviour
    {
        public float MaxHitPoint = 100;
        public float CurrentPoint;
        public GameObject PopUpPrefab;
        public GameObject PointBars;
        public Image CurrentHitPoint;

        private float _hitRatio;

        private void Start()
        {
            CurrentPoint = MaxHitPoint;
        }

        private void UpdatePointsBars()
        {
            _hitRatio = CurrentPoint / MaxHitPoint;
            CurrentHitPoint.rectTransform.localScale = new Vector3(_hitRatio, 1, 1);
        }

        public void ApplyDamage(float amount)
        {
            CurrentPoint -= amount;
            UpdatePointsBars();
            InstancePopUp(amount.ToString(CultureInfo.InvariantCulture));
            if (!(CurrentPoint <= 0)) return;
            CurrentPoint = 0;
            Dead();
        }

        //instance the popUp text
        //You can change this to text mesh pro or another GUI solutions.
        private void InstancePopUp(string popUpText)
        {
            var poPupText =
                Instantiate(PopUpPrefab, transform.position + Random.insideUnitSphere * 0.4f,
                    transform.rotation);
            Destroy(poPupText, 3);
            poPupText.transform.GetChild(0).GetComponent<TextMesh>().text = popUpText;
        }

        private void Dead()
        {
            Enemy enemyController = GetComponent<Enemy>();
            if (enemyController)
            {
                enemyController.Dead();
            }
        }
    }
}