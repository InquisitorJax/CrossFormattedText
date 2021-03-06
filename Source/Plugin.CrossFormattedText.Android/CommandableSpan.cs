﻿using System;
using System.Windows.Input;
using Android.Graphics;
using Android.Text;
using Android.Text.Style;
using Android.Views;

namespace Plugin.CrossFormattedText {
    class CommandableSpan : ClickableSpan {

        public bool IsHighlight { get; set; }
        private ICommand command;
        private object commandParameter;

        public CommandableSpan(ICommand command,object commandParameter) {
            this.command = command;
            this.commandParameter = commandParameter;
        }

        public override void OnClick(View widget) {
            if(command.CanExecute(commandParameter) == false) {
                return;
            }
            command.Execute(commandParameter);
        }

        public override void UpdateDrawState(TextPaint ds) {
            if(IsHighlight) {
                ds.BgColor = Color.ParseColor("#ff33b5e5");
            }
        }
    }
}