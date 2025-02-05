using MudBlazor;

namespace FinAspire.Web;

public static class Configuration
{
    public const string HttpClientName = "FinAspire";

    public static string BackEndUrl { get; set; } = "http://localhost:5267";
    
    public static MudTheme Theme = new()
    {
        Typography = new Typography
        {
            Default = new DefaultTypography
            {
                FontFamily = ["RaleWay", "sans-serif"]
            }
        },
        PaletteLight = new PaletteLight
        {
            Primary = Colors.Gray.Darken4,
            Secondary = Colors.Gray.Darken1,
            Background = Colors.Gray.Lighten4,
            AppbarBackground = Colors.Gray.Darken4,
            AppbarText =  Colors.Gray.Lighten4,
            TextPrimary = Colors.Shades.Black,
            DrawerText = Colors.Shades.Black ,
            DrawerBackground = Colors.Gray.Lighten4
        },
        PaletteDark = new PaletteDark
        {
            Primary = Colors.Gray.Darken4,
            Secondary = Colors.Gray.Darken1,
            Background = Colors.Gray.Darken2,
            AppbarBackground = Colors.Gray.Darken4,
            AppbarText =  Colors.Shades.Black,
            TextPrimary = Colors.Shades.Black,
            DrawerText = Colors.Shades.Black ,
            DrawerBackground = Colors.Gray.Lighten4
        },
    };

    
}