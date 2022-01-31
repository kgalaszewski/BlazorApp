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
}
