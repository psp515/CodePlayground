using System;
namespace DesignPatterns.Command;

public class CommandHistory
{
	private Stack<Command> commands;

	public CommandHistory()
	{
		commands = new Stack<Command>();
	}

	public void Push(Command command) => commands.Push(command);

	public Command Pop() => commands.Pop();
}

