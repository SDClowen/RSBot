namespace RSBot.General.Models
{
    internal class Account
    {
        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        /// <value>
        /// The username.
        /// </value>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the servername.
        /// </summary>
        /// <value>
        /// The servername.
        /// </value>
        public string Servername { get; set; }

        /// <summary>
        /// Gets or sets the characters.
        /// </summary>
        /// <value>
        /// The characters.
        /// </value>
        public string[] Characters { get; set; }
    }
}