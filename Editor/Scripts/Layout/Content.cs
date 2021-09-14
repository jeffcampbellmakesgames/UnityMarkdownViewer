using System.ComponentModel;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;

namespace MG.MDV
{

    public class HyperlinkOpenEventArgs : CancelEventArgs
    {

        public HyperlinkOpenEventArgs(string hyperlink, bool isMarkdownFile, Context context)
        {
            Hyperlink = hyperlink;
            IsMarkdownFile = isMarkdownFile;
            Context = context;
        }

        public string Hyperlink { get; }
        public bool IsMarkdownFile { get; }
        public Context Context { get; }

    }

    public class HyperlinkHelper
    {

        public delegate void OnHyperlinkOpened(HyperlinkOpenEventArgs e);

        public static event OnHyperlinkOpened HyperlinkOpened;

        internal static void OnHyperlink(string hyperlink, bool isMarkdownFile, Context context, out bool cancelDefault)
        {
            var e = new HyperlinkOpenEventArgs(hyperlink, isMarkdownFile, context);
            HyperlinkOpened?.Invoke(e);
            cancelDefault = e.Cancel;
        }

    }

    public abstract class Content
    {
        public Rect Location;
        public Style Style;
        public GUIContent Payload;
        public string Link;

        public float Width { get { return Location.width; } }
        public float Height { get { return Location.height; } }
        public bool CanUpdate { get { return false; } }

        public Content(GUIContent payload, Style style, string link)
        {
            Payload = payload;
            Style = style;
            Link = link;
        }

        public void CalcSize(Context context)
        {
            Location.size = context.CalcSize(Payload);
        }

        public void Draw(Context context)
        {

            if (!string.IsNullOrEmpty(Link))
            {
                EditorGUIUtility.AddCursorRect(Location, MouseCursor.Link);
            }

            if (string.IsNullOrEmpty(Link))
            {
                GUI.Label(Location, Payload, context.Apply(Style));
            }
            else if (GUI.Button(Location, Payload, context.Apply(Style)))
            {

                var isMarkdownFile = !Regex.IsMatch(Link, @"^\w+:", RegexOptions.Singleline);
                HyperlinkHelper.OnHyperlink(Link, isMarkdownFile, context, out bool cancelDefault);
                if (cancelDefault)
                    return;

                if (!isMarkdownFile)
                {
                    Application.OpenURL(Link);
                }
                else
                {
                    context.SelectPage(Link);
                }
            }
        }

        public virtual void Update(Context context)
        {
        }
    }
}

