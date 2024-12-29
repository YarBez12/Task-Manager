namespace TasksManager.Models;

public class Buffer 
{
    private object? _buffer;
    public bool HasCopy()
    {
        return _buffer is not null;
    }
    
    public void Copy<T>(T data)
    {
        _buffer = data;
    }

    public T Paste<T>() where T : class
    {
        if (_buffer is T)
        {
            return (T)_buffer;
        }
        return null;
    }

    public void Clear()
    {
        _buffer = null;
    }
}