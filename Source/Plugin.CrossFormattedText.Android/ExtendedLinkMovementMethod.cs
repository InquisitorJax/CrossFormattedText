using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Text;
using Android.Text.Method;
using Android.Views;
using Android.Widget;

namespace Plugin.CrossFormattedText {
    public class ExtendedLinkMovementMethod : LinkMovementMethod {

        private static ExtendedLinkMovementMethod _instance;
        public static new ExtendedLinkMovementMethod Instance {
            get {
                if(_instance == null) {
                    _instance = new ExtendedLinkMovementMethod();
                }
                return _instance;
            }
        }

        private CommandableSpan currentSpan;

        public override bool OnTouchEvent(TextView widget,ISpannable buffer,MotionEvent e) {
            var action = e.Action;

            if(action == MotionEventActions.Up || action == MotionEventActions.Down) {
                int x = (int)e.GetX() - widget.TotalPaddingLeft + widget.ScrollX;
                int y = (int)e.GetY() - widget.TotalPaddingTop + widget.ScrollY;
                var layout = widget.Layout;
                int line = layout.GetLineForVertical(y);
                int off = layout.GetOffsetForHorizontal(line,x);

                var span = buffer.GetSpans(off,off,Java.Lang.Class.FromType(typeof(CommandableSpan))).OfType<CommandableSpan>().FirstOrDefault();

                if(span != null) {
                    if(action == MotionEventActions.Up) {
                        span.OnClick(widget);
                        span.IsHighlight = false;
                    } else if(action == MotionEventActions.Down) {
                        span.IsHighlight = true;
                    }
                    widget.Invalidate();
                    currentSpan = span;
                    return true;
                } else {
                    if(currentSpan != null) {
                        currentSpan.IsHighlight = false;
                        currentSpan = null;
                        widget.Invalidate();
                    }
                }
            }
            base.OnTouchEvent(widget,buffer,e);
            return false;
        }

    }
}