using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidPay.Services.Implementations
{
    public class UFEService
    {
        private static UFEService _instance;
        private decimal currentFee = 0.05m; // Initial value

        private UFEService()
        {
        }

        public static UFEService Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UFEService();
                return _instance;
            }
        }

        public void UpdateFee()
        {
            Random rand = new Random();
            decimal ufe = (decimal)rand.NextDouble() * 2;
            currentFee = Math.Round(currentFee * ufe, 2);
        }

        public decimal ApplyFee(decimal amount) 
        {
            return amount + (amount * currentFee);
        }

    }
}
