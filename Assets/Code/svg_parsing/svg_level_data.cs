using System;
using System.Xml;
using System.IO;
using System.Text;
using System.Collections;


public class SvgShapeData {
	XmlNamespaceManager nsmgr;
	XmlDocument document;

	public SvgShapeData(string path) {
		document = new XmlDocument ();
		document.Load (path);
		nsmgr = new XmlNamespaceManager (document.NameTable);
		nsmgr.AddNamespace ("svg", "http://www.w3.org/2000/svg");
		nsmgr.AddNamespace ("inkscape", "http://www.inkscape.org/namespaces/inkscape");
	}

	public ArrayList NodesWithLabel(String label) {
		ArrayList nodes = new ArrayList ();
		String xpath = "//svg:rect[@inkscape:label='{0}']";
		XmlNodeList shapes = document.SelectNodes(String.Format(xpath, label), nsmgr);

		IEnumerator ienum = shapes.GetEnumerator(); 
		XmlNode shape;
		while (ienum.MoveNext()) {
			shape = (XmlNode) ienum.Current;
			Console.WriteLine(shape.OuterXml);
			Console.WriteLine();
			nodes.Add(shape);
		}

		return nodes;
	}
}


