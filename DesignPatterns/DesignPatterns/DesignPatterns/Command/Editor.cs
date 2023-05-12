using System;
namespace DesignPatterns.Command;

public class Editor
{
	private string text;
	public string Text { get => text; set => text = value; }

	public Editor()
	{
	}

	public string GetSelected() => text;

	public void DeleteSelected() => text = "";
	public string ReplaceSelected(string newText) => text = newText;
}

