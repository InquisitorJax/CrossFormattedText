﻿using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Plugin.CrossFormattedText.Abstractions;

namespace Test.CrossFormattedText.Unit {

    [TestClass]
    public class FormattedStringBuilderTest {

        [TestMethod]
        public void AppendTest() {
            var sb = new StringBuilder();
            var fsb = new FormattedStringBuilder();

            sb.Append(true);
            fsb.Append(true);
            sb.Append((byte)10);
            fsb.Append((byte)10);
            sb.Append((decimal)10.0);
            fsb.Append((decimal)10.0);
            sb.Append(3.14);
            fsb.Append(3.14);
            sb.Append(3.14f);
            fsb.Append(3.14f);
            sb.Append((short)10);
            fsb.Append((short)10);
            sb.Append(19);
            fsb.Append(19);
            sb.Append(1L);
            fsb.Append(1L);
            sb.Append((object)"aaa");
            fsb.Append((object)"aaa");
            sb.Append('1');
            fsb.Append('1');
            sb.Append("text text");
            fsb.Append("text text");

            Assert.AreEqual(fsb.ToFormattedString().Text,sb.ToString());
        }

        [TestMethod]
        public void AppendLineTest() {
            var sb = new StringBuilder();
            var fsb = new FormattedStringBuilder();

            sb.AppendLine();
            fsb.AppendLine();
            sb.AppendLine("aaa");
            fsb.AppendLine("aaa");

            Assert.AreEqual(fsb.ToFormattedString().Text,sb.ToString());
        }

        [TestMethod]
        public void ClearTest() {
            var sb = new StringBuilder();
            var fsb = new FormattedStringBuilder();

            sb.AppendLine();
            fsb.AppendLine();
            sb.Append("aaa");
            fsb.Append("aaa");
            sb.Clear();
            fsb.Clear();

            Assert.AreEqual(fsb.Length,sb.Length);
            Assert.AreEqual(fsb.ToFormattedString().Text,sb.ToString());

            sb.Append("aaa");
            fsb.Append("aaa");

            Assert.AreEqual(fsb.ToFormattedString().Text,sb.ToString());
        }

        [TestMethod]
        public void InsertTest() {
            var sb = new StringBuilder();
            var fsb = new FormattedStringBuilder();

            sb.Append("abcdefghijk");
            fsb.Append("abcdefghijk");

            sb.Insert(3,true);
            fsb.Insert(3,true);
            sb.Insert(3,(byte)10);
            fsb.Insert(3,(byte)10);
            sb.Insert(3,(decimal)10.0);
            fsb.Insert(3,(decimal)10.0);
            sb.Insert(3,3.14);
            fsb.Insert(3,3.14);
            sb.Insert(3,3.14f);
            fsb.Insert(3,3.14f);
            sb.Insert(3,(short)10);
            fsb.Insert(3,(short)10);
            sb.Insert(3,19);
            fsb.Insert(3,19);
            sb.Insert(3,1L);
            fsb.Insert(3,1L);
            sb.Insert(3,(object)"aaa");
            fsb.Insert(3,(object)"aaa");
            sb.Insert(3,'c');
            fsb.Insert(3,'c');
            sb.Insert(3,"sfg");
            fsb.Insert(3,"sfg");

            Assert.AreEqual(fsb.ToFormattedString().Text,sb.ToString());
        }

        [TestMethod]
        public void RemoveTest() {
            var sb = new StringBuilder();
            var fsb = new FormattedStringBuilder();

            sb.Append("abcdefghijk");
            fsb.Append("abcdefghijk");

            sb.Remove(0,2);
            fsb.Remove(0,2);

            Assert.AreEqual(fsb.ToFormattedString().Text,sb.ToString());

            sb.Remove(sb.Length - 3,3);
            fsb.Remove(fsb.Length - 3,3);

            Assert.AreEqual(fsb.ToFormattedString().Text,sb.ToString());
            Assert.AreEqual(fsb.Length,sb.Length);
        }

        [TestMethod]
        public void ReplaceTest() {
            var sb = new StringBuilder();
            var fsb = new FormattedStringBuilder();

            sb.Append("ashgilassfianvlaih");
            fsb.Append("ashgilassfianvlaih");
            sb.Replace('a','b');
            fsb.Replace('a','b');

            Assert.AreEqual(fsb.ToFormattedString().Text,sb.ToString());

            sb.Clear();
            fsb.Clear();
            sb.Append("aaaaaaaaaaaaaaaaaaaaaaaaa");
            fsb.Append("aaaaaaaaaaaaaaaaaaaaaaaaa");
            sb.Replace('a','b',2,4);
            fsb.Replace('a','b',2,4);

            Assert.AreEqual(fsb.ToFormattedString().Text,sb.ToString());

            sb.Clear();
            fsb.Clear();
            sb.Append("aaaaaaaaaaaaaaaaaaaaaaaaa");
            fsb.Append("aaaaaaaaaaaaaaaaaaaaaaaaa");
            sb.Replace("a","[]");
            fsb.Replace("a","[]");

            Assert.AreEqual(fsb.ToFormattedString().Text,sb.ToString());
            Assert.AreEqual(fsb.Length,sb.Length);

            sb.Replace("[]","a");
            fsb.Replace("[]","a");

            Assert.AreEqual(fsb.ToFormattedString().Text,sb.ToString());
            Assert.AreEqual(fsb.Length,sb.Length);

            sb.Replace("aaa","b");
            fsb.Replace("aaa","b");

            Assert.AreEqual(fsb.ToFormattedString().Text,sb.ToString());
            Assert.AreEqual(fsb.Length,sb.Length);

            sb.Replace("b","a",1,2);
            fsb.Replace("b","a",1,2);

            Assert.AreEqual(fsb.ToFormattedString().Text,sb.ToString());
            Assert.AreEqual(fsb.Length,sb.Length);

            sb.Replace("a","");
            fsb.Replace("a","");

            Assert.AreEqual(fsb.ToFormattedString().Text,sb.ToString());
            Assert.AreEqual(fsb.Length,sb.Length);

            sb.Clear();
            fsb.Clear();
            sb.Append("aaaaaaaaaaaaaaaaaaaaaaaaa");
            fsb.Append("aaaaaaaaaaaaaaaaaaaaaaaaa");
            sb.Replace("c","[]");
            fsb.Replace("c","[]");

            Assert.AreEqual(fsb.ToFormattedString().Text,sb.ToString());
            Assert.AreEqual(fsb.Length,sb.Length);
        }
    }
}
