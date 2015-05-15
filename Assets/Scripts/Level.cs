/*
using System.Collections;
using System.Linq;
using UnityEngine.UI;
*/
using UnityEngine;
using System;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

[System.Serializable]
public class Level {
	[XmlArray("Blocks"),XmlArrayItem("Block")]
	public Block[] blocks;
	public string name;
	
	public Level (string filename) {
		name = filename;
	}
	
	public Level () {
	}
	
	static XmlSerializer serializer() {
		return new XmlSerializer(typeof(Level));
	}
	
	public static Level load(string name) {
		if (!File.Exists(path(name))) { return null; }
		
		FileStream stream = new FileStream(path(name), FileMode.Open);
		StreamReader reader = new StreamReader(stream, new UTF8Encoding());
		Level level = serializer().Deserialize(reader) as Level;
		stream.Close();
		return level;
	}
	
	public void save() {
		FileStream stream = new FileStream(path(), FileMode.Create);
		TextWriter writer = new StreamWriter(stream, new UTF8Encoding());
		serializer ().Serialize (writer, this);
		stream.Close();
	}
	
	public string path() {
		return Level.path(name);
	}
	
	public static string path(string filename) {
		return String.Format ("{0}/{1}.xml", Application.persistentDataPath, filename);
	}
	
}

[System.Serializable]
public class Block : System.Object {
	
	public float x;
	public float y;
	public String prefab;
	
	public Block() {}
	public Block(Vector3 position, string dprefab) {
		x = position.x; y = position.y; prefab = dprefab;
	}
	
	public Vector3 position() {
		return new Vector3 (x, y, 0);
	}
}
