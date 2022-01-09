using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;
namespace BuilderPattern
{

    public class HtmlElement
    {
        public List<HtmlElement> Elements = new List<HtmlElement>();
        private const int indentSize = 2;
        public string Name, Text;
        public HtmlElement()
        {

        }

        public HtmlElement(string name, string text)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Text = text ?? throw new ArgumentNullException(nameof(text));
        }

        private string ToStringImpl(int indent)
        {
            var sb = new StringBuilder();
            var i = new string(' ', indentSize * indent);
            sb.AppendLine($"{i}<{Name}>");
            if (!string.IsNullOrWhiteSpace(Text))
            {
                sb.Append(new string(' ', indentSize * (indent + 1)));
                sb.AppendLine($"{Text}");
            }

            foreach(var e in Elements)
            {
                sb.AppendLine(e.ToStringImpl(indent + 1));
            }

            sb.Append($"{i}</{Name}>");
            return sb.ToString();
        }

        public override string ToString()
        {
            return ToStringImpl(0);
        }

    }

    public class HtmlBuilder
    {
        private readonly string rootName;
        HtmlElement root = new HtmlElement();
        public HtmlBuilder(string rootName)
        {
            root.Name = rootName;
            this.rootName = rootName;
        }

        public void AddChild(string  name,string text)
        {
            var e = new HtmlElement(name, text);
            root.Elements.Add(e);

        }
        public HtmlBuilder AddFluentChild(string name,string text)
        {
            var e = new HtmlElement(name, text);
            root.Elements.Add(e);
            return this;
        }

        public void Clear()
        {
            root = new HtmlElement() { Name=rootName};
           // root.Name = rootName;
        }

        public override string ToString()
        {
            return root.ToString();
        }
    }

    public class BuilderWithFluent
    {
        //static void Main(string[] args)
        //{
        //    var hello = "Hello";
        //    var sb = new StringBuilder();
        //    sb.Append($"<p>{hello}</p>");
        //    WriteLine(sb);
        //    var words = new[] { "hello", "world" };
        //    sb.Clear();
        //    sb.Append("<ul>");
        //    foreach(var word in words)
        //    {
        //        sb.Append($"<li>{word}</li>");

        //    }
        //    sb.Append("</ul>");

        //    WriteLine(sb);

        //    var builder = new HtmlBuilder("ul");
        //    builder.AddChild("li", "hello");
        //    builder.AddChild("li", "world");
        //    WriteLine(builder);

        //    sb.Clear();
        //    builder.Clear();
        //    builder.AddFluentChild("li", "hello").AddFluentChild("li","world");
        //    WriteLine(builder);
        //}
    }


}
