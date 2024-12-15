using Microsoft.AspNetCore.Components;

public class ModalService {
    public event Action<Type, Dictionary<string, object>>? OnShow;
    public event Action? OnClose;

    public async void ShowModal<T>(Dictionary<string, object>? parameters = null) where T : ComponentBase {
        if (OnShow != null)
            await Task.Run(() => OnShow?.Invoke(typeof(T), parameters ?? new Dictionary<string, object>()));
    }

    public async void CloseModal() {
        if (OnShow != null)
            await Task.Run(() => OnClose?.Invoke());
    }
}
