using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : Singleton<EventManager>
{
   public Dictionary<EventId, List <Action>> subscriber = new Dictionary<EventId, List <Action>>();
    public Messages msg;
   protected override void Awake()
   { 
      DontDestroyOnLoad(this.gameObject);
   }
   public void SendEvent(EventId eventId, Messages message)
   { 
      
    List<Action> sub;
      if (subscriber.TryGetValue(eventId, out sub))
      {
         foreach (Action item in sub)
         {
            msg = message;
           // Debug.Log($"MESSAGE Name= {msg.Character.name}, Clip = {msg.Clip.name} ");
            item.Invoke();
           
         }
      }
     
   }

   public void Sub(EventId eventId, Action action)
   {
      List<Action> subs;
      if (!subscriber.TryGetValue(eventId, out subs))
      {
         subs = new List<Action>();
         subscriber[eventId] = subs;
      }
      subs.Add(action);
   }
   
   public void UnSub(EventId eventId, Action action)
   {
      List<Action> sub = subscriber[eventId];
      sub.Remove(action);
     
   }
  

}
