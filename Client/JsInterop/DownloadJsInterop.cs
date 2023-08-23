using Microsoft.JSInterop;

namespace Artisan.III.Client.JsInterop;

[RegisterScoped]
public class DownloadJsInterop : JsInteropBase
{
    public DownloadJsInterop(IJSRuntime jsRuntime) : base(jsRuntime)
    { }

    protected override string JsFileName => "js/download.js";
    
    public async ValueTask DownloadAsync(Stream stream, string fileName)
    {
        var module = await GetModuleAsync();
        DotNetStreamReference streamRef = new(stream);
        
        await module.InvokeVoidAsync("downloadFile", streamRef, fileName);
    }
}