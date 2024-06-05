using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Test.Shared.BusinessObjects.ValueObjects;

namespace Test.Razor.Views.Components;
public partial class AddressEditor
{
    [Parameter]
    public Address Address { get; set; }

    InputText NameInput;

    //protected override async Task OnAfterRenderAsync(bool firstRender)
    //{
    //    if (firstRender)
    //    {
    //        await NameInput.Element.Value.FocusAsync();
    //    }
    //}
}
