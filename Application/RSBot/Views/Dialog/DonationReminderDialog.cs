using RSBot.Core;
using SDUI.Controls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace RSBot.Views.Dialog;

public partial class DonationReminderDialog : UIWindowBase
{
    private static readonly Dictionary<string, Dictionary<string, string>> Translations = new()
    {
        ["en_US"] = new()
        {
            ["Title"] = "We Need Your Support!",
            ["Message"] = "RSBot is completely free and open source.\nWe need your support to continue development.\nEven a small donation makes a big difference!",
            ["BuyMeCoffee"] = "☕ Buy Me a Coffee",
            ["GitHubSponsors"] = "💜 GitHub Sponsors",
            ["Patreon"] = "🎨 Patreon",
            ["FormTitle"] = "Support Us",
            ["or"] = "OR"
        },
        ["vn_VN"] = new()
        {
            ["Title"] = "Chúng tôi cần sự hỗ trợ của bạn!",
            ["Message"] = "RSBot hoàn toàn miễn phí và mã nguồn mở.\nChúng tôi cần sự hỗ trợ của bạn để tiếp tục phát triển.\nNgay cả một khoản quyên góp nhỏ cũng tạo nên sự khác biệt lớn!",
            ["BuyMeCoffee"] = "☕ Mời tôi một ly cà phê",
            ["GitHubSponsors"] = "💜 Nhà tài trợ GitHub",
            ["Patreon"] = "🎨 Patreon",
            ["FormTitle"] = "Ủng hộ chúng tôi",
            ["or"] = "hoặc"
        },
        ["tr_TR"] = new()
        {
            ["Title"] = "Desteğinize İhtiyacımız Var!",
            ["Message"] = "RSBot tamamen ücretsiz ve açık kaynaklı bir projedir.\nGeliştirmeye devam edebilmemiz için desteğinize ihtiyacımız var.\nKüçük bir bağış bile büyük fark yaratır!",
            ["BuyMeCoffee"] = "☕ Bana Kahve Ismarla",
            ["GitHubSponsors"] = "💜 GitHub Sponsorları",
            ["Patreon"] = "🎨 Patreon",
            ["FormTitle"] = "Destek Olun",
            ["or"] = "VEYA",
        },
        ["de_DE"] = new()
        {
            ["Title"] = "Wir brauchen Ihre Unterstützung!",
            ["Message"] = "RSBot ist komplett kostenlos und Open Source.\nWir brauchen Ihre Unterstützung um weiterzuentwickeln.\nSelbst eine kleine Spende macht einen großen Unterschied!",
            ["BuyMeCoffee"] = "☕ Kauf mir einen Kaffee",
            ["GitHubSponsors"] = "💜 GitHub Sponsoren",
            ["Patreon"] = "🎨 Patreon",
            ["FormTitle"] = "Unterstützen Sie uns",
            ["or"] = "oder",
        },
        ["es_ES"] = new()
        {
            ["Title"] = "¡Necesitamos tu apoyo!",
            ["Message"] = "RSBot es completamente gratis y de código abierto.\nNecesitamos tu apoyo para continuar el desarrollo.\n¡Incluso una pequeña donación marca una gran diferencia!",
            ["BuyMeCoffee"] = "☕ Cómprame un café",
            ["GitHubSponsors"] = "💜 Patrocinadores de GitHub",
            ["Patreon"] = "🎨 Patreon",
            ["FormTitle"] = "Apóyanos",
            ["or"] = "o",
        },
        ["ru_RU"] = new()
        {
            ["Title"] = "Нам нужна ваша поддержка!",
            ["Message"] = "RSBot полностью бесплатен и имеет открытый исходный код.\nНам нужна ваша поддержка для продолжения разработки.\nДаже небольшое пожертвование имеет большое значение!",
            ["BuyMeCoffee"] = "☕ Купите мне кофе",
            ["GitHubSponsors"] = "💜 Спонсоры GitHub",
            ["Patreon"] = "🎨 Patreon",
            ["FormTitle"] = "Поддержите нас",
            ["or"] = "или",
        },
        ["ar_AR"] = new()
        {
            ["Title"] = "نحن بحاجة إلى دعمكم!",
            ["Message"] = "RSBot مجاني تماماً ومفتوح المصدر.\nنحن بحاجة إلى دعمكم لمواصلة التطوير.\nحتى التبرع الصغير يحدث فرقاً كبيراً! ",
            ["BuyMeCoffee"] = "☕ اشتر لي قهوة",
            ["GitHubSponsors"] = "💜 رعاة GitHub",
            ["Patreon"] = "🎨 باتريون",
            ["FormTitle"] = "ادعمنا",
            ["or"] = "أو",
        }
    };

    public DonationReminderDialog()
    {
        InitializeComponent();
    }

    private void DonationReminderDialog_Load(object sender, EventArgs e)
    {
        ApplyTranslations();
    }

    private void ApplyTranslations()
    {
        var currentLanguage = Kernel.Language;

        if (!Translations.ContainsKey(currentLanguage))
            currentLanguage = "English";

        var translations = Translations[currentLanguage];

        Text = translations["FormTitle"];
        lblTitle.Text = translations["Title"];
        lblMessage.Text = translations["Message"];
        btnBuyMeCoffee.Text = translations["BuyMeCoffee"];
        btnGitHubSponsors.Text = translations["GitHubSponsors"];
        btnPatreon.Text = translations["Patreon"];
        labelOr.Text = translations["or"];
    }

    private void btnBuyMeCoffee_Click(object sender, EventArgs e)
    {
        Process.Start(new ProcessStartInfo { FileName = "https://buymeacoffee.com/sdclowen", UseShellExecute = true });
        DialogResult = DialogResult.OK;
        Close();
    }

    private void btnGitHubSponsors_Click(object sender, EventArgs e)
    {
        Process.Start(new ProcessStartInfo { FileName = "https://github.com/sponsors/SDClowen", UseShellExecute = true });
        DialogResult = DialogResult.OK;
        Close();
    }

    private void btnPatreon_Click(object sender, EventArgs e)
    {
        Process.Start(new ProcessStartInfo { FileName = "https://www.patreon.com/sdclowen", UseShellExecute = true });
        DialogResult = DialogResult.OK;
        Close();
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
        GlobalConfig.Set("RSBot.LastDonationReminderDate", DateTime.Now.ToString("yyyy-MM-dd"));
        DialogResult = DialogResult.Cancel;
        Close();
    }

    private void pictureBoxMaxicardImage_Click(object sender, EventArgs e)
    {
        var maxicard = new MaxicardDonation();
        maxicard.ShowDialog(this);
    }

    private void buttonClose_Click(object sender, EventArgs e)
    {
        Close();
    }
}
