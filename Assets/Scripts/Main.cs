using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;
using System.Linq;

namespace StringTest
{
    public class Main : MonoBehaviour
    {
        public TextMeshProUGUI TestText;
        public TextMeshProUGUI ResultText;

        public GameObject UI;

        int m_whichTest = 0;

        private void Awake()
        {
            ResultText.text = "Ready\n";
        }

        private void Start()
        {
            if (Screen.width > Screen.height)
                UI.GetComponent<CanvasScaler>().matchWidthOrHeight = 1.0f;
            else
                UI.GetComponent<CanvasScaler>().matchWidthOrHeight = 0.0f;

            TestText.text = "Time: + Time.time";
        }

        public void SwitchTest()
        {
            m_whichTest = (m_whichTest + 1) % 5;

            switch (m_whichTest)
            {
                case 0:
                    TestText.text = "Time: + Time.time";
                    break;
                case 1:
                    TestText.text = "String.Format(Time: {0}, Time.time)";
                    break;
                case 2:
                    TestText.text = "SetText(Time:  + Time.time)";
                    break;
                case 3:
                    TestText.text = "SetText(Time: {0}, Time.time)";
                    break;
                case 4:
                    TestText.text = "$Time: {Time.time}";
                    break;
            }
        }

        private void Update()
        {
            RunTest();
        }

        private void RunTest()
        {
            switch (m_whichTest)
            {
                case 0:
                    ResultText.text = "Time: " + Time.time;
                    break;
                case 1:
                    ResultText.text = String.Format("Time: {0}", Time.time);
                    break;
                case 2:
                    ResultText.SetText("Time: " + Time.time);
                    break;
                case 3:
                    ResultText.SetText("Time: {0}", Time.time);
                    break;
                case 4:
                    ResultText.text = $"Time: {Time.time}";
                    break;
            }
        }
    }
}