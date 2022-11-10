// Decompiled with JetBrains decompiler
// Type: Relatorio_Produtos_VHSYS.Properties.Settings
// Assembly: Relatorio_Produtos_VHSYS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3740E6A2-8A63-493B-9E56-76A1104CAF61
// Assembly location: C:\Users\Aroldo Jales\Desktop\net5.0-windows\Relatorio_Produtos_VHSYS.dll

using System.CodeDom.Compiler;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Relatorio_Produtos_VHSYS.Properties
{
  [CompilerGenerated]
  [GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.10.0.0")]
  internal sealed class Settings : ApplicationSettingsBase
  {
    private static Settings defaultInstance = (Settings) SettingsBase.Synchronized((SettingsBase) new Settings());

    public static Settings Default => Settings.defaultInstance;

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("")]
    public string accessToken
    {
      get => (string) this[nameof (accessToken)];
      set => this[nameof (accessToken)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("")]
    public string secretAccessToken
    {
      get => (string) this[nameof (secretAccessToken)];
      set => this[nameof (secretAccessToken)] = (object) value;
    }

    [ApplicationScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("no-cache")]
    public string cacheControl => (string) this[nameof (cacheControl)];

    [ApplicationScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("application/json")]
    public string contentType => (string) this[nameof (contentType)];
  }
}
