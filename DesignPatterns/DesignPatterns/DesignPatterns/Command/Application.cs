using System;
namespace DesignPatterns.Command;

public class Application
{
	private string clipboard;
	public string Clipboard { get => clipboard; set => clipboard = value; }

	private Editor activeEditor;
	private List<Editor> editors;
	private CommandHistory commandHistory;

	public Application()
	{
		activeEditor = new Editor();
		editors = new List<Editor>();
		commandHistory = new CommandHistory();
	}

	public void CreateUI() { }

	public void ExecuteCommand(Command command)
	{
		command.Execute();
		commandHistory.Push(command);
	}

	public void UndoCommand()
	{
		var command = commandHistory.Pop();

		if(command != null)
			command.Undo();
	}
}

