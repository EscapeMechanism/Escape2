using System;
using System.Xml;
using System.IO;
using System.Text;
using System.Collections;


public class SvgLevelData {
  ArrayList nodes;

  public SvgLevelData(string path) {
    nodes = new ArrayList();

    XmlDocument document = new XmlDocument();
    document.Load(path);
    XmlNamespaceManager nsmgr = new XmlNamespaceManager(document.NameTable);
    nsmgr.AddNamespace("svg", "http://www.w3.org/2000/svg");
    nsmgr.AddNamespace("inkscape", "http://www.inkscape.org/namespaces/inkscape");

    XmlNodeList tiles = document.SelectNodes("//svg:g[@inkscape:label='tiles']/svg:rect", nsmgr);

    IEnumerator ienum = tiles.GetEnumerator();
    XmlNode rect;
    while (ienum.MoveNext()) {
      rect = (XmlNode) ienum.Current;
      Console.WriteLine(rect.OuterXml);
      Console.WriteLine();

      nodes.Add(rect);
    }
  }
}


