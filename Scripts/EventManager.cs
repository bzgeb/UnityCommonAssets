using UnityEngine;
using System.Collections.Generic;

public static class EventManager
{
    public delegate void EventHandler( params object[] args );

    static Dictionary<string, List<EventHandler>> events = new Dictionary<string, List<EventHandler>>();


    static public void CreateEvent( string eventName ) {
        if ( events.ContainsKey( eventName ) ) {
            return;
        }

        List<EventHandler> newEvent = new List<EventHandler>();
        events.Add( eventName, newEvent );
    }

    static public void Register( string eventName, EventHandler callback ) {
        if ( !events.ContainsKey( eventName ) ) {
            CreateEvent( eventName );
        }

        events[eventName].Add( callback );
    }

    static public void Deregister( string eventName, EventHandler callback ) {
        if ( !events.ContainsKey( eventName ) ) {
            return;
        }

        events[eventName].Remove( callback );
    }

    static public void Push( string eventName, params object[] args ) {
        if ( !events.ContainsKey( eventName ) ) {
            CreateEvent( eventName );
        }

        EventHandler[] callbacks = events[eventName].ToArray();

        foreach ( EventHandler callback in callbacks ) {
            callback( args );
        }
    }
}