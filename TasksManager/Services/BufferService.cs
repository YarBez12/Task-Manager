using CommunityToolkit.Mvvm.ComponentModel;

namespace TasksManager.Services;

public partial class BufferService
{

    public void Copy<T>(T data)
    {
        App.Buffer.Copy<T>(data);
    }

    public T Paste<T>() where T : class
    {
        return App.Buffer.Paste<T>();
    }

    public void Clear()
    {
        App.Buffer.Clear();
    }
}