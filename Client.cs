using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming_03_Assignment
{
    /// <summary>
    /// Represents a client with personal and account information.
    /// This class is designed for re-use across multiple methods in the program.
    /// </summary>
    public class Client
    {
        /// <summary>
        /// Gets or sets the unique identifier.
        /// </summary>
        public int ClientID { get; set; }
        
        /// <summary>
        /// Gets or sets the client's first name.
        /// </summary>
        public string Forename { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the client's last name.
        /// </summary>
        public string Surname { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the client's email address.
        /// </summary>
        public string EmailAddress { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the client's phone number.
        /// </summary>
        public string PhoneNumber { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the client's hashed password.
        /// This property is hidden to protect sensitive information.
        /// </summary>
        [System.ComponentModel.Browsable(false)]
        public string HashedPassword { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the client's address.
        /// </summary>
        public string Address { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the client's city of residence.
        /// </summary>
        public string City { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the client's postcode.
        /// </summary>
        public string Postcode { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets if the client have software.
        /// </summary>
        public bool Software { get; set; }

        /// <summary>
        /// Gets or sets if the client have a laptop or PC.
        /// </summary>
        public bool LaptopsPC { get; set; }

        /// <summary>
        /// Gets or sets if the client have games.
        /// </summary>
        public bool Games { get; set; }

        /// <summary>
        /// Gets or sets if the client have office tools.
        /// </summary>
        public bool OfficeTools { get; set; }

        /// <summary>
        /// Gets or sets if the client have accessories.
        /// </summary>
        public bool Accessories { get; set; }

        /// <summary>
        /// Gets or sets whether the client has administrative access.
        /// This property is hidden to protect sensitive information.
        /// </summary>
        [System.ComponentModel.Browsable(false)]
        public bool IsAdmin { get; set; }
    }
}
