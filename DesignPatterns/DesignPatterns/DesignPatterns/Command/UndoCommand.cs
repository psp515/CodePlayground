using System;
namespace DesignPatterns.Command;

public class UndoCommand : Command
{
    public UndoCommand(Application application, Editor editor) : base(application, editor)
    {
    }

    public override void Execute()
    {
        app.UndoCommand();
    }
}

