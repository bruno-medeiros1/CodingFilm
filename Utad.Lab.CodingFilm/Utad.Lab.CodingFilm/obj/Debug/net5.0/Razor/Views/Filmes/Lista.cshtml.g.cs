#pragma checksum "C:\Users\bruno\OneDrive\Backup_PC\Documents\Universidade\3ºAno-1ºSemestre\Laboratório\Coding Film\Projeto Visual Studio\Utad.Lab.CodingFilm\Utad.Lab.CodingFilm\Views\Filmes\Lista.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2ffe0e3de877c54fd7c7abfddc9a9b359860867f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Filmes_Lista), @"mvc.1.0.view", @"/Views/Filmes/Lista.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\bruno\OneDrive\Backup_PC\Documents\Universidade\3ºAno-1ºSemestre\Laboratório\Coding Film\Projeto Visual Studio\Utad.Lab.CodingFilm\Utad.Lab.CodingFilm\Views\_ViewImports.cshtml"
using Utad.Lab.CodingFilm;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\bruno\OneDrive\Backup_PC\Documents\Universidade\3ºAno-1ºSemestre\Laboratório\Coding Film\Projeto Visual Studio\Utad.Lab.CodingFilm\Utad.Lab.CodingFilm\Views\_ViewImports.cshtml"
using Utad.Lab.CodingFilm.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\bruno\OneDrive\Backup_PC\Documents\Universidade\3ºAno-1ºSemestre\Laboratório\Coding Film\Projeto Visual Studio\Utad.Lab.CodingFilm\Utad.Lab.CodingFilm\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\bruno\OneDrive\Backup_PC\Documents\Universidade\3ºAno-1ºSemestre\Laboratório\Coding Film\Projeto Visual Studio\Utad.Lab.CodingFilm\Utad.Lab.CodingFilm\Views\Filmes\Lista.cshtml"
using Utad.Lab.CodingFilm.Areas.Admin.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2ffe0e3de877c54fd7c7abfddc9a9b359860867f", @"/Views/Filmes/Lista.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6984c9101d49c2058b9f0fcc88c4443fc9cdf4b0", @"/Views/_ViewImports.cshtml")]
    public class Views_Filmes_Lista : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IList<Categoria>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "C:\Users\bruno\OneDrive\Backup_PC\Documents\Universidade\3ºAno-1ºSemestre\Laboratório\Coding Film\Projeto Visual Studio\Utad.Lab.CodingFilm\Utad.Lab.CodingFilm\Views\Filmes\Lista.cshtml"
  
    ViewData["Title"] = "A minha lista";

    //  Casting
    var categorias = (List<Categoria>)ViewData["Categorias"];
    var categoriasPreferidas = (List<CategoriasFavoritas>)ViewData["CategoriasPreferidas"];

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<style>
    #table_€ {
        font-size: 10px;
    }
    #table {
        background: rgb(116,63,251);
        background: linear-gradient(75deg, rgba(116,63,251,0.5914740896358543) 0%, rgba(158,70,252,1) 72%);
        color: white;
        border: 2px solid mediumpurple;
    }
</style>

