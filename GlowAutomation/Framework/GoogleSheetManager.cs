using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace GlowAutomation.Framework
{
    public sealed class GoogleSheetManager
    {
        private static readonly Lazy<GoogleSheetManager> s_lazyInstance = new Lazy<GoogleSheetManager>(() => new GoogleSheetManager());
        public static GoogleSheetManager Instance => s_lazyInstance.Value;
        public static string SheetIdMain = "13ItApAkiEEFKphUcAJCXKVZ5BXMfF8ooBUy9ajb9Zpo";

        public void Write(List<object> values, int rowNum)
        {
            var SheetId = SheetIdMain;
            var Service = AuthorizeGoogleAppForSheetsService();
            var CellRange = $"Sheet1!I{rowNum}:I{rowNum}";
            UpdatGoogleSheetinBatch(values, SheetId, CellRange, Service);
        }

        private static SheetsService AuthorizeGoogleAppForSheetsService()
        {
            string[] Scopes = { SheetsService.Scope.Spreadsheets };
            string ApplicationName = "Glow";
            UserCredential Credential;

            using (var stream =
                new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
            {
                var credPath = "token.json";
                Credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.FromStream(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
            }

            var service = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = Credential,
                ApplicationName = ApplicationName,
            });

            return service;
        }

        private static void UpdatGoogleSheetinBatch(List<object> values, string spreadsheetId, string cellRange, SheetsService service)
        {
            var writeList = new List<IList<object>> { values };

            var request =
            service.Spreadsheets.Values.Update(new ValueRange() { Values = writeList }, spreadsheetId, cellRange);
            request.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.RAW;
            request.Execute();
        }
    }
}