using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Internal.Singleton;

using Manager;

using ui.ingame;
using ui.alertNotification;

namespace Manager
{
    public class UIManager : Singleton<UIManager>
    {
        [SerializeField] private InGameView inGameView;
        [SerializeField] private AlertNotificationView alertNotificationView;

        [SerializeField] private float alertVisibleTimer = 15f;

        // Start is called before the first frame update
        void Start()
        {
            if (GameManager.Instance.CurrentGameState == model.GameState.INGAME)
            {
                inGameView.gameObject.SetActive(true);
            }

            StartCoroutine(Coroutine_AlertNotificationVisible());
        }

        public void SetPlayerScore(int score)
        {
            if(inGameView)
                inGameView.SetScore(score);
        }

        public void SetAlertMessage(string _message)
        {
            if(alertNotificationView)
                alertNotificationView.SetMessage(_message);
        }

        public void SetAlertNotificationVisible(bool _visible)
        {
            if(alertNotificationView)
                alertNotificationView.gameObject.SetActive(_visible);
        }

        IEnumerator Coroutine_AlertNotificationVisible()
        {
            yield return new WaitForSeconds(alertVisibleTimer);
            SetAlertNotificationVisible(false);
            StopCoroutine(Coroutine_AlertNotificationVisible());
        }
    }
}