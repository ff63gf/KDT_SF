using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppDelegate
{
    public delegate void EventDelegate(string message);

    public partial class FormPractice : Form
    {
        public FormPractice()
        {
            InitializeComponent();

            EventManager eventManager = new EventManager();

            eventManager.RegisterEvent("Event1", Method1);
            eventManager.RegisterEvent("Event1", Method2);
            eventManager.RegisterEvent("Event2", Method3);

            eventManager.TriggerEvent("Event1", "Hello from Event1");
            eventManager.TriggerEvent("Event2", "Hello from Event2");
        }

        public static void Method1(string message)
        {
            MessageBox.Show("Method1 received: " + message);
        }
        public static void Method2(string message)
        {
            MessageBox.Show("Method2 received: " + message);
        }
        public static void Method3(string message)
        {
            MessageBox.Show("Method3 received: " + message);
        }
    }

    public class EventManager
    {
        private Dictionary<string, EventDelegate> eventDictionary;

        public EventManager()
        {
            eventDictionary = new Dictionary<string, EventDelegate>();
        }

        public void RegisterEvent(string eventName, EventDelegate eventMethod)
        {
            if (eventDictionary.ContainsKey(eventName))
            {
                eventDictionary[eventName] += eventMethod;
            }
            else
            {
                eventDictionary[eventName] = eventMethod;
            }
        }

        public void UnregisterEvent(string eventName, EventDelegate eventMethod)
        {
            if (eventDictionary.ContainsKey(eventName))
            {
                eventDictionary[eventName] -= eventMethod;
            }
        }

        public void TriggerEvent(string eventName, string message)
        {
            if (eventDictionary.ContainsKey(eventName) && eventDictionary[eventName] != null)
            {
                eventDictionary[eventName].Invoke(message);
            }
        }
    }

}
