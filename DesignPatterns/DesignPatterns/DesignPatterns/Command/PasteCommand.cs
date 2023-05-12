using System;
namespace DesignPatterns.Command;

public class PasteCommand : Command
{
    public PasteCommand(Application application, Editor editor) : base(application, editor)
    {
    }

    public override void Execute()
    {
        Save();
        editor.ReplaceSelected(app.Clipboard);
    }
}

