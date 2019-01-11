using Microsoft.Exchange.WebServices.Data;
using System;
using System.Linq;

namespace MonitoringApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ExchangeService service = new ExchangeService(
                ExchangeVersion.Exchange2007_SP1)
            {
                Credentials = new WebCredentials("it@intrapost.nl", "_Jyx6b52"),

                //service.UseDefaultCredentials = false;

                TraceEnabled = true,
                TraceFlags = TraceFlags.All
            };


            service.AutodiscoverUrl(
                "it@intrapost.nl", RedirectionUrlValidationCallback);

            var folderViewSize = int.MaxValue;
            var view = new FolderView(folderViewSize)
            {
                Traversal = FolderTraversal.Deep
            };

            var results = service.FindFolders(WellKnownFolderName.MsgFolderRoot, view);

            var folders = results.Folders.ToArray();

            var poboxFolderName = "Postbussen";
            Folder poboxFolder = folders.Where(x => x.DisplayName == poboxFolderName).SingleOrDefault();
            if (poboxFolder == null)
            {
                poboxFolder = new Folder(service)
                {
                    DisplayName = poboxFolderName,
                    FolderClass = "IPF.Note"
                };
                poboxFolder.Save(WellKnownFolderName.Inbox);
            }

            var preimportFolderName = "pre-import";
            Folder preImportFolder = folders.Where(x => x.DisplayName == preimportFolderName).SingleOrDefault();
            if (preImportFolder == null)
            {
                preImportFolder = new Folder(service)
                {
                    DisplayName = preimportFolderName,
                    FolderClass = "IPF.Note"
                };
                preImportFolder.Save(poboxFolder.Id);
            }

            var succesfullyImportedFolderName = "successfully imported";

            var successfullyImportedFolder = folders.Where(x => x.DisplayName == succesfullyImportedFolderName).SingleOrDefault();
            if (successfullyImportedFolder == null)
            {
                successfullyImportedFolder = new Folder(service)
                {
                    DisplayName = succesfullyImportedFolderName,
                    FolderClass = "IPF.Note"
                };
                successfullyImportedFolder.Save(poboxFolder.Id);
            }

            var failedToImportFolderName = "failed import";
            var failedToImportFolder = folders.Where(x => x.DisplayName == failedToImportFolderName).SingleOrDefault();
            if (failedToImportFolder == null)
            {
                failedToImportFolder = new Folder(service)
                {
                    DisplayName = failedToImportFolderName,
                    FolderClass = "IPF.Note"
                };
                failedToImportFolder.Save(poboxFolder.Id);
            }

            Folder inbox = Folder.Bind(service, WellKnownFolderName.Inbox);
            //SearchFilter senderFilter = new SearchFilter.IsEqualTo(EmailMessageSchema.Sender, "");
            SearchFilter subjectFilter = new SearchFilter.IsEqualTo(ItemSchema.Subject, "O2C702 postbussen met een brengservice");

            var itemView = new ItemView(10)
            {
                Traversal = ItemTraversal.Shallow
            };

            var poboxMailResults = service.FindItems(WellKnownFolderName.Inbox, subjectFilter, itemView);

            Console.WriteLine($"Found items: {poboxMailResults.TotalCount}");
            Console.WriteLine("Press Enter/Return to move items");
            Console.ReadLine();


            service.MoveItems(poboxMailResults.Select(x => x.Id), preImportFolder.Id);

            Console.WriteLine("Items moved");
            Console.ReadLine();

            //PropertySet propSet = new PropertySet(BasePropertySet.IdOnly);
            //Folder inbox = Folder.Bind(
            //    service, WellKnownFolderName.Inbox, propSet);
            //
            //PropertySet propSet2 = new PropertySet(BasePropertySet.IdOnly);
            //Folder createdFolder = Folder.Bind(
            //    service, folder.Id, propSet2);
            //
            //var folderViewSize = int.MaxValue;
            //FolderView view = new FolderView(folderViewSize);
            //var isHiddenProp = new ExtendedPropertyDefinition(
            //    0x10f4, MapiPropertyType.Boolean);
            //
            //view.PropertySet = new PropertySet(
            //    BasePropertySet.IdOnly, FolderSchema.DisplayName, isHiddenProp);
            //
            //view.Traversal = FolderTraversal.Deep;
            //var findFolderResults = service.FindFolders(
            //    WellKnownFolderName.MsgFolderRoot, view);

            //EmailMessage email = new EmailMessage(service);
            //
            //email.ToRecipients.Add("mark@intrapost.nl");
            //
            //email.Subject = "HelloWorld";
            //email.Body = new MessageBody(
            //    "This is the first email I've sent using the EWS Managed API");
            //
            //email.Send();

            Console.ReadLine();
        }

        private static bool RedirectionUrlValidationCallback(
            string redirectionUrl)
        {
            bool result = false;

            Uri redirectionUri = new Uri(redirectionUrl);

            if (redirectionUri.Scheme == "https")
            {
                result = true;
            }

            return result;
        }
    }
}
