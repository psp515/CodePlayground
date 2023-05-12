using System;
namespace DesignPatterns.Command;

public abstract class Command
{
    protected Application app;
    protected Editor editor;
    protected string backup;

    public Command(Application application, Editor editor)
    {
        this.app = application;
        this.editor = editor;
    }

    public virtual void Save() => this.backup = editor.Text;
    
    public virtual void Undo() => editor.Text = backup;
    
    public abstract void Execute();
}

