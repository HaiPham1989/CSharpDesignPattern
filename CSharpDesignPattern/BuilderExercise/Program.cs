using System;
using System.Collections.Generic;
using System.Text;

namespace BuilderExercise
{
    public class CSElement
    {
        public string sName;
        public string sType;

        //child elements
        public List<CSElement> Elements = new List<CSElement>();
        private const int nOneIndentLength = 2;

        public CSElement(string sElementName, string sElementType)
        {
            this.sName = sElementName;
            this.sType = sElementType;
        }

        private string ToStringWithIndent(int indentCount)
        {
            var stringBuild = new StringBuilder();
            var indent = new string(' ', CSElement.nOneIndentLength * indentCount);
            if (Elements.Count > 0)
            {
                stringBuild.AppendLine($"{indent}public {sType} {sName}");
                stringBuild.AppendLine("{");
            }
            else
            {
                stringBuild.Append($"{indent}public {sType} {sName}");
                stringBuild.AppendLine(";");
            }

            foreach (var csElement in Elements)
            {
                stringBuild.Append(csElement.ToStringWithIndent(indentCount + 1));
            }

            if (Elements.Count > 0)
                stringBuild.AppendLine("}");

            return stringBuild.ToString();
        }

        public override string ToString()
        {
            return ToStringWithIndent(0);
        }
    }

    public class CodeBuilder
    {
        private CSElement rootElement;

        public CodeBuilder(string classname)
        {
            rootElement = new CSElement("Foo", "class");
        }

        public CodeBuilder AddField(string sName, string sType)
        {
            rootElement.Elements.Add(new CSElement(sName, sType));
            return this;
        }

        public override string ToString()
        {
            return rootElement.ToString();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var cb = new CodeBuilder("Foo").AddField("Name", "string").AddField("Age", "int");
            Console.WriteLine(cb);
        }
    }
}
