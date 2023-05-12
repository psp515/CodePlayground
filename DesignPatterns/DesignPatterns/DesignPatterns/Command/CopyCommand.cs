using System;
namespace DesignPatterns.Command;

public class CopyCommand : Command
{
    public CopyCommand(Application application, Editor editor) : base(application, editor)
    {
    }

    public override void Execute()
    {
        app.Clipboard = editor.GetSelected();
    }
}

