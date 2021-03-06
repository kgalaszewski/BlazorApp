using Microsoft.JSInterop;

namespace PocketAnalyzerServer.Extensions;

public static class IJSRuntimeExtension
{
    public static async ValueTask ToastrSuccess(this IJSRuntime JSRuntime, string message)
    {
        await JSRuntime.InvokeVoidAsync("ShowToastr", "git", message);
    }

    public static async ValueTask ToastrError(this IJSRuntime JSRuntime, string message)
    {
        await JSRuntime.InvokeVoidAsync("ShowToastr", "bad", message);
    }
    public static async ValueTask SwalSuccessAlert(this IJSRuntime JSRuntime, string message, string buttonMessage)
    {
        await JSRuntime.InvokeVoidAsync("SwalAlert", "git", message, buttonMessage);
    }

    public static async ValueTask SwalErrorAlert(this IJSRuntime JSRuntime, string message, string buttonMessage)
    {
        await JSRuntime.InvokeVoidAsync("SwalAlert", "bad", message, buttonMessage);
    }

    public static async ValueTask SwalOnDelete(this IJSRuntime JSRuntime, string onDeleteMessage)
    {
        await JSRuntime.InvokeVoidAsync("SwalOnDelete", onDeleteMessage);
    }

    public static async ValueTask<bool> OverrideConfirm(this IJSRuntime JSRuntime)
    {
        var isConfirmed = await JSRuntime.InvokeAsync<bool>("OverrideConfirm");
        return isConfirmed;
    }
}
