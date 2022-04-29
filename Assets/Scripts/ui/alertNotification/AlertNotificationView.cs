using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

namespace ui.alertNotification
{
    public class AlertNotificationView : MonoBehaviour
    {

        [SerializeField] private TMP_Text txtMessage;

        public void SetMessage(string _message)
        {
            txtMessage.text = _message;
        }
    }
}