");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2ffe0e3de877c54fd7c7abfddc9a9b359860867f5569", async() => {
                WriteLiteral("\r\n    <h2> ");
#nullable restore
#line 25 "C:\Users\bruno\OneDrive\Backup_PC\Documents\Universidade\3ºAno-1ºSemestre\Laboratório\Coding Film\Projeto Visual Studio\Utad.Lab.CodingFilm\Utad.Lab.CodingFilm\Views\Filmes\Lista.cshtml"
    Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
                WriteLiteral(@" </h2>
    <h5>Aqui poderás editar a tua lista de categorias preferidas e visualizar os filmes que já viste!</h5>
    <hr />

    <!-- Lista de categorias preferidas-->
    <div class=""row"">

        <h3><strong>Lista de Categorias Preferidas</strong></h3>
");
#nullable restore
#line 33 "C:\Users\bruno\OneDrive\Backup_PC\Documents\Universidade\3ºAno-1ºSemestre\Laboratório\Coding Film\Projeto Visual Studio\Utad.Lab.CodingFilm\Utad.Lab.CodingFilm\Views\Filmes\Lista.cshtml"
         if (TempData["Success"] != null)
        {

#line default
#line hidden
#nullable disable
                WriteLiteral(@"            <div class=""alert alert-success alert-dismissible"" role=""alert"">
                <button type=""button"" class=""close"" data-dismiss=""alert"" aria-label=""Close""><span aria-hidden=""true"">&times;</span></button>
                <span style=""font-weight:bold"">");
#nullable restore
#line 37 "C:\Users\bruno\OneDrive\Backup_PC\Documents\Universidade\3ºAno-1ºSemestre\Laboratório\Coding Film\Projeto Visual Studio\Utad.Lab.CodingFilm\Utad.Lab.CodingFilm\Views\Filmes\Lista.cshtml"
                                          Write(TempData["Success"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("</span>\r\n            </div>\r\n");
#nullable restore
#line 39 "C:\Users\bruno\OneDrive\Backup_PC\Documents\Universidade\3ºAno-1ºSemestre\Laboratório\Coding Film\Projeto Visual Studio\Utad.Lab.CodingFilm\Utad.Lab.CodingFilm\Views\Filmes\Lista.cshtml"
        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 40 "C:\Users\bruno\OneDrive\Backup_PC\Documents\Universidade\3ºAno-1ºSemestre\Laboratório\Coding Film\Projeto Visual Studio\Utad.Lab.CodingFilm\Utad.Lab.CodingFilm\Views\Filmes\Lista.cshtml"
         if (TempData["NoSuccess"] != null)
        {

#line default
#line hidden
#nullable disable
                WriteLiteral(@"            <div class=""alert alert-danger alert-dismissible"" role=""alert"">
                <button type=""button"" class=""close"" data-dismiss=""alert"" aria-label=""Close""><span aria-hidden=""true"">&times;</span></button>
                <span style=""font-weight:bold"">");
#nullable restore
#line 44 "C:\Users\bruno\OneDrive\Backup_PC\Documents\Universidade\3ºAno-1ºSemestre\Laboratório\Coding Film\Projeto Visual Studio\Utad.Lab.CodingFilm\Utad.Lab.CodingFilm\Views\Filmes\Lista.cshtml"
                                          Write(TempData["NoSuccess"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("</span>\r\n            </div>\r\n");
#nullable restore
#line 46 "C:\Users\bruno\OneDrive\Backup_PC\Documents\Universidade\3ºAno-1ºSemestre\Laboratório\Coding Film\Projeto Visual Studio\Utad.Lab.CodingFilm\Utad.Lab.CodingFilm\Views\Filmes\Lista.cshtml"
        }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
        <div class=""col-md-4"">
            <hr style=""height:2px;border:none;color:#333;background-color:#333;"" />

            <table class=""table table-hover"" style='border: 2px solid mediumpurple;'>
                <thead class=""thead-dark"">
                    <tr>
                        <th scope=""col"" id=""table"">Categoria</th>
                    </tr>
                </thead>
                <tbody>

");
#nullable restore
#line 59 "C:\Users\bruno\OneDrive\Backup_PC\Documents\Universidade\3ºAno-1ºSemestre\Laboratório\Coding Film\Projeto Visual Studio\Utad.Lab.CodingFilm\Utad.Lab.CodingFilm\Views\Filmes\Lista.cshtml"
                     foreach (var categoria in @categoriasPreferidas)
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <tr>\r\n                            <td style=\'border: 2px solid mediumpurple;\'><span style=\"font-weight:bold; font-size: 11px;\" class=\"glyphicon glyphicon-trash\"></span> ");
#nullable restore
#line 62 "C:\Users\bruno\OneDrive\Backup_PC\Documents\Universidade\3ºAno-1ºSemestre\Laboratório\Coding Film\Projeto Visual Studio\Utad.Lab.CodingFilm\Utad.Lab.CodingFilm\Views\Filmes\Lista.cshtml"
                                                                                                                                                              Write(categoria.Categoria.Nome);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                        </tr>\r\n");
#nullable restore
#line 64 "C:\Users\bruno\OneDrive\Backup_PC\Documents\Universidade\3ºAno-1ºSemestre\Laboratório\Coding Film\Projeto Visual Studio\Utad.Lab.CodingFilm\Utad.Lab.CodingFilm\Views\Filmes\Lista.cshtml"
                    }

#line default
#line hidden
#nullable disable
                WriteLiteral("                </tbody>\r\n            </table>\r\n        </div>\r\n\r\n        <br /><br />\r\n        <div class=\"col-md-4\">\r\n");
#nullable restore
#line 71 "C:\Users\bruno\OneDrive\Backup_PC\Documents\Universidade\3ºAno-1ºSemestre\Laboratório\Coding Film\Projeto Visual Studio\Utad.Lab.CodingFilm\Utad.Lab.CodingFilm\Views\Filmes\Lista.cshtml"
             if (@categoriasPreferidas.Count == 0)
            {



#line default
#line hidden
#nullable disable
                WriteLiteral(@"                <div class=""alert alert-danger alert-dismissible"" role=""alert"">
                    <button type=""button"" class=""close"" data-dismiss=""alert"" aria-label=""Close""><span aria-hidden=""true"">&times;</span></button>
                    <h3 style=""font-weight:bold"">Nota</h3>
                    Não possuis nenhuma categoria favorita, adiciona abaixo!
                </div>
");
#nullable restore
#line 80 "C:\Users\bruno\OneDrive\Backup_PC\Documents\Universidade\3ºAno-1ºSemestre\Laboratório\Coding Film\Projeto Visual Studio\Utad.Lab.CodingFilm\Utad.Lab.CodingFilm\Views\Filmes\Lista.cshtml"
            }
            else
            {

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                <div class=""alert alert-warning alert-dismissible"" role=""alert"">
                    <button type=""button"" class=""close"" data-dismiss=""alert"" aria-label=""Close""><span aria-hidden=""true"">&times;</span></button>
                    <h3 style=""font-weight:bold"">Nota</h3>
                    Ao adicionares uma categoria à tua lista de favoritos irás receber uma notificação por email quando sair um novo filme pertencente a uma dessas categorias!
                </div>
");
#nullable restore
#line 88 "C:\Users\bruno\OneDrive\Backup_PC\Documents\Universidade\3ºAno-1ºSemestre\Laboratório\Coding Film\Projeto Visual Studio\Utad.Lab.CodingFilm\Utad.Lab.CodingFilm\Views\Filmes\Lista.cshtml"
            }

#line default
#line hidden
#nullable disable
                WriteLiteral("        </div>\r\n    </div>\r\n\r\n    <div class=\"row\">\r\n        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2ffe0e3de877c54fd7c7abfddc9a9b359860867f13176", async() => {
                    WriteLiteral("\r\n            <div class=\"col-md-3\">\r\n                <div class=\"form-group\">\r\n                    <label> Adicionar categoria à lista </label>\r\n                    <select class=\"form-control\" name=\"inputNome\">\r\n\r\n");
#nullable restore
#line 99 "C:\Users\bruno\OneDrive\Backup_PC\Documents\Universidade\3ºAno-1ºSemestre\Laboratório\Coding Film\Projeto Visual Studio\Utad.Lab.CodingFilm\Utad.Lab.CodingFilm\Views\Filmes\Lista.cshtml"
                         foreach (var categoria in @categorias)
                        {

#line default
#line hidden
#nullable disable
                    WriteLiteral("                            ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2ffe0e3de877c54fd7c7abfddc9a9b359860867f14101", async() => {
                        WriteLiteral(" ");
#nullable restore
#line 101 "C:\Users\bruno\OneDrive\Backup_PC\Documents\Universidade\3ºAno-1ºSemestre\Laboratório\Coding Film\Projeto Visual Studio\Utad.Lab.CodingFilm\Utad.Lab.CodingFilm\Views\Filmes\Lista.cshtml"
                                                        Write(categoria.Nome);

#line default
#line hidden
#nullable disable
                        WriteLiteral(" ");
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                    BeginWriteTagHelperAttribute();
#nullable restore
#line 101 "C:\Users\bruno\OneDrive\Backup_PC\Documents\Universidade\3ºAno-1ºSemestre\Laboratório\Coding Film\Projeto Visual Studio\Utad.Lab.CodingFilm\Utad.Lab.CodingFilm\Views\Filmes\Lista.cshtml"
                               WriteLiteral(categoria.Nome);

#line default
#line hidden
#nullable disable
                    __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                    __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                    __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    WriteLiteral("\r\n");
#nullable restore
#line 102 "C:\Users\bruno\OneDrive\Backup_PC\Documents\Universidade\3ºAno-1ºSemestre\Laboratório\Coding Film\Projeto Visual Studio\Utad.Lab.CodingFilm\Utad.Lab.CodingFilm\Views\Filmes\Lista.cshtml"
                        }

#line default
#line hidden
#nullable disable
                    WriteLiteral(@"
                    </select>
                </div>
                <div class=""form-group animate__animated animate__tada"">
                    <button class=""btn btn-success"">Adicionar categoria</button>
                </div>
            </div>
        ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
    </div>

        <!-- Lista de Filmes vistos-->
        <div class=""row"">

            <h3><strong>Lista de filmes vistos</strong></h3>
            <hr style=""height:2px;border:none;color:#333;background-color:#333;"" />

            <table class=""table"">
                <thead>
                    <tr>
                        <th>Filme</th>
                        <th>Data</th>
                        <th>Horário</th>
                        <th>Tipo de Bilhete</th>
                        <th>Bilhetes comprados</th>
                        <th>Preço</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td>Licorice Pizza</td>
                        <td>27/01/2022</td>
                        <td>22:00h</td>
                        <td>Estudante</td>
                        <td>2</td>
                        <td>12,80 <span class=""glyphicon glyphicon-euro"" id=""table_€""></span> </td>
                    ");
                WriteLiteral(@"</tr>
                </tbody>
            </table>

            <div class=""form-group"">
                <div class=""alert alert-warning alert-dismissible"" role=""alert"">
                    <span style=""font-weight:bold; font-style:italic"">Exemplo meramente demostrativo</span>
                </div>
            </div>
        </div>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IList<Categoria>> Html { get; private set; }
    }
}
#pragma warning restore 1591