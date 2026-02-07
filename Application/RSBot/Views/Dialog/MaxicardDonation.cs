using SDUI.Controls;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSBot.Views.Dialog
{
    public partial class MaxicardDonation : UIWindow
    {
        public MaxicardDonation()
        {
            InitializeComponent();
        }

        class EpinResponse
        {
            public string durum { get; set; }
            public string aciklama { get; set; }
        }

        private async void buttonUse_Click(object sender, EventArgs e)
        {
            string epinusername = Environment.UserName;
            string epincode = textBoxCode.Text.Trim();
            string epinpass = textBoxPassword.Text.Trim();

            if (string.IsNullOrEmpty(epincode) || string.IsNullOrEmpty(epinpass))
            {
                MessageBox.Show("Please enter both code and password.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                buttonUse.Enabled = textBoxCode.Enabled = textBoxPassword.Enabled = false;

                using (var client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromSeconds(15);

                    var requestData = new { epinusername, epincode, epinpass };
                    string json = System.Text.Json.JsonSerializer.Serialize(requestData);
                    var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                    var request = await client.PostAsync("https://wripad.com/api/rsbot", content);
                    var epinResponse = await request.Content.ReadFromJsonAsync<EpinResponse>();

                    if (request.IsSuccessStatusCode)
                    {
                        
                        MessageBox.Show(
                            $"Thanks for your donation ♥",
                            "Success",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                    }
                    else
                    {
                        MessageBox.Show(
                            epinResponse.aciklama,
                            "Request failed!",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );
                    }
                }
            }
            catch (TaskCanceledException)
            {
                MessageBox.Show(
                    "The request time out. Please try again...",
                    "Time out!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Connection error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            finally
            {
                Cursor.Current = Cursors.Default;
                buttonUse.Enabled = textBoxCode.Enabled = textBoxPassword.Enabled = true;
                buttonUse.Text = "Use";
            }

        }
    }
}
