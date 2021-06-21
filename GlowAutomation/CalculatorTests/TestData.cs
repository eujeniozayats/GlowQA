using GlowAutomation.Framework;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace GlowAutomation.CalculatorTests
{
    public partial class TC001_CalculateLoan
    {
        public class TestData
        {
            public string Price { get; set; }
            public string UpfrontPaymentPercents { get; set; }
            public string Term { get; set; }
            public string APR { get; set; }
            public string UpfrontPaymentValue { get; set; }
            public string TotalBorrowed { get; set; }
            public string MonthlyPayment { get; set; }
            public string CostOfCredit { get; set; }
            public int RownNumber { get; set; }
        }

        private static IEnumerable<object[]> GetData()
        {
            string[] Scopes = { SheetsService.Scope.Spreadsheets };
            string ApplicationName = "Glow";
            UserCredential credential;

            using (var stream = new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
            {
                var credPath = "token.json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.FromStream(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                Console.WriteLine("Credential file saved to: " + credPath);
            }

            var service = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            string spreadsheetId = GoogleSheetManager.SheetIdMain;
            string range = "Sheet1!A2:H";
            var request = service.Spreadsheets.Values.Get(spreadsheetId, range);

            var response = request.Execute();
            var values = response.Values;
            if (values != null && values.Count > 0)
            {
                int counter = 2;
                foreach (IList<object> row in values)
                {
                    yield return new object[] { new TestData
                    {
                        Price = row[0].ToString(),
                        UpfrontPaymentPercents = row[1].ToString().Trim(new char[] { '%' }),
                        Term = row[2].ToString(),
                        APR = row[3].ToString().Trim(new char[] { '%' }),
                        UpfrontPaymentValue = row[4].ToString().Trim(new char[] { '£' }),
                        TotalBorrowed = row[5].ToString().Trim(new char[] { '£' }),
                        MonthlyPayment = row[6].ToString().Trim(new char[] { '£' }),
                        CostOfCredit = row[7].ToString().Trim(new char[] { '£' }),
                        RownNumber = counter
                    } };
                    counter++;
                }
            }
        }
    }
}