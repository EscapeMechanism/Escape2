using System;
using System.Xml;
using System.IO;
using System.Text;
using System.Collections;


public class HelloWorld {
	static public void Main (string[] args) {
		SvgShapeData sld = new SvgShapeData(@"/Users/simonhildebrandt/Desktop/test.svg");
		sld.NodesWithLabel ("block1");
  	}
}

