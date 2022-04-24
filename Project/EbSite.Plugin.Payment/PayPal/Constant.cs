namespace EbSite.Plugin.Payment.PayPal
{
    

    public class Constant
    {
        private string _Acct;
        private string _Amt;
        private string _APIPassword;
        private string _APISiganture;
        private string _APIUserName;
        private string _City;
        private string _CountryCode;
        private string _CreditCardType;
        private string _CurrencyCode;
        private string _Cvv2;
        private string _Environment;
        private string _ExpDate;
        private string _FirstName;
        private string _LastName;
        private string _Method;
        private string _PaymentAction;
        private string _State;
        private string _Street;
        private string _Zip;

        public string Acct
        {
            get
            {
                return this._Acct;
            }
            set
            {
                this._Acct = value;
            }
        }

        public string Amt
        {
            get
            {
                return this._Amt;
            }
            set
            {
                this._Amt = value;
            }
        }

        public string APIPassword
        {
            get
            {
                return this._APIPassword;
            }
            set
            {
                this._APIPassword = value;
            }
        }

        public string APISiganture
        {
            get
            {
                return this._APISiganture;
            }
            set
            {
                this._APISiganture = value;
            }
        }

        public string APIUserName
        {
            get
            {
                return this._APIUserName;
            }
            set
            {
                this._APIUserName = value;
            }
        }

        public string City
        {
            get
            {
                return this._City;
            }
            set
            {
                this._City = value;
            }
        }

        public string CountryCode
        {
            get
            {
                return this._CountryCode;
            }
            set
            {
                this._CountryCode = value;
            }
        }

        public string CreditCardType
        {
            get
            {
                return this._CreditCardType;
            }
            set
            {
                this._CreditCardType = value;
            }
        }

        public string CurrencyCode
        {
            get
            {
                return this._CurrencyCode;
            }
            set
            {
                this._CurrencyCode = value;
            }
        }

        public string Cvv2
        {
            get
            {
                return this._Cvv2;
            }
            set
            {
                this._Cvv2 = value;
            }
        }

        public string Environment
        {
            get
            {
                if (this._Environment == null)
                {
                    return "sandbox";
                }
                return this._Environment;
            }
            set
            {
                this._Environment = value;
            }
        }

        public string ExpDate
        {
            get
            {
                return this._ExpDate;
            }
            set
            {
                this._ExpDate = value;
            }
        }

        public string FirstName
        {
            get
            {
                return this._FirstName;
            }
            set
            {
                this._FirstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this._LastName;
            }
            set
            {
                this._LastName = value;
            }
        }

        public string Method
        {
            get
            {
                return this._Method;
            }
            set
            {
                this._Method = value;
            }
        }

        public string PaymentAction
        {
            get
            {
                return this._PaymentAction;
            }
            set
            {
                this._PaymentAction = value;
            }
        }

        public string State
        {
            get
            {
                return this._State;
            }
            set
            {
                this._State = value;
            }
        }

        public string Street
        {
            get
            {
                return this._Street;
            }
            set
            {
                this._Street = value;
            }
        }

        public string Zip
        {
            get
            {
                return this._Zip;
            }
            set
            {
                this._Zip = value;
            }
        }
    }
}

