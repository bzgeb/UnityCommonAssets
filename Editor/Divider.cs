//
// Modified by Graeme Lennon <graeme.lennon@gmail.com> from https://gist.github.com/MattRix/5972828
//
// Based on a brilliant idea by Matthew Wegner - https://twitter.com/mwegner/status/355147544818495488
//
// [Divider]
// [Divider("My header")] 
// [Divider("My header", "My subtitle")] 
//

#if UNITY_EDITOR

using System;
using UnityEngine;
using UnityEditor;

public class Divider : PropertyAttribute  {
    public readonly string title;
    public readonly string subtitle;

    public Divider() : this("", "") {}
    public Divider( string title ) : this( title, "" ) {}
    public Divider( string title, string subtitle ) {
        this.title = title;
        this.subtitle = subtitle;
    }
}

[CustomPropertyDrawer (typeof(Divider))]
public class DividerDrawer : DecoratorDrawer {
    const float baseHeight = 0f; // Base divider height
    const float titleHeight = 20f;
    const float subtitleHeight = 11f;

    public override void OnGUI( Rect rect ) {
        Divider attr = attribute as Divider;

        float headerHeight = baseHeight;

        if ( attr.title != "" ) {
            headerHeight += titleHeight;
        }

        if ( attr.subtitle != "" ) {
            headerHeight += subtitleHeight;
        }

        // Title
        if ( attr.title != "" ) {
            rect.y += 8f;

            GUIStyle headerStyle = new GUIStyle (GUI.skin.label);
            headerStyle.fontSize = 12;
            headerStyle.fontStyle = FontStyle.Bold;

            EditorGUI.LabelField(rect,attr.title,headerStyle);

            rect.y += titleHeight - 8f;
        }

        // Subtitle
        if ( attr.subtitle != "" ) {
            rect.y += 3f;

            GUIStyle subtitleStyle = new GUIStyle (GUI.skin.label);
            subtitleStyle.fontSize = 9;
            subtitleStyle.fontStyle = FontStyle.Italic;

            EditorGUI.LabelField(rect,attr.subtitle,subtitleStyle);

            rect.y += subtitleHeight - 3f;
        }

        /* Divider */
        //draw the divider
        if ( Event.current.type == EventType.Repaint) {
            GUIStyle dividerStyle = new GUIStyle();
            dividerStyle.normal.background = EditorGUIUtility.whiteTexture;
            Color dividerColor = EditorGUIUtility.isProSkin ? new Color(0.157f, 0.157f, 0.157f) : new Color(0.5f, 0.5f, 0.5f);
            Color restoreColor = GUI.color;

            rect.y += 7f;
            rect.height = 1f;

            GUI.color = dividerColor;
            dividerStyle.Draw(rect, false, false, false, false);
            GUI.color = restoreColor;
        }
    }

    public override float GetHeight () {
        Divider attr = attribute as Divider;

        float headerHeight = baseHeight;
        
        if ( attr.title != "" ) {
            headerHeight += titleHeight;
        }

        if ( attr.subtitle != "" ) {
            headerHeight += subtitleHeight;
        }

        return base.GetHeight() + headerHeight;
    }

}

#else

using System;
using UnityEngine;

public class Divider : PropertyAttribute 
{
    public string header;
    public string subtitle;

    public Divider( string header, string subtitle ) {}
    public Divider( string header ) {}
    public Divider() {}
}

#endif