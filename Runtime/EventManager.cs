using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace com.victorafael.events
{
    public static class EventManager
    {
        private static Dictionary<string, UnityEvent> voidEvents;
        private static Dictionary<string, IntEvent> intEvents;
        private static Dictionary<string, StringEvent> stringEvents;
        private static Dictionary<string, ObjEvent> objEvents;

        private static bool initialized = false;

        private static void Initialize()
        {
            if (initialized)
            {
                return;
            }
            voidEvents = new Dictionary<string, UnityEvent>();
            intEvents = new Dictionary<string, IntEvent>();
            stringEvents = new Dictionary<string, StringEvent>();
            objEvents = new Dictionary<string, ObjEvent>();

            initialized = true;
        }
        public static void Clear()
        {
            voidEvents.Clear();
            intEvents.Clear();
            stringEvents.Clear();
            objEvents.Clear();
        }

        #region Void Events

        public static void Register(UnityAction action, params string[] events)
        {
            Initialize();
            foreach (var evt in events)
            {
                Register(evt, action);
            }
        }
        public static void Register(string eventKey, UnityAction action)
        {
            Initialize();
            if (voidEvents != null && !voidEvents.ContainsKey(eventKey))
                voidEvents.Add(eventKey, new UnityEvent());
            voidEvents[eventKey].AddListener(action);
        }

        public static void Unregister(UnityAction action, params string[] events)
        {
            Initialize();
            foreach (var evt in events)
            {
                Unregister(evt, action);
            }
        }

        public static void Unregister(string eventKey, UnityAction action)
        {
            Initialize();
            if (voidEvents != null && voidEvents.ContainsKey(eventKey))
                voidEvents[eventKey].RemoveListener(action);
        }

        public static void Trigger(string eventKey)
        {
            Initialize();
            if (voidEvents != null && voidEvents.ContainsKey(eventKey))
                voidEvents[eventKey].Invoke();
        }

        #endregion
        #region Int events
        private class IntEvent : UnityEvent<int> { }

        public static void Register(string eventKey, UnityAction<int> action)
        {
            Initialize();
            if (intEvents != null && !intEvents.ContainsKey(eventKey))
                intEvents.Add(eventKey, new IntEvent());
            intEvents[eventKey].AddListener(action);
        }
        public static void Unregister(string eventKey, UnityAction<int> action)
        {
            Initialize();
            if (intEvents != null && intEvents.ContainsKey(eventKey))
                intEvents[eventKey].RemoveListener(action);
        }
        public static void Trigger(string eventKey, int value)
        {
            Initialize();
            if (intEvents != null && intEvents.ContainsKey(eventKey))
                intEvents[eventKey].Invoke(value);
        }
        #endregion
        #region String events
        private class StringEvent : UnityEvent<string> { }

        public static void Register(string eventKey, UnityAction<string> action)
        {
            Initialize();
            if (stringEvents != null && !stringEvents.ContainsKey(eventKey))
                stringEvents.Add(eventKey, new StringEvent());
            stringEvents[eventKey].AddListener(action);
        }
        public static void Unregister(string eventKey, UnityAction<string> action)
        {
            Initialize();
            if (stringEvents != null && stringEvents.ContainsKey(eventKey))
                stringEvents[eventKey].RemoveListener(action);
        }
        public static void Trigger(string eventKey, string value)
        {
            Initialize();
            if (stringEvents != null && stringEvents.ContainsKey(eventKey))
                stringEvents[eventKey].Invoke(value);
        }
        #endregion

        #region Obj events
        private class ObjEvent : UnityEvent<object> { }

        public static void RegisterObj(string eventKey, UnityAction<object> action)
        {
            Initialize();
            if (objEvents != null && !objEvents.ContainsKey(eventKey))
                objEvents.Add(eventKey, new ObjEvent());
            objEvents[eventKey].AddListener(action);
        }
        public static void UnregisterObj(string eventKey, UnityAction<object> action)
        {
            Initialize();
            if (objEvents != null && objEvents.ContainsKey(eventKey))
                objEvents[eventKey].RemoveListener(action);
        }
        public static void TriggerObj(string eventKey, object value)
        {
            Initialize();
            if (objEvents != null && objEvents.ContainsKey(eventKey))
                objEvents[eventKey].Invoke(value);
        }
        #endregion
    }
}