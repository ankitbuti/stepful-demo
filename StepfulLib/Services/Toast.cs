namespace StepfulLib;

public class ToastService{

    public event Action<string> OnShow;
    public void ShowToast(string message)
    {
        OnShow?.Invoke(message);
    }
}

