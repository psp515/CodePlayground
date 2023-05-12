using System;
namespace DesignPatterns.Command;

public class CutCommand : Command
{
    public CutCommand(Application application, Editor editor) : base(application, editor)
    {
    }

    public override void Execute()
    {
        Save();
        app.Clipboard = editor.GetSelected();
        editor.DeleteSelected();
    }
}

