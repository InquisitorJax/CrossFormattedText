﻿using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Plugin.CrossFormattedText.Abstractions;

namespace Test.CrossFormattedText.Unit {
    
    [TestClass]
    public class FormattedStringTest {

        private static readonly FormattedString text = new FormattedString(new Span[] {
            new Span() {
                Text = "This is sample text."
            },
            new Span() {
                Text = "\n"
            },
            new Span() {
                Text = "This is test text."
            },
            new Span() {
                Text = "\n"
            },
            new Span() {
                Text = "This is text."
            }
        });
        
        [TestMethod]
        public void ContainsSpanTest() {
            Span span1 = new Span() {
                Text = "This is text."
            };
            Span span2 = new Span() {
                Text = "That is text."
            };
            Assert.AreEqual(text.ContainsSpan(span1),true);
            Assert.AreEqual(text.ContainsSpan(span2),false);
        }

        [TestMethod]
        public void EndsWithSpanTest() {
            Span span1 = new Span() {
                Text = "This is text."
            };
            Span span2 = new Span() {
                Text = "That is text."
            };
            Assert.AreEqual(text.EndsWithSpan(span1),true);
            Assert.AreEqual(text.EndsWithSpan(span2),false);
        }

        [TestMethod]
        public void IndexOfSpanTest() {
            Span span1 = new Span() {
                Text = "This is sample text."
            };
            Span span2 = new Span() {
                Text = "This is text."
            };
            Span span3 = new Span() {
                Text = "That is text."
            };
            Assert.AreEqual(text.IndexOfSpan(span1),0);
            Assert.AreEqual(text.IndexOfSpan(span2),4);
            Assert.AreEqual(text.IndexOfSpan(span1,1),-1);
            Assert.AreEqual(text.IndexOfSpan(span2,0,1),-1);
            Assert.AreEqual(text.IndexOfSpan(span3),-1);
        }

        [TestMethod]
        public void InsertTest() {
            string s = " That is text.";

            var newText1 = text.Insert(20,s);
            var newString1 = text.Text.Insert(20,s);
            var newText2 = text.Insert(20,s,SpanOperand.Left);
            var newString2 = text.Text.Insert(20,s);
            Assert.AreEqual(newText1[1].Text.StartsWith(s),true);
            Assert.AreEqual(newText2[0].Text.EndsWith(s),true);
            Assert.AreEqual(newText1.Length,text.Length);
            Assert.AreEqual(newText2.Length,text.Length);
            Assert.AreEqual(newText1.Text,newString1);
            Assert.AreEqual(newText2.Text,newString2);
            Assert.AreEqual(text.AnySpanReferenceEquals(newText1),false);
            Assert.AreEqual(text.AnySpanReferenceEquals(newText2),false);            
        }

        [TestMethod]
        public void InsertSpanTest() {
            string s = " That is text.";

            Span span = new Span() {
                Text = s
            };
            var newText = text.InsertSpan(1,span);
            Assert.AreEqual(newText[1].Equals(span),true);
            Assert.AreEqual(newText.Length,text.Length + 1);
            Assert.AreEqual(text.AnySpanReferenceEquals(newText),false);
        }

        [TestMethod]
        public void LastIndexOfSpanTest() {
            Span span1 = new Span() {
                Text = "This is sample text."
            };
            Span span2 = new Span() {
                Text = "This is text."
            };
            Span span3 = new Span() {
                Text = "That is text."
            };
            Assert.AreEqual(text.LastIndexOfSpan(span1),0);
            Assert.AreEqual(text.LastIndexOfSpan(span2),4);
            Assert.AreEqual(text.LastIndexOfSpan(span1,1),0);
            Assert.AreEqual(text.LastIndexOfSpan(span2,1,1),-1);
            Assert.AreEqual(text.LastIndexOfSpan(span3),-1);
        }

        [TestMethod]
        public void RemoveTest() {
            var newText1 = text.Remove(1);
            var newText2 = text.Remove(1,text.TextLength-2);

            Assert.AreEqual(newText1.TextLength,1);
            Assert.AreEqual(newText2.TextLength,2);
            Assert.AreEqual(newText1.Text,"T");
            Assert.AreEqual(newText2.Text,"T.");
            Assert.AreEqual(newText1.AnySpanReferenceEquals(text),false);
            Assert.AreEqual(newText2.AnySpanReferenceEquals(text),false);
        }

        [TestMethod]
        public void RemoveSpanTest() {
            var newText1 = text.RemoveSpan(1);
            var newText2 = text.RemoveSpan(1,text.Length - 2);

            Assert.AreEqual(newText1.Length,1);
            Assert.AreEqual(newText2.Length,2);
            Assert.AreEqual(newText1[0].Equals(text[0]),true);
            Assert.AreEqual(newText2[0].Equals(text[0]),true);
            Assert.AreEqual(newText2[1].Equals(text[text.Length - 1]),true);
            Assert.AreEqual(newText1.AnySpanReferenceEquals(text),false);
            Assert.AreEqual(newText2.AnySpanReferenceEquals(text),false);
        }

        [TestMethod]
        public void ReplaceTest() {
            var newText1 = text.Replace('i','1');
            Assert.AreEqual(newText1.Text,text.Text.Replace('i','1'));
            Assert.AreEqual(newText1.AnySpanReferenceEquals(text),false);

            var newText2 = text.Replace("t","tt");
            var newText3 = text.Replace("1",(string)null);
            var newText4 = text.Replace("t",(string)null);
            Assert.AreEqual(newText2.Text,text.Text.Replace("t","tt"));
            Assert.AreEqual(newText2.AnySpanReferenceEquals(text),false);
            Assert.AreEqual(newText3.Text,text.Text);
            Assert.AreEqual(newText3.AnySpanReferenceEquals(text),false);
            Assert.AreEqual(newText4.Text,text.Text.Replace("t",null));
            Assert.AreEqual(newText4.AnySpanReferenceEquals(text),false);
        }

        [TestMethod]
        public void ReplaceSpanTest() {
            Span span = new Span() {
                Text = "This is text."
            };

            FormattedString newText = text.ReplaceSpan(span,new Span());

            Assert.AreEqual(newText.Length,text.Length);
            Assert.AreEqual(newText.Text,text.Text.Replace(span.Text,null));
            Assert.AreEqual(newText.AnySpanReferenceEquals(text),false);
        }
    }
}